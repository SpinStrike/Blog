using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Требуется ввсести имя пользавателя")]
        [MinLength(length: 2, ErrorMessage = "Введите имя пользователя не мение 2 символов")]
        [MaxLength(length: 255,ErrorMessage = "Слишком длинное имя пользователя. Максимальный размер поля 255 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Требуется ввсести электронную почту")]
        [RegularExpression(pattern:@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Не верный формат электронной почты" )]
        [MinLength(length: 10, ErrorMessage = "Введите значение электронной почты не мение 10 символов")]
        [MaxLength(length: 255, ErrorMessage = "Слишком длинное значение электронной почты. Максимальный размер поля 255 символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Требуется ввсести пароль")]
        [MinLength(length: 6, ErrorMessage = "Введите пароль не мение 6 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Требуется повторить пароль")]
        [Compare(otherProperty:"Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
} 