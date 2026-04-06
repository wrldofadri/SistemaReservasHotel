using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaReservasHotel.Data;
using System.Linq;

namespace SistemaReservasHotel.Controllers
{
    [Authorize(Roles = "Administrador")] // Solo el Administrador puede ver el dashboard [cite: 13, 15]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
          
            ViewBag.TotalHoteles = await _context.Hoteles.CountAsync();
            ViewBag.TotalUsuarios = await _context.Users.CountAsync();
            ViewBag.TotalReservas = await _context.Reservas.CountAsync();

   
            var reservasPorMes = _context.Reservas
                .GroupBy(r => r.FechaInicio.Month)
                .Select(g => new { Mes = g.Key, Cantidad = g.Count() })
                .OrderBy(g => g.Mes)
                .ToList();

            ViewBag.GraficoDatos = reservasPorMes.Select(x => x.Cantidad).ToList();
            ViewBag.GraficoEtiquetas = reservasPorMes.Select(x => x.Mes.ToString()).ToList();

            return View();
        }
    }
}