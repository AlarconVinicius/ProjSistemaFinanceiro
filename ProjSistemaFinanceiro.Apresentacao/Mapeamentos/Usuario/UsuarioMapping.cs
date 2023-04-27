using ProjSistemaFinanceiro.Aplicacao.DTOs.Usuario;
using ProjSistemaFinanceiro.Identity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProjSistemaFinanceiro.Apresentacao.Mapeamentos.Usuario
{
    public class UsuarioMapping
    {
        public UsuarioViewDTO MapToGetDTO(ApplicationUserEntity usuario)
        {
            if(usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return new UsuarioViewDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                Telefone = usuario.PhoneNumber
            };
        }

        public ApplicationUserEntity MapToUpdOrDelDTO(UsuarioViewDTO usuario)
        {
            if(usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            return new ApplicationUserEntity
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email,
                PhoneNumber = usuario.Telefone
            };
        }
    }
}
