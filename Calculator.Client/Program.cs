using Calculator.Client.Services.Calculator.Implementation;
using Calculator.Client.Services.Calculator.Interfaces;
using Calculator.Client.Services.CalculatorGrpc.Implementation;
using Calculator.Client.Services.CalculatorGrpc.Interfaces;

namespace Calculator.Client;

public class Program
{
    private const double Operand1 = 14;

    private const double Operand2 = 7;

    private const string DockerArg = "-docker";

    private const string RestApiBaseAddress = "http://localhost:5074/";

    private const string GrpcApiBaseAddress = "http://localhost:5123/";

    private const string DockerRestApiBaseAddress = "http://localhost:49154/";

    private const string DockerGrpcApiBaseAddress = "http://localhost:49153/";

    private static ICalculatorClientInvoker _calculatorClientInvoker = null!;

    private static IGrpcCalculatorClientInvoker _grpcCalculatorClientInvoker = null!;

    private static async Task Main(string[] args)
    {
        if (args.Contains(DockerArg))
        {
            await InvokeRestApiCalculatorClient(DockerRestApiBaseAddress);
            InvokeGrpcApiCalculatorClient(DockerGrpcApiBaseAddress);
        }
        else
        {
            await InvokeRestApiCalculatorClient(RestApiBaseAddress);
            InvokeGrpcApiCalculatorClient(GrpcApiBaseAddress);
        }
    }

    private static async Task InvokeRestApiCalculatorClient(string baseAddress)
    {
       _calculatorClientInvoker = new CalculatorClientInvoker(Operand1, Operand2, baseAddress);
       await _calculatorClientInvoker.Invoke();
    }

    private static void InvokeGrpcApiCalculatorClient(string baseAddress)
    {
        _grpcCalculatorClientInvoker = new GrpcCalculatorClientInvoker(Operand1, Operand2, baseAddress);
        _grpcCalculatorClientInvoker.Invoke();
    }
}