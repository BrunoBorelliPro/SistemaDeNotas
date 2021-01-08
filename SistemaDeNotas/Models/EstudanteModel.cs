using SistemaDeNotas.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeNotas
{
    public class EstudanteModel
    {
        [Key]
        public int IdEstudante { get; set; }
        public string Nome { get; set; }
        
    }
}
