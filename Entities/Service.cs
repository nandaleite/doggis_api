namespace WebApi.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TempoEstimado { get; set; }
        public string Preco { get; set; }
        public string ProdutoNecessario { get; set; }
        public string Profissional { get; set; }
        
    }
}