using Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class Client
{
    private readonly HttpClient client;

    public Client(HttpClient client)
    {
        this.client = client;
    }

    public async Task AñadirTarea(string descripcion)
    {
        var tarea = new { Descripcion = descripcion };
        var response = await client.PostAsJsonAsync("/api/tareas", tarea);
        response.EnsureSuccessStatusCode();
    }

    public async Task EliminarTarea(int id)
    {
        var response = await client.DeleteAsync($"/api/tareas/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task MarcarCompletada(int id)
    {
        var response = await client.PutAsync($"/api/tareas/{id}", null);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<Tareas>> ListarPendientes()
    {
        return await client.GetFromJsonAsync<List<Tareas>>("/api/tareas/pendientes");
    }

    public async Task<List<Tareas>> ListarTodas()
    {
        return await client.GetFromJsonAsync<List<Tareas>>("/api/tareas");
    }

    public async Task<Tareas> ObtenerTareaPorId(int id)
    {
        return await client.GetFromJsonAsync<Tareas>($"/api/tareas/{id}");
    }
}
