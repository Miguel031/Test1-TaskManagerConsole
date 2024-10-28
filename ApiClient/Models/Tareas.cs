using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tareas
    {
        //Creacion de los atributos de la clase Tareas
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool EstaCompleta { get; set; }

        public Tareas(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
            EstaCompleta = false;
        }
        //Funcion que marca la tarea como completa, evitando acceder directamente a la variable EstaCompleta

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
