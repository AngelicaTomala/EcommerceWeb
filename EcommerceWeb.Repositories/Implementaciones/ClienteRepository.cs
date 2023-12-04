using EcommerceWeb.Entities;
using EcommerceWeb.Repositories.Interfaces;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Repositories.Implementaciones
{
	public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
	{
		public ClienteRepository(EcommerceDbContext _context) : base(_context)
		{
		}

        public async Task<Cliente?> BuscarPorEmailAsync(string email)
        {
            return await context.Set<Cliente>().FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
