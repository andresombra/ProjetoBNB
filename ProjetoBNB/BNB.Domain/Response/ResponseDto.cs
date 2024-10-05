using BNB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BNB.Domain.Response
{
    public class ResponseDto
    {

        public bool Status { get; set; }
        public object? Data { get; set; }
        public string? Mensagem { get; set; }
        
    }
}
