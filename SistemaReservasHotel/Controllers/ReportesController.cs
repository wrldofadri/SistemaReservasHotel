using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using SistemaReservasHotel.Data;

public class ReportesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> TodasLasReservas()
    {
        var modelo = await _context.Reservas.Include(r => r.Hotel).Include(r => r.Usuario).ToListAsync();
        return new ViewAsPdf("ReporteReservas", modelo);
    }


    public async Task<IActionResult> HotelesPopulares()
    {
        var modelo = await _context.Hoteles
            .OrderByDescending(h => h.Reservas.Count)
            .Take(5)
            .ToListAsync();
        return new ViewAsPdf("ReporteHoteles", modelo);
    }
}