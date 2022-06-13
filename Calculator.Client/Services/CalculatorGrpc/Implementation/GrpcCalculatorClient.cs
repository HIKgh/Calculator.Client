using Calc;
using Calculator.Client.Services.CalculatorGrpc.Interfaces;
using Grpc.Net.Client;

namespace Calculator.Client.Services.CalculatorGrpc.Implementation;

public class GrpcCalculatorClient : IGrpcCalculatorClient
{
    private readonly string _baseAddress;

    public GrpcCalculatorClient(string baseAddress)
    {
        _baseAddress = baseAddress;
    }

    public CalculationResult Addition(double operand1, double operand2)
    {
        try
        {
            using var channel = GrpcChannel.ForAddress(_baseAddress);
            var client = new GrpcCalculator.GrpcCalculatorClient(channel);
            return client.Addition(new ArithmeticCommandRequest { Operand1 = operand1, Operand2 = operand2 });
        }
        catch
        {
            throw new Exception("Addition error");
        }
    }

    public CalculationResult Subtraction(double operand1, double operand2)
    {
        try
        {
            using var channel = GrpcChannel.ForAddress(_baseAddress);
            var client = new GrpcCalculator.GrpcCalculatorClient(channel);
            return client.Subtraction(new ArithmeticCommandRequest { Operand1 = operand1, Operand2 = operand2 });
        }
        catch
        {
            throw new Exception("Subtraction error");
        }
    }

    public CalculationResult Multiplication(double operand1, double operand2)
    {
        try
        {
            using var channel = GrpcChannel.ForAddress(_baseAddress);
            var client = new GrpcCalculator.GrpcCalculatorClient(channel);
            return client.Multiplication(new ArithmeticCommandRequest { Operand1 = operand1, Operand2 = operand2 });
        }
        catch
        {
            throw new Exception("Multiplication error");
        }
    }

    public CalculationResult Division(double operand1, double operand2)
    {
        try
        {
            using var channel = GrpcChannel.ForAddress(_baseAddress);
            var client = new GrpcCalculator.GrpcCalculatorClient(channel);
            return client.Division(new ArithmeticCommandRequest { Operand1 = operand1, Operand2 = operand2 });
        }
        catch
        {
            throw new Exception("Division error");
        }
    }
}