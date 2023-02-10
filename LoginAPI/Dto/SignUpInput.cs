namespace LoginAPI.Dto
{
    public class SignUpInput
    {
        public string UCID { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }
        public string password { get; set; }
        public string birthDate { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string PIN { get; set; }
    }
}
