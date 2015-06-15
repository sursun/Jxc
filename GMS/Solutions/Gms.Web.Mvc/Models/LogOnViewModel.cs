using System.ComponentModel.DataAnnotations;

namespace SecurityGuard.ViewModels
{
    public partial class LogOnViewModel
    {
        [Required]
        [Display(Name = "登录名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Display(Name = "记住我？")]
        public bool RememberMe { get; set; }

        public bool EnablePasswordReset { get; set; }
    }
}
