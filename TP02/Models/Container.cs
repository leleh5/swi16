using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP02.Models
{
    public class Container
    {
        [Key]
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }
    }
}