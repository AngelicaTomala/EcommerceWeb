using AutoMapper;
using EcommerceWeb.Entities;
using EcommerceWeb.Shared;
using EcommerceWeb.Shared.Request;

namespace EcommerceWeb.Server.Perfiles
{
	public class ProductoProfile: Profile
	{
        public ProductoProfile()
        {
            //origem -> destino
            CreateMap<ProductoDtoRequest, Producto>();
        }
    }
}
