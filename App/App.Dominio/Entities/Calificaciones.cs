using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Dominio.Entities
{
    public class Calificaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCalificacion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public decimal Nota { get; set; }
        
    }
}
