using System.Net;
using System.Text.Json;
using Calculator.Client.Services.Calculator.Interfaces;
using Calculator.Client.Services.Calculator.Models;

namespace Calculator.Client.Services.Calculator.Implementation;

public class CalculatorClient : ICalculatorClient
{
    private const string AddUri = "api/calculations/{0}/{1}/addition";

    private const string SubUri = "api/calculations/{0}/{1}/subtraction";

    private const string MulUri = "api/calculations/{0}/{1}/multiplication";

    private const string DivUri = "api/calculations/{0}/{1}/division";

    private readonly JsonSerializerOptions _options;

    private readonly HttpClient _client;

    public CalculatorClient(string baseAddress)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(baseAddress)
        };
        _options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    private async Task<CalculationResult> GetCommand(double operand1, double operand2, string uri)
    {
        var response = await _client.GetAsync(string.Format(uri, operand1, operand2));
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var stringContent = await response.Content.ReadAsStringAsync();
            var content = JsonSerializer.Deserialize<CalculationResult>(stringContent, _options);

            if (content != null)
            {
                return content;
            }
        }
        throw new Exception();
    }

    public async Task<CalculationResult> Addition(double operand1, double operand2)
    {
        try
        {
            return await GetCommand(operand1, operand2, AddUri);
        }
        catch
        {
            throw new Exception("Addition error");
        }
    }

    public async Task<CalculationResult> Subtraction(double operand1, double operand2)
    {
        try
        {
            return await GetCommand(operand1, operand2, SubUri);
        }
        catch
        {
            throw new Exception("Subtraction error");
        }
    }

    public async Task<CalculationResult> Multiplication(double operand1, double operand2)
    {
        try
        {
            return await GetCommand(operand1, operand2, MulUri);
        }
        catch
        {
            throw new Exception("Multiplication error");
        }
    }

    public async Task<CalculationResult> Division(double operand1, double operand2)
    {
        try
        {
            return await GetCommand(operand1, operand2, DivUri);
        }
        catch
        {
            throw new Exception("Division error");
        }
    }
}