using System.ComponentModel.DataAnnotations;

namespace SQLTemporalTablesDemo.Models.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
