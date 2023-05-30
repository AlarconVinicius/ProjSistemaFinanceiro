using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Identity.Entidades
{
    public class ApplicationUserEntity : IdentityUser
    {
        [Column(Order = 2)]
        public string Nome { get; set; }

        [Column(Order = 3)]
        public string Sobrenome { get; set; }

        [Column(Order = 4)]
        public string NomeCompleto { get; set; }
    }
}
