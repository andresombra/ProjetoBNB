using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNB.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Endereco { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
    }
}
