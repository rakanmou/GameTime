using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GameTime.ViewModels.User
{
    public class LoginVM
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("إسم المستخدم")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DataType(DataType.Password)]
        [DisplayName("كلمة المرور")]
        public required string Password { get; set; }

        [DisplayName("تذكرني")]
        public bool RememberMe { get; set; }
    }
}
