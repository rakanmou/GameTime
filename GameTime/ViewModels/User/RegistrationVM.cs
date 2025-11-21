using GameTime.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameTime.ViewModels.User
{
    public class RegistrationVM
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(30, ErrorMessage = "يجب ألا يتجاوز إسم المستخدم 40 حرف")]
        [RegularExpression(@"^[A-Za-z0-9._-]+$", ErrorMessage = "اسم المستخدم غير صالح")]
        [DisplayName("إسم المستخدم")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [StringLength(40, ErrorMessage = "يجب ألا يتجاوز البريد الإلكتروني 40 حرف")]
        [EmailAddress(ErrorMessage = "الرجاء إدخال بريد إلكتروني صالح")]
        [Display(Name = "البريد الإلكتروني")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "يجب أن تحتوي كلمة المرور على حرف كبير وحرف صغير ورقم واحد على الأقل.")]
        [DataType(DataType.Password)]
        [DisplayName("كلمة المرور")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمة المرور غير متطابقة.")]
        [Display(Name = "تأكيد كلمة المرور")]
        public required string ConfirmPassword { get; set; }
    }
}
