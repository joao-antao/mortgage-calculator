namespace mortgage_calculator.Domain;

public interface IStrategy
{
    double GrossMonthlyCost(double loanAmount, double annualInterestRate, int loanTermYears);

    IEnumerable<Installment> GrossMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears);
}