using EcommerceWeb.Entities;
using EcommerceWeb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWeb.Repositories.Implementaciones
{
	public class MarcaRepository:RepositoryBase<Marca>, IMarcaRepository
	{
        public MarcaRepository(EcommerceDbContext context)
            : base(context)
        {
               
        }
    }
}
