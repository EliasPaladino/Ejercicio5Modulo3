using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Entities.DTOs;
using Ejercicio5Modulo3.Repository;
using Ejercicio5Modulo3.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Ejercicio5Modulo3.Services
{
    public class UsuarioService : IUsuarioService
    {
        private Ejercicio5Modulo3Context _context;
        private IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        public UsuarioService(Ejercicio5Modulo3Context context, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<Usuario>> getAllUsersAsync(String apellido, String genero)
        {
            if (apellido == null && genero == null) return await _context.Usuario.ToListAsync();
            else if (apellido != null)
            {
                if (genero != null)
                {
                    return await _context.Usuario.Where(w => w.Genero.ToLower().Equals(genero.ToLower()) && w.Genero.ToLower().Equals(genero.ToLower())).ToListAsync();
                }
                return await _context.Usuario.Where(w => w.Apellido.ToLower().Equals(apellido.ToLower())).ToListAsync();
            } else
            {
                return await _context.Usuario.Where(w => w.Genero.ToLower().Equals(genero.ToLower())).ToListAsync();
            }
        }

        public async Task postUserBySeed()
        {
            if(_context.Usuario.Count() > 0)
            {
                throw new Exception("Ya hay datos cargados en la base de datos");
            }

            var client = _httpClientFactory.CreateClient("service-user");
            var response = await client.GetAsync($"?results={_configuration.GetSection("SEED_NUMBER").Value}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ResponseUsuariosDTO>(content);

            if(result.usuarios != null)
            {
                foreach (UsuarioDTO item in result.usuarios)
                {
                    Usuario usuario = new Usuario
                    {
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Edad = item.Edad,
                        Genero = item.Genero,
                        Ciudad = item.Ciudad,
                        Email = item.Email,
                        Estado = item.Estado,
                        NombreUsuario = item.NombreUsuario,
                        Password = item.Password,
                        Pais = item.Pais
                    };

                    await _context.Usuario.AddAsync(usuario);
                    await _context.SaveChangesAsync();
                }
            }
            

        }
    }
}
