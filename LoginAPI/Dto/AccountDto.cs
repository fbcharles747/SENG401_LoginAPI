namespace LoginAPI.Dto
{
    public class AccountDto
    {
        public string UCID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        //Access code will combine UCID with user set PIN when user sign up
        public string AccessCode { get; set; }

    }
}
