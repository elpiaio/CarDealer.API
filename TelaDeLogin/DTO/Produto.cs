using System.ComponentModel.DataAnnotations;

namespace TelaDeLogin.DTO
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }  
        public int Quantidade { get; set; }
        public string Imagem { get; set; }        
    }
}
