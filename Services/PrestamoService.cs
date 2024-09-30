using EddyCapellan_Ap1_P1.DAL;
using EddyCapellan_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EddyCapellan_Ap1_P1.Services;

public class PrestamoService
{
    private readonly Contexto _contexto;

    public PrestamoService(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo Existe 
    public async Task<bool> Existe(int deudorid)
    {
        return await _contexto.Prestamos.AnyAsync(p => p.PrestamoId == deudorid);
    }
    //Metodo Insertar
    private async Task<bool> Insertar(Prestamos prestamo)
    {
        _contexto.Prestamos.Add(prestamo);
        return await _contexto.SaveChangesAsync() > 0;
    }
    //Metodo Modificar 
    private async Task <bool> Modificar (Prestamos prestamo)
    {
        _contexto.Prestamos.Update(prestamo);
        var modificado = await _contexto.SaveChangesAsync() >0;
        return modificado;
    }
    //Metod Guardar 
    public async Task <bool> Guardar (Prestamos prestamo)
    {
        if (! await Existe(prestamo.PrestamoId))
            return await Insertar(prestamo);
        else 
            return await Modificar(prestamo);
    }
    //Metodo Eliminar
    public async Task <bool> Eliminar (int id)
    {
        var eliminado = await _contexto.Prestamos
            .Where(p =>p.PrestamoId == id)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo Buscar 
    public async Task <Prestamos?> Buscar (int id)
    {
        return await _contexto.Prestamos
            .AsNoTracking()
            .FirstOrDefaultAsync( p => p.PrestamoId == id);
    }
    //Metodo Listar 
    public async Task <List<Prestamos>> Listar (Expression<Func<Prestamos, bool>> criterio)
    {
        return await _contexto.Prestamos
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}