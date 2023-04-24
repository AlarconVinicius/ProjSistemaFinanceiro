using ProjSistemaFinanceiro.Aplicacao.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Aplicacao.Interfaces.IServicos
{
    public interface IIdentityService
    {
        Task<UsuarioCadastroDTOResponse> CadastrarUsuario(UsuarioCadastroDTO usuarioCadastro);
        Task<UsuarioLoginDTOResponse> Login(UsuarioLoginDTO usuarioLogin);
        Task Logout();
        //Task<UsuarioLoginDTOResponse> LoginSemSenha(string usuarioId);
    }
}
