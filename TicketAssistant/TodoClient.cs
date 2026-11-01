using System.Net.Http.Json;

namespace TicketAssistant;

internal class TodoClient
{
    private readonly HttpClient _httpClient = new HttpClient();

    public async Task<Todo?> GetTodoAsync(int id)
    {
        HttpResponseMessage todoResponse = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/todos/{id}");

        if (!todoResponse.IsSuccessStatusCode)
        {
            return null;
        }

        Todo? todo = await todoResponse.Content.ReadFromJsonAsync<Todo>();
        return todo;
    }
}
