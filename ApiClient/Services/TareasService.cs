using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Services
{
    public class TareasServices
    {
        private List<Tareas> tareas;
        private int contadorId;
        private string archivoTareas = "tareas.txt";

        public TareasServices()
        {
            tareas = new List<Tareas>();
            contadorId = 1;
            CargarTareasDeArchivo(archivoTareas);
        }
        //Crear una nueva tarea y añadirla al archivo de texto
        public void AgregarTarea(string descripcion)
        {
            var tarea = new Tareas(contadorId, descripcion);
            tareas.Add(tarea);
            contadorId++;
            GuardarTareasEnArchivo();
        }
        //Elimina una tarea del archivo de texto

        public void EliminarTarea(int id)
        {
            tareas.RemoveAll(t => t.Id == id);
            GuardarTareasEnArchivo();
        }
        //Marca como completa una tarea en el archivo de texto
        public void MarcarTareaCompleta(int id)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea != null)
            {
                tarea.MarcarCompleta();
                GuardarTareasEnArchivo();
            }
        }
        //Tres funciones para listar las tareas desde el archivo de texto

        public List<Tareas> ObtenerTareasPendientes()
        {
            return tareas.Where(t => !t.EstaCompleta).ToList();
        }

        public Tareas ObtenerTareaPorId(int id)
        {
            return tareas.FirstOrDefault(t => t.Id == id);
        }

        public List<Tareas> ObtenerTodasLasTareas()
        {
            return tareas;
        }
        //Funciones para acceder al archivo de texto
        #region ArchivoTexto
        private void GuardarTareasEnArchivo()
        {
            using (StreamWriter writer = new StreamWriter(archivoTareas))
            {
                foreach (var tarea in tareas)
                {
                    writer.WriteLine($"{tarea.Id}|{tarea.Descripcion}|{tarea.EstaCompleta}");
                }
            }
        }

        private void CargarTareasDeArchivo(string archivo)
        {
            if (File.Exists(archivo))
            {
                using (StreamReader reader = new StreamReader(archivoTareas))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        var partes = linea.Split('|');
                        var tarea = new Tareas(int.Parse(partes[0]), partes[1])
                        {
                            EstaCompleta = bool.Parse(partes[2])
                        };
                        tareas.Add(tarea);
                        contadorId = tarea.Id + 1;
                    }
                }
            }
        }
        #endregion
    }
}
