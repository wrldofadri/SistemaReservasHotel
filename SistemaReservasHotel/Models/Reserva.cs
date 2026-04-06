using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaReservasHotel.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        // Llave Foránea hacia Usuario
        [Required]
        public string UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public AppUser Usuario { get; set; }

        // Llave Foránea hacia Hotel
        [Required]
        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
    }
}