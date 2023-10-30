namespace EcommerceWeb.Server.Entities
{
    //POCO : PLAIN OLD CLR (COMMON LANGUAGE RUNTINE) OBJECT
    // ES UN OBJETO PLANO DE UN OBJECTO CLR
    //CLR define todos los tipos de datos 
	public class Categoria
	{
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string? Comentarios { get; set; }
    }
}
