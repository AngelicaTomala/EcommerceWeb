using EcommerceWeb.Entities;
using EcommerceWeb.Repositories.Interfaces;
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
	}
}
