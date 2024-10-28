using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient { BaseAddress = new Uri("https://localhost:7181") };
        var apiClient = new Client(client);

        string opcion;
        do
        {
            Console.WriteLine("1. Añadir Tarea");
            Console.WriteLine("2. Eliminar Tarea");
            Console.WriteLine("3. Marcar Tarea Completada");
            Console.WriteLine("4. Listar Tareas Pendientes");
            Console.WriteLine("5. Listar Todas las Tareas");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Descripción de la tarea: ");
                    var descripcion = Console.ReadLine();
                    await apiClient.AñadirTarea(descripcion);
                    break;
                case "2":
                    Console.Write("ID de la tarea a eliminar: ");
                    var idEliminar = int.Parse(Console.ReadLine());
                    await apiClient.EliminarTarea(idEliminar);
                    break;
                case "3":
                    Console.Write("ID de la tarea a marcar como completada: ");
                    var idCompletar = int.Parse(Console.ReadLine());
                    await apiClient.MarcarCompletada(idCompletar);
                    break;
                case "4":
                    var pendientes = await apiClient.ListarPendientes();
                    Console.WriteLine("Tareas Pendientes:");
                    foreach (var t in pendientes)
                    {
                        Console.WriteLine($"ID: {t.Id}, Descripción: {t.Descripcion}");
                    }
                    break;
                case "5":
                    var todas = await apiClient.ListarTodas();
                    Console.WriteLine("Todas las Tareas:");
                    foreach (var t in todas)
                    {
                        Console.WriteLine($"ID: {t.Id}, Descripción: {t.Descripcion}, Completada: {t.EstaCompleta}");
                    }
                    break;
            }
        } while (opcion != "6");
    }
}
