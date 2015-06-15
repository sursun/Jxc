using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SecurityGuard.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 应至少包含 {2} 个字符。", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "两次输入密码不一致！")]
        public string ConfirmPassword { get; set; }
    }
}
