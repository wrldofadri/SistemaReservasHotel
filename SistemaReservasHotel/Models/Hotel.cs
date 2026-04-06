using System.ComponentModel.DataAnnotations;

namespace SistemaReservasHotel.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del hotel es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El precio por noche es obligatorio")]
        [Range(1, 10000, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal PrecioPorNoche { get; set; }

        public string Descripcion { get; set; }

        // Relación: Un hotel puede tener muchas reservas
        public ICollection<Reserva> Reservas { get; set; }
    }
}