
using AutoMapper;
using LoginAPI.Dto;
using LoginAPI.Interface;
using LoginAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountController(IAccountRepository accountRepository,IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type =typeof(Account))]
        [ProducesResponseType(400)]
        public IActionResult GetAccountCredential([FromQuery] string UCID, [FromQuery] string password)
        {
            if (!_accountRepository.Exist(UCID.Trim())) return NotFound("User not exists");
           
            var account=_accountRepository.GetAccountCredential(UCID.Trim(), password.Trim());
            if(account == null) return NotFound();
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var mappedAccount=_mapper.Map<AccountDto>(account);
            return Ok(mappedAccount);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAccount([FromBody] AccountDto account)
        {
            if (account == null) return BadRequest(ModelState);
            if(_accountRepository.Exist(account.UCID))
            {
                ModelState.AddModelError("","Account already exists");
                return StatusCode(422, ModelState);
            }
            var MappedAccount=_mapper.Map<Account>(account);

            if (!_accountRepository.CreateAccount(MappedAccount))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500,ModelState);

            }

            return Ok("Successfully Created");

        }




    }
}
