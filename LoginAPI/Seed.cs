using LoginAPI.Data;
using LoginAPI.Model;

namespace LoginAPI
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext dataContext)
        {
            _context= dataContext;
        }
        /*
         * public int Id { get; set; }
        public string UCID { get; set; }
        public string Password { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        */

        public void SeedDataContext()
        {
            if(!_context.Accounts.Any())
            {
                var accounts = new List<Account>()
                {
                    new Account()
                    {
                        BirthDate=new DateTime(2001,12,16),
                        UCID="30112677",
                        Password="12345",
                        FirstName="Charles",
                        LastName="Huang",
                        Email="chunchun.huang@ucalgary.ca",
                        Address="Wherever",
                        AccessCode="3011267712345"
                        
                    }

                };

                _context.Accounts.AddRange(accounts);
                _context.SaveChanges();

            }
        }

    }
   
}
