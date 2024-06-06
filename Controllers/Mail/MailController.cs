using System.Text;
using System.Text.Json;
using Filtro.Models;

namespace Filtro.Controllers
{
    public class MailController
    {
        public async void EnviarCorreo()
        {
            try
            {
                string url = "https://api.mailersend.com/v1/email";

                string jwtToken = "mlsn.b8ecbf115696599c1831f3ab2b0b4a1a03e4ca8a18d6e4d4a4e7dff390241b6d";

                var emailMessage = new Email
                {
                    from = new From { email = "info@trial-v69oxl5oo6rg785k.mlsender.net" },
                    to = new[]
                    {
                        new To { email = "juandaortega0712@gmail.com" }
                    },
                    subject = "Matrícula",
                    text = "Haz creado una nueva matrícula acá se te enviarán los datos sobre el curso al que te matriculaste",
                    html = "Matrícula"
                };

                string jsonBody = JsonSerializer.Serialize(emailMessage);
                Console.WriteLine(jsonBody);

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwtToken}");

                    StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Correo enviado correctamente");
                        Console.WriteLine(responseBody);
                    }
                    else 
                    {
                        Console.WriteLine($"La solicitud falló con el código de estado: {response.StatusCode}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}