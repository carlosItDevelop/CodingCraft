using System;
using System.ComponentModel.DataAnnotations;
using Cooperchip.MedicalManagement.Domain.Entidade;

namespace Cooperchip.MedicalManagement.Web.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MuralViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mural"></param>
        public MuralViewModel(Mural mural)
        {
            this.MuralId = MuralId;
            this.Autor = Autor;
            this.Aviso = Aviso;
            this.Data = Data;
            this.Titulo = Titulo;
        }

        /// <summary>
        /// 
        /// </summary>
        public MuralViewModel()
        {
        }

        /*
            <small>12:03:28 12-04-2014</small>
            <h4>Long established fact</h4>
            <p>The years, sometimes by accident, sometimes on purpose (injected humour and the like).</p>
            <h6>Por: Carlos Alberto dos Santos</h6>
            <a href="#"><i class="fa fa-trash-o "></i></a>
        */

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int MuralId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Título do PostIt")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(30, ErrorMessage = "Máximo de caractere permitido: 30")]
        [MinLength(5, ErrorMessage = "Mínimo de caractere permitido: 5")]
        public string Titulo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Aviso")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(135, ErrorMessage = "Máximo de caractere permitido: 135")]
        [MinLength(3, ErrorMessage = "Mínimo de caractere permitido: 3")]
        public string Aviso { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Autor é campo Obrigatório")]
        [MaxLength(28, ErrorMessage = "Máximo de caractere permitido: 28")]
        [MinLength(2, ErrorMessage = "Mínimo de caractere permitido: 2")]
        public string Autor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(300, ErrorMessage = "Máximo de caracter permitido: 300")]
        public string Email { get; set; }


    }
}
