namespace mortgage_calculator.Domain;

public interface IStrategy
{
    decimal GrossMonthlyCost(decimal loanAmount, decimal interestRate, int loanTermYears);
    
    IEnumerable<Instalment> GrossMonthlyInstalments(decimal loanAmount, decimal interestRate, int loanTermYears);
}