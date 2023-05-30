using ProjSistemaFinanceiro.Aplicacao.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Aplicacao.Interfaces.IServicos
{
    public interface IIdentityService
    {
        Task<AuthCadastroDTOResponse> CadastrarUsuario(AuthCadastroDTO usuarioCadastro);
        Task<AuthLoginDTOResponse> Login(AuthLoginDTO usuarioLogin);
        Task Logout();
        //Task<UsuarioLoginDTOResponse> LoginSemSenha(string usuarioId);
    }
}
