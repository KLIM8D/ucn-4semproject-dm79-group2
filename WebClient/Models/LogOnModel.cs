using System.ComponentModel.DataAnnotations;
using BusinessLogic.Resources;

namespace WebClient.Models
{
    public class LogOnModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsValid(string userName, string password)
        {
            return new UserLogic().LoginUser(userName, password);
        }
    }
}