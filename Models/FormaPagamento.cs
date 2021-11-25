using System;
using System.Collections.Generic;

namespace server.Models
{
    public class FormaPagamento
    {
        public FormaPagamento() => CriadoEm = DateTime.Now;

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Simbolo { get; set; }
        public DateTime CriadoEm { get; set; }

        public override string ToString() =>
            $"Descicao: {Descricao} | Simbolo: {Simbolo} | CriadoEm: {CriadoEm}";

    }
}