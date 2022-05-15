using System.ComponentModel.DataAnnotations;
namespace Mutual_MyPJ_HP.Data.Entities
{
    public class ClientesTipo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descripción Tipo de Cliente")]
        [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String Name { get; set; }

        [Display(Name = "Cliente Inae")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public String ClienteInae { get; set; }

    }
}
