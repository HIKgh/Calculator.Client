using Calculator.Client.Services.Calculator.Interfaces;
using Calculator.Client.Services.Calculator.Models;

namespace Calculator.Client.Services.Calculator.Implementation;

public class CalculatorClientInvoker : ICalculatorClientInvoker
{
    private readonly double _operand1;
    
    private readonly double _operand2;

    private readonly ICalculatorClient _client;

    public CalculatorClientInvoker(double operand1, double operand2, string baseAddress)
    {
        _operand1 = operand1;
        _operand2 = operand2;
        _client = new CalculatorClient(baseAddress);
    }

    public async Task Invoke()
    {
        try
        {
            Console.WriteLine("Rest API Calculator demo:");
            var calculationResult = await _client.Addition(_operand1, _operand2);
            WriteLineResult(calculationResult, "Addition");
            calculationResult = await _client.Subtraction(_operand1, _operand2);
            WriteLineResult(calculationResult, "Subtraction");
            calculationResult = await _client.Multiplication(_operand1, _operand2);
            WriteLineResult(calculationResult, "Multiplication");
            calculationResult = await _client.Division(_operand1, _operand2);
            WriteLineResult(calculationResult, "Division");
            Console.WriteLine("Press any key ...\n");
            Console.ReadKey();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void WriteLineResult(CalculationResult result, string command)
    {
        Console.WriteLine($"{command}/{_operand1}/{_operand2} Result: {result.Result}");
    }
}