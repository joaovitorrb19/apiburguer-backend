using System.ComponentModel.DataAnnotations;

namespace ApiBurguer.Model {
    public class Carne {
        public Carne()
        {
            this.dataCadastro = DateTime.Now;
            this.dataAlteracao = "nemhuma...";
        }
        [Key]
        public int id {get;set;}
        [Required]
        public string? nome {get;set;}

        public DateTime dataCadastro {get;set;}

        public string? dataAlteracao {get;set;}
    }
}