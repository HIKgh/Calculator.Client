using Calc;

namespace Calculator.Client.Services.CalculatorGrpc.Interfaces;

public interface IGrpcCalculatorClient
{
    public CalculationResult Addition(double operand1, double operand2);

    public CalculationResult Subtraction(double operand1, double operand2);

    public CalculationResult Multiplication(double operand1, double operand2);

    public CalculationResult Division(double operand1, double operand2);
}