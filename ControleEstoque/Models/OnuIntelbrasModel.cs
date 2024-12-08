using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Models
{
    public class OnuIntelbrasModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do produto")] //Diz que o nome é um campo obrigatório
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o mac do produto")] //Diz que o mac é um campo obrigatório
        public string Mac { get; set; }
        [Required(ErrorMessage = "Digite o número de série do produto")] //Diz que o numero de serie é um campo obrigatório
        public string NumeroSerie { get; set; }
    }
}
