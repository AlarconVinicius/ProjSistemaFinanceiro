﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Entidade.ResultadoPaginas
{
    public class ResultadoPagina<T> where T : class
    {
        //public int CurrentPage { get; set; }
        //public int PageSize { get; set; }
        //public int TotalCount { get; set; }
        //public int TotalPages { get; set; }
        //public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public List<T> Resultados { get; set; } = new List<T>();
    }
}
