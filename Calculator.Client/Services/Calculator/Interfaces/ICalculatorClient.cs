using Calculator.Client.Services.Calculator.Models;

namespace Calculator.Client.Services.Calculator.Interfaces;

public interface ICalculatorClient
{
    public Task<CalculationResult> Addition(double operand1, double operand2);
    
    public Task<CalculationResult> Subtraction(double operand1, double operand2);

    public Task<CalculationResult> Multiplication(double operand1, double operand2);

    public Task<CalculationResult> Division(double operand1, double operand2);
}