﻿using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Usuarios
{
    public  class UsuarioService
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://rpgapi20242pam.azurewebsites.net/Usuarios";

        private string _token;

        public UsuarioService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.Id = await _request.PostReturnIntAsync(_apiUrlBase + urlComplementar, u, string.Empty);
            
            return u;
        }

        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u = await _request.PostAsync(_apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }


        public async Task<int> PutFotoUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/AtualizarFoto";
            var result = await _request.PutAsync(_apiUrlBase + urlComplementar, u, _token);
            return result;
        }


        public async Task<Usuario> GetUsuarioAsync(int usuarioId)
        {
            string urlComplementar = string.Format("/{0}", usuarioId);
            var usuario = await
                _request.GetAsync<Models.Usuario>(_apiUrlBase + urlComplementar, _token);
            return usuario;
        }

        



    }
}
