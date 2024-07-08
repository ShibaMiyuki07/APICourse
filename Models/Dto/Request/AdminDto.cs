using API.Services.Autre;

namespace API.Models.Dto.Request
{
    public class AdminDto
    {
        public string? Login { get; set; }

        private string _Password = string.Empty;

        public string? Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = Utils.ChiffrementPassword(value!);
            }
        }
    }
}
