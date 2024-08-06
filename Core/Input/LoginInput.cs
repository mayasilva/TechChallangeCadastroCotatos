using System.ComponentModel.DataAnnotations;

namespace Core.Input
{
    public class LoginInput
    {
        [Required(ErrorMessage = "Campo usuário é obrigatório")]
        public required string Usuario { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        public required string Senha { get; set; }
    }
}
