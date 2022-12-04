﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinal.Desktop.Models;

namespace TPFinal.Desktop.Service
{
    public class UsuariosService
    {
        private const string URI = "http://localhost:60422/api/usuarios";

        public async Task<Usuario> GetUsuario(string id)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{URI}/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosJsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Usuario>(usuariosJsonString);
                    }
                    else
                    {
                        throw new Exception("Não foi possível os usuarios\nErro: " + response.StatusCode);
                    }
                }
            }
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var usuariosJsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Usuario[]>(usuariosJsonString).ToList();
                    }
                    else
                    {
                        throw new Exception("Não foi possível os usuarios\nErro: " + response.StatusCode);
                    }
                }
            }
        }

        public async Task<bool> PostUsuario(Usuario usuario)
        {
            using (var client = new HttpClient())
            {
                var result = await client.PostAsync(URI, returnUsuarioContent(usuario));
                return result.IsSuccessStatusCode;
            }
        }

        public async Task<bool> PutUsuario(Usuario usuario)
        {
            using (var client = new HttpClient())
            {
                
                HttpResponseMessage responseMessage = await client.PutAsync($"{URI}/{usuario.Id}", returnUsuarioContent(usuario));
                return responseMessage.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteUsuario(string id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await client.DeleteAsync($"{URI}/{id}");
                return responseMessage.IsSuccessStatusCode;
            }
        }

        private StringContent returnUsuarioContent(Usuario usuario)
        {
            var serializedUsuario = JsonConvert.SerializeObject(usuario);
            return new StringContent(serializedUsuario, Encoding.UTF8, "application/json");
        } 
    }
}
