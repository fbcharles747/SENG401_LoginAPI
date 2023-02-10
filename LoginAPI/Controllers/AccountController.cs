
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
        public IActionResult CreateAccount([FromBody] SignUpInput input)
        {
            if (input == null) return BadRequest(ModelState);
            if(_accountRepository.Exist(input.UCID))
            {
                ModelState.AddModelError("","Account already exists");
                return StatusCode(422, ModelState);
            }

            // we create account from signup input because:
            // 1. we need to parse datetime from javascript date
            // 2. Access code is combined from UCID and user-set PIN
            Account account=new Account()
            {
                UCID= input.UCID,
                FirstName=input.firstName,
                LastName=input.lastName,
                BirthDate=DateTime.Parse(input.birthDate),
                Email=input.email,
                Address=input.address,
                Password=input.password,
                AccessCode=input.UCID+input.PIN,
            };


            

            if (!_accountRepository.CreateAccount(account))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500,ModelState);

            }

            return Ok("Successfully Created");

        }




    }
}
