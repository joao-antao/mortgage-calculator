using mortgage_calculator.Domain;

namespace mortgage_calculator.Console;

internal sealed class MortgageCalculator(IStrategy strategy)
{
    internal decimal CalculateGrossMonthlyPayment(decimal loanAmount, decimal annualInterestRate, int loanTermYears)
    {
        return strategy.GrossMonthlyCost(loanAmount, annualInterestRate, loanTermYears);
    }

    internal IEnumerable<Instalment> CalculateGrossMonthlyInstalments(decimal loanAmount, decimal annualInterestRate, int loanTermYears)
    {
        return strategy.GrossMonthlyInstalments(loanAmount, annualInterestRate, loanTermYears);
    }
}