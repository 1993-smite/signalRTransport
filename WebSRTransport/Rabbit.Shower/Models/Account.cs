using System.ComponentModel.DataAnnotations;

namespace Rabbit.Shower.Models
{
    public class Account
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Не заполнен логин")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Недопустимая длина логина")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не заполнен пароль")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Недопустимая длина пороля")]
        public string Password { get; set; }
    }

    public class AccountView: Account
    {
        public string ReturnUrl { get; set; }

        public AccountView(): base()
        {

        }

        public AccountView(string returnUrl): this()
        {
            ReturnUrl = returnUrl;
        }
    }
}
