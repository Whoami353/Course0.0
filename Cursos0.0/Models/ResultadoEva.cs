//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cursos0._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResultadoEva
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public string Valoracion { get; set; }
        public int EstudianteId { get; set; }
    
        public virtual Evaluacion Evaluacion { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
