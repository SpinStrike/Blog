using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class AuthorizeModel
    {
        [Required(ErrorMessage = "Введите имя пользавателя")]
        [MinLength(length:2, ErrorMessage = "Имя пользователя  должно быть не мение 2 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(length: 6, ErrorMessage = "Пароль должен включать в себя не мение 6 символов")]
        public string Password { get; set; }

        public bool IsRememberMe { get; set; }
    }
}