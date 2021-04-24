using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial2_DiegoDuran.Models
{
    public class Friends
    {
        [Key]
        public int FriendID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Ingrese su nombre con un maximo de 30 caracteres y 3 minimo")]
        public string Name { get; set; }

        public string NickName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
    }
}