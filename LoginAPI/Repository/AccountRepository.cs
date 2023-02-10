using LoginAPI.Data;
using LoginAPI.Dto;
using LoginAPI.Interface;
using LoginAPI.Model;

namespace LoginAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public bool Exist(string UCID)
        {
            return _context.Accounts.Any(a=>a.UCID == UCID);
        }

        

        public Account GetAccountCredential(string UCID, string password)
        {
            return _context.Accounts.Where(a => a.UCID == UCID && a.Password == password).FirstOrDefault();
        }

        public bool CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            return Save();
        }

        public bool Save()
        {
            var saved=_context.SaveChanges();
            return saved > 0;
        }
    }
}
