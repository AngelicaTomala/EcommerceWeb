using EcommerceWeb.Shared.Request;
using EcommerceWeb.Shared.Response;
using EcommerceWeb.Shared;

namespace EcommerceWeb.Client.Proxy.Interfaces
{
    public interface IVentaProxy
    {
        Task<BaseResponse> CrearVenta(VentaDto request);

        Task<DashboardDto> MostrarDashboard();
    }
}