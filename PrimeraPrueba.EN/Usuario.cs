using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PrimeraPrueba.EN
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caractere")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Correo es obligatorio")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Password es obligatorio")]
        //DataType: Especifica que es un campo de contarseña, en lugar de mostrar el texto muestra los puntos
        [DataType(DataType.Password)]
        //50(Máximo)                                                    //5 (Mínimo)
        [StringLength(50, ErrorMessage = "Password debe estar entre 5 a 50 carateres", MinimumLength = 5)]
        public string Password { get; set; }

        //Relacion con llave foranea ROL
        [ValidateNever]
        public Roles Rol { get; set; }

        //NotMapped: indica que el top_aux no es tomado en cuenta en el mapeo
        [NotMapped]
        public int Top_Aux { get; set; }// Metodo de busqueda auxiliar
    }
}
