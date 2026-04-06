using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SistemaReservasHotel.Models
{
    // Heredamos de IdentityUser para tener email, password, etc.
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        // Relación: Un usuario puede tener muchas reservas
        public ICollection<Reserva> Reservas { get; set; }
    }
}