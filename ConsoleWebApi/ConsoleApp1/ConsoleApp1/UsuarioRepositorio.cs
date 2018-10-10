using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class UsuarioRepositorio
    {
        HttpClient cliente = new HttpClient();

        public UsuarioRepositorio()
        {
            cliente.BaseAddress = new Uri("https://localhost:44319/");

            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Usuario>> getUsuariosAsync()
        {
            HttpResponseMessage response = await cliente.GetAsync("api/usuarios");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Usuario>>(dados);
            }
            return new List<Usuario>();
        }
    }
}
