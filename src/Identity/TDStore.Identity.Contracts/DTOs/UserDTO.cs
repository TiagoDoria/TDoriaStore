using System.ComponentModel.DataAnnotations;

namespace TDStore.Identity.Contracts.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Campo EMAIL obrigatório!")]
        [EmailAddress(ErrorMessage = "Campo EMAIL inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo SENHA obrigatório!")]
        [StringLength(100, ErrorMessage = "Campo SENHA deve ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Senhas devem ser iguais!")]
        public string ConfirmPassword { get; set; }
    }

    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Campo EMAIL obrigatório!")]
        [EmailAddress(ErrorMessage = "Campo EMAIL inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo SENHA obrigatório!")]
        [StringLength(100, ErrorMessage = "Campo SENHA deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }

    public class UserResponseLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }

    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
