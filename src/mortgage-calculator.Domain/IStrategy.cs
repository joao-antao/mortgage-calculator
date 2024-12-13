namespace mortgage_calculator.Domain;

public interface IStrategy
{
    double CalculateMonthlyPayment(double loanAmount, double annualInterestRate, int loanTermYears);

    IEnumerable<Installment> CalculateMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears);
}