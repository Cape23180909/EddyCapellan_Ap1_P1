using EddyCapellan_Ap1_P1.DAL;
using EddyCapellan_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EddyCapellan_Ap1_P1.Services;

public class CobroService
{
    private readonly Contexto _contexto;

    public CobroService(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo Existe
    public async Task<bool> Existe(int cobroid)
    {
        return await _contexto.Cobros.AnyAsync(c => c.CobroId == cobroid);
    }
    //Metodo Insertar 
    private async Task<bool> Insertar(Cobros cobro)
    {
        _contexto.Cobros.Add(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Modificar(Cobros cobro)
    {
        var cobroExistente = await _contexto.Cobros
        .Include(c => c.CobroDetalles)
        .FirstOrDefaultAsync(c => c.CobroId == cobro.CobroId);

        if (cobroExistente != null)
        {

            foreach (var detalleExistente in cobroExistente.CobroDetalles.ToList())
            {
                if (!cobro.CobroDetalles.Any(d => d.DetalleId == detalleExistente.DetalleId))
                {
                    _contexto.CobroDetalle.Remove(detalleExistente);
                }
            }

            cobroExistente.CobroDetalles = cobro.CobroDetalles;

            _contexto.Entry(cobroExistente).CurrentValues.SetValues(cobro);
            return await _contexto.SaveChangesAsync() > 0;
        }
        return false;
    }

    //Metodo Guardar 
    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.CobroId))
            return await Insertar(cobro);
        else
            return await Modificar(cobro);
    }
    //Metodo Eliminar
    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Cobros
            .Where(c => c.CobroId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo Buscar 
    public async Task<Cobros?> Buscar(int id)
    {
        return await _contexto.Cobros
            .AsNoTracking()
            .Include(c => c.Deudor)
            .Include(c => c.CobroDetalles)
            .FirstOrDefaultAsync(c => c.CobroId == id);
    }
    //Metodo Listar
    public async Task<List<Cobros>> listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await _contexto.Cobros
            .AsNoTracking()
            .Include(c => c.Deudor)
            .Include(c => c.CobroDetalles)
            .Where(criterio)
            .ToListAsync();
    }
    //Este metodo me ayude a coleccionar los deudores que tengo registrado en mi tabla prestamos
    public async Task<List<Deudores>> ListarDeudores()
    {
        return await _contexto.Deudores
            .AsNoTracking()
            .ToListAsync();
    }

    //Metodo ObtenerDeudoresConPrestamos ya guardados con su dicho monto
    public async Task<List<Deudores>> ObtenerDeudoresConPrestamos()
    {
        var deudoresConPrestamos = _contexto.Prestamos
      .Include(p => p.Deudor)
      .Select(p => p.Deudor)
      .Distinct()
      .ToList();

        return deudoresConPrestamos;
    }

    public async Task<List<Prestamos>> ObtenerPrestamosPorDeudorId(int deudorId)
    {
        return await _contexto.Prestamos
            .Where(p => p.DeudorId == deudorId)
            .OrderByDescending(p => p.PrestamoId)
            .ToListAsync();
    }

    private async Task<List<Prestamos>> CargarPrestamosPorDeudorAsync(int deudorId)
    {
        return await _contexto.Prestamos.Where(p => p.DeudorId == deudorId).ToListAsync();
    }

}