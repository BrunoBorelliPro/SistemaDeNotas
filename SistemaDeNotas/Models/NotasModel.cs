using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas.Models
{
    public class NotasModel
    {
        [Key]
        public int NotaId { get; set; }
        public double Nota { get; set; }
        public int IdEstudante { get; set; }
    }
}
