using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ConsomeApi
    {
        public static async Task<List<Usuario>> GetUsuarios(string URI)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var usuarioJsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<Usuario[]>(usuarioJsonString).ToList();
                    }
                    else
                    {
                        throw new Exception("Não foi possível obter o usuário: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<Usuario> GetUsuarioById(string URI)
        {
            using (var cliente = new HttpClient())
            {
                HttpResponseMessage response = await cliente.GetAsync(URI);
                if (response.IsSuccessStatusCode)
                {
                    var UsuarioJsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Usuario>(UsuarioJsonString);
                }
                else
                {
                    throw new Exception("Falha ao obter o usuario: "+ response.StatusCode);
                }
            }
        }

        public static async void AddUsuario(string URI, Usuario usuario)
        {
            using (var client = new HttpClient())
            {
                var serializedUsuario = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(URI, content);
            }
        }

        public static async void UpdateUsuario(string URI, Usuario usuario)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URI + "/" + usuario.UsuarioId, usuario);
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Falha ao atualizar o usuário: " + responseMessage);
                }
            }
        }

        public static async void DeleteUsuario(string URI, int codigoUsuario)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await
                    client.DeleteAsync(String.Format("{0}/{1}", URI, codigoUsuario));
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Falha ao excluir o usuário :" + responseMessage.StatusCode);
                }
            }
        }
    }
}
 