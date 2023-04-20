using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.Usuario
{
    public class UsuarioCadastroDTOResponse
    {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public UsuarioCadastroDTOResponse() =>
            Erros = new List<string>();

        public UsuarioCadastroDTOResponse(bool sucesso = true) : this() =>
            Sucesso = sucesso;

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
}
