using System;
using System.Collections.Generic;

#nullable disable

namespace ExamenU3.Models
{
    public partial class Mascotum
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdTipo { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
    }
}
