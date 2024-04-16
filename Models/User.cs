using System.ComponentModel.DataAnnotations;

namespace SeniorApi.Models {
    public class User {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Código do usuário é obrigatório.")]
        public string UserCode { get; set; }

        [Required(ErrorMessage = "Nome do usuário é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CPF do usuário é obrigatório.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Município do usuário é obrigatório.")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Data de nascimento do usuário é obrigatório.")]
        public string BirthDate { get; set; }

        //authentication vars;
        [Required(ErrorMessage = "Usuário de login é obrigatório.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Cargo do usuário é obrigatório.")]
        public string Role { get; set; }
    }
}
