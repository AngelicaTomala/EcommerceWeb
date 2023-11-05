using Microsoft.AspNetCore.Components;

namespace EcommerceWeb.Client.Shared
{
	public partial class LoadingComponent
	{
		[Parameter]
        public bool IsLoading { get; set; }

    }
}
