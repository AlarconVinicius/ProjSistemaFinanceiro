using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Entidade.ResultadoPaginas
{
    public class ResultadoErroPagina
    {
        public ResultadoErroPagina()
        {
            Erros = new List<object>();
        }

        public string Titulo { get; set; }
        public int Status { get; set; }
        public List<object> Erros { get; set; }

        public void AdicionarErro(string nomePropriedade, string mensagem)
        {
            //Erros.Add($"Propriedade({nomePropriedade}): {mensagem}");
            Erros.Add(new
            {
                Propriedade = nomePropriedade,
                Mensagem = mensagem
            });
        }

    }
}
