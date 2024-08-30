using System.ComponentModel.DataAnnotations;

namespace API_2__Bimestre.Dto
{
    public class FuncionarioDTO
    {
        [Required] //Torna o campo obrigatório
        public string Nome { get; set; }
        [Required]
        public string cpf { get; set; }
        [Required]
        public string CTPS { get; set; }
        [Required]
        public string RG { get; set; }
        [Required]
        public string Funcao { get; set; }
        [Required]
        public string Setor { get; set; }
        [Required]
        public string Sala { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string UF { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Numero { get; set; }
        [Required]
        public string CEP { get; set; }

    }
}
