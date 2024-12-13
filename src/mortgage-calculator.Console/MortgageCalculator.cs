using mortgage_calculator.Domain;

namespace mortgage_calculator.Console;

internal sealed class MortgageCalculator(IStrategy strategy)
{
    internal double CalculateMonthlyPayment(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        return strategy.CalculateMonthlyPayment(loanAmount, annualInterestRate, loanTermYears);
    }

    internal IEnumerable<Installment> CalculateMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        return strategy.CalculateMonthlyInstallments(loanAmount, annualInterestRate, loanTermYears);   
    }
}