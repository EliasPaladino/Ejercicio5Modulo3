using Ejercicio5Modulo3.Domain.Entities;
using Ejercicio5Modulo3.Domain.Entities.DTOs;

namespace Ejercicio5Modulo3.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<List<Usuario>> getAllUsersAsync(String apellido, String genero);
        public Task postUserBySeed();
    }
}
