using System.Data;
using Dapper;
using EcommerceWeb.Repositories.Implementaciones;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Repositories.Implementaciones;

public class VentaRepository : RepositoryBase<Venta>, IVentaRepository
{
    public VentaRepository(EcommerceDbContext context)
        : base(context)
    {
    }

    public override async Task AddAsync(Venta entity)
    {
        await context.AddAsync(entity);
    }

    public async Task CrearTransaccionAsync()
    {
        //va a bloquear la tabla hasta que el proceso acabe es decir no podran hacer crud
        await context.Database.BeginTransactionAsync(IsolationLevel.Serializable);
    }

    public async Task ConfirmarTransaccionAsync()
    {
        await context.Database.CommitTransactionAsync();
        await context.SaveChangesAsync();
    }

    public async Task ResetearTransaccionAsync()
    {
        await context.Database.RollbackTransactionAsync();
    }

    public async Task<Dashboard> MostrarDashboard()
    {
        var query = await context.Database.GetDbConnection()
            .QuerySingleAsync<Dashboard>("uspDashBoard", commandType: CommandType.StoredProcedure);

        return query;
    }
}