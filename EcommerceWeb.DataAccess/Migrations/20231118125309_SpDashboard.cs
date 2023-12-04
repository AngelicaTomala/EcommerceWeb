using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWeb.Server.Migrations
{
    /// <inheritdoc />
    public partial class SpDashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE uspDashBoard
	            -- Add the parameters for the stored procedure here
            AS
            BEGIN
	            -- SET NOCOUNT ON added to prevent extra result sets from
	            -- interfering with SELECT statements.
	            SET NOCOUNT ON;

                -- Insert statements for procedure here
	            SELECT 
		            sum(v.total) as TotalVenta,
		            count(v.id) as CantidadVentas,
		            (select count(c.id) from Cliente c) CantidadClientes,
		            (select count(p.id) from Producto P where p.Estado = 1) CantidadProductos
	            from Venta v
	            where v.Estado = 1
            END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROC uspDashBoard");
        }
    }
}
