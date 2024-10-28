using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tareas
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool EstaCompleta { get; set; }

        public Tareas(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
            EstaCompleta = false;
        }

        public void MarcarCompleta()
        {
            EstaCompleta = true;
        }

        public override string ToString()
        {
            return $"{Id}: {Descripcion} (Completa: {EstaCompleta})";
        }
    }

}
