using GameTime.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameTime.ViewModels
{
    public class UserRegistrationVM
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز إسم المستخدم 20 حرف")]
        [DisplayName("إسم المستخدم")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(20, ErrorMessage = "يجب ألا يتجاوز البريد الإلكتروني 20 حرف")]
        [EmailAddress(ErrorMessage = "الرجاء إدخال بريد إلكتروني صالح")]
        [Display(Name = "البريد الإلكتروني")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "يجب أن تتكون كلمة المرور من 8 أحرف على الأقل")]
        [DataType(DataType.Password)]
        [DisplayName("كلمة المرور")]
        public required string Password { get; set; }
    }
}
