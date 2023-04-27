using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Aplicacao.DTOs.Auth
{
    public class AuthCadastroDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 150 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Senha { get; set; }

        [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
        public string SenhaConfirmacao { get; set; }
    }
}
