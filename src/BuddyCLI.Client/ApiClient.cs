using System.Net;
using System.Text.Json;
using BuddyCLI.Client.Models;
using RestSharp;

namespace BuddyCLI.Client;

public class RestException(string content, HttpStatusCode code) : Exception
{
    public string Content { get; } = content;
    
    public HttpStatusCode Code { get; } = code;
}

public class ApiClient
{
    private readonly RestClient _client;
    
    private async Task<(T? Data, Error? Error)> Execute<T>(RestRequest request)
    {
        var resp = await _client.ExecuteAsync(request);
        if(resp.Content is null) throw new RestException(resp.ErrorMessage ?? "No message", resp.StatusCode);
        var expected = JsonSerializer.Deserialize<T>(resp.Content);
        if(expected is not null) return (expected, null);
        var error = JsonSerializer.Deserialize<Error>(resp.Content);
        return (default, error);
    }
    
    
}