using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP02.Models
{
    public class BL
    {
        [Key]
        public int Numero { get; set; }
        public string Consignee { get; set; }
        public string Navio { get; set; }
    }
}