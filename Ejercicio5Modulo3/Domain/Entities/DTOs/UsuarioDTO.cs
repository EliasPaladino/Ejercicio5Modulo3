using System.Text.Json.Serialization;

namespace Ejercicio5Modulo3.Domain.Entities.DTOs
{
    public class UsuarioDTO
    {
        [JsonPropertyName("name.first")]
        public string Nombre { get; set; }

        [JsonPropertyName("name.last")]
        public string Apellido { get; set; }

        [JsonPropertyName("dob.age")]
        public int Edad { get; set; }

        [JsonPropertyName("gender")]
        public string Genero { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("login.username")]
        public string NombreUsuario { get; set; }

        [JsonPropertyName("login.password")]
        public string Password { get; set; }

        [JsonPropertyName("city")]
        public string Ciudad { get; set; }

        [JsonPropertyName("state")]
        public string Estado { get; set; }

        [JsonPropertyName("country")]
        public string Pais { get; set; }
    }
}
