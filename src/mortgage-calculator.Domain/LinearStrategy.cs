namespace mortgage_calculator.Domain;

/// <summary>
/// A linear mortgage is a mortgage where you pay off the same amount each month over the term. The interest rate is highest at the beginning and decreases over the term. So you start with a high monthly amount
/// </summary>
internal sealed class LinearStrategy : IStrategy
{
    public double CalculateMonthlyPayment(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Installment> CalculateMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        throw new NotImplementedException();
    }
}