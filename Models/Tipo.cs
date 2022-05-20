using System;
using System.Collections.Generic;

#nullable disable

namespace ExamenU3.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Mascota = new HashSet<Mascotum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Mascotum> Mascota { get; set; }
    }
}
