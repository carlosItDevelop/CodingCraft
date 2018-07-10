using System;
using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade
{
    public class Mural
    {
        /*
                            <small>12:03:28 12-04-2014</small>
                            <h4>Long established fact</h4>
                            <p>The years, sometimes by accident, sometimes on purpose (injected humour and the like).</p>
                            <h6>Por: Carlos Alberto dos Santos</h6>
                            <a href="#"><i class="fa fa-trash-o "></i></a>
         */

        /// <summary>
        /// Esse construtor é próprio para o Credenciamento
        /// onde Data e Aviso não têm EditorFor. No caso da
        /// gravação de outros avisos no painel do Mural, os
        /// campos Data e Aviso são obrigatórios, caso contrário
        /// ao do E-Mail, que só é obrigatório em Credencial!
        /// </summary>
        public Mural()
        {
            this.Data = DateTime.Now;

            if (string.IsNullOrEmpty(this.Aviso))
            {
                this.Aviso = "Solicitação de Credenciamento ao Sistema, para o E-Mail:\n ";
            }
        }

        [Key]
        public int MuralId { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Data Inválida!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Display(Name = "Título do PostIt")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(30, ErrorMessage = "Máximo de caractere permitido: 30")]
        [MinLength(5, ErrorMessage = "Mínimo de caractere permitido: 5")]
        public string Titulo { get; set; }


        [Display(Name = "Aviso")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(335, ErrorMessage = "Máximo de caractere permitido: 335")]
        [MinLength(3, ErrorMessage = "Mínimo de caractere permitido: 3")]
        public string Aviso { get; set; }


        [Required(ErrorMessage = "Autor é campo Obrigatório")]
        [MaxLength(28, ErrorMessage = "Máximo de caractere permitido: 28")]
        [MinLength(2, ErrorMessage = "Mínimo de caractere permitido: 2")]
        public string Autor { get; set; }


        [MaxLength(200, ErrorMessage = "Máximo de caracter permitido: 200")]
        public string Email { get; set; }

        // Implementar algo parecido com isso!
        //IdentityUser usuario = new IdentityUser();
        //public Mural()
        //{
        //    this.Autor = usuario.Email;
        //}


    }
}
