using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entities
{
    public class UsuarioEntity
    {
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int idUsuario { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Limite máximo de 50 caracteres.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Formato de E-mail inválido.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} Senha muito longa", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "senha")]
        public string senha { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "dataCriacao")]
        public DateTime dataCriacao { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} must be at least {2} characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "dataAlteracao")]
        public DateTime dataAlteracao { get; set; }

        [Required]
        public int ativo { get; set; }
    }
}
