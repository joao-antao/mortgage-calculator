using mortgage_calculator.Domain;

namespace mortgage_calculator.Console;

internal sealed class MortgageCalculator(IStrategy strategy)
{
    internal double CalculateGrossMonthlyPayment(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        return strategy.GrossMonthlyCost(loanAmount, annualInterestRate, loanTermYears);
    }

    internal IEnumerable<Installment> CalculateGrossMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        return strategy.GrossMonthlyInstallments(loanAmount, annualInterestRate, loanTermYears);   
    }
}