using System;
using System.Collections.Generic;
using System.Text;

namespace TPFinal.Desktop.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
        public string StatusFormatado { get => Status ? "Ativo" : "Inativo"; }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Senha} - {StatusFormatado}";
        }
    }
}
