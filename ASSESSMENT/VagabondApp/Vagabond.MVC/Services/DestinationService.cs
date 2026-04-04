using System.Text.Json;
using Vagabond.MVC.Models;

namespace Vagabond.MVC.Services;

public class DestinationService : IDestinationService
{
    private readonly HttpClient _httpClient;

    public DestinationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<DestinationViewModel>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/destinations");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<IEnumerable<DestinationViewModel>>(json, options)
               ?? Enumerable.Empty<DestinationViewModel>();
    }
}