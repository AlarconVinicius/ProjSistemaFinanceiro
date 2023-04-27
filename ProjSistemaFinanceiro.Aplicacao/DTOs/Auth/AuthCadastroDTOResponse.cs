using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Aplicacao.DTOs.Auth
{
    public class AuthCadastroDTOResponse
    {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public AuthCadastroDTOResponse() =>
            Erros = new List<string>();

        public AuthCadastroDTOResponse(bool sucesso = true) : this() =>
            Sucesso = sucesso;

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}

