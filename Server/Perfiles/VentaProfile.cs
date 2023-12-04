using AutoMapper;
using EcommerceWeb.Shared.Request;
using ECommerceWeb.Entities;

namespace ECommerceWeb.Server.Perfiles;

public class VentaProfile : Profile
{
    public VentaProfile()
    {
        CreateMap<VentaDto, Venta>();
        CreateMap<VentaDetalleDto, VentaDetalle>();
    }
}