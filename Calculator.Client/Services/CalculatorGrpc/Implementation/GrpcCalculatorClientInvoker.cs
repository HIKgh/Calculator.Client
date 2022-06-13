using Calc;
using Calculator.Client.Services.CalculatorGrpc.Interfaces;

namespace Calculator.Client.Services.CalculatorGrpc.Implementation;

public class GrpcCalculatorClientInvoker : IGrpcCalculatorClientInvoker
{
    private readonly double _operand1;

    private readonly double _operand2;

    private readonly IGrpcCalculatorClient _client;

    public GrpcCalculatorClientInvoker(double operand1, double operand2, string baseAddress)
    {
        _operand1 = operand1;
        _operand2 = operand2;
        _client = new GrpcCalculatorClient(baseAddress);
    }

    public void Invoke()
    {
        try
        {
            Console.WriteLine("gRPC API Calculator demo:");
            var calculationResult = _client.Addition(_operand1, _operand2);
            WriteLineResult(calculationResult, "Addition");
            calculationResult = _client.Subtraction(_operand1, _operand2);
            WriteLineResult(calculationResult, "Subtraction");
            calculationResult = _client.Multiplication(_operand1, _operand2);
            WriteLineResult(calculationResult, "Multiplication");
            calculationResult = _client.Division(_operand1, _operand2);
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