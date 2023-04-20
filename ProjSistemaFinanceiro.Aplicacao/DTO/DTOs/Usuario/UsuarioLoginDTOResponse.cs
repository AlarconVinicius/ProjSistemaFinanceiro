﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjSistemaFinanceiro.Aplicacao.DTO.DTOs.Usuario
{
    public class UsuarioLoginDTOResponse
    {
        public bool Sucesso => Erros.Count == 0;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AccessToken { get; private set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? RefreshToken { get; private set; }
        //public string RefreshToken { get; private set; }

        public List<string> Erros { get; private set; }

        public UsuarioLoginDTOResponse() =>
            Erros = new List<string>();

        public UsuarioLoginDTOResponse(bool sucesso, string accessToken, DateTime refreshToken) : this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public void AdicionarErro(string erro) =>
            Erros.Add(erro);

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}

