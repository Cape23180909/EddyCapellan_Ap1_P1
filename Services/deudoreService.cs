using EddyCapellan_Ap1_P1.DAL;
using EddyCapellan_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EddyCapellan_Ap1_P1;

public class DeudoreService
{
    private readonly Contexto _contexto; 

    public DeudoreService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
    {
        return await _contexto.Deudores
             .AsNoTracking() 
             .Where(criterio)
             .ToListAsync(); 
    }

    public async Task<List<Deudores>> ListarDeudores()
    {
        return await _contexto.Deudores
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Deudores>> ObtenerDeudoresConPrestamos()
    {
        return await _contexto.Deudores
            .Include(d => d.Prestamos) 
            .AsNoTracking() 
            .ToListAsync();
    }
}