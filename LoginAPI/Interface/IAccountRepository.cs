using LoginAPI.Dto;
using LoginAPI.Model;

namespace LoginAPI.Interface
{
    public interface IAccountRepository
    {

        //read
        Account GetAccountCredential(string UCID,string password);

        //create
        bool CreateAccount(Account account);


        bool Save();
        bool Exist(string UCID);


    }
}
