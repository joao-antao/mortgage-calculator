namespace mortgage_calculator.Domain;

/// <summary>
/// A linear mortgage is a mortgage where you pay off the same amount each month over the term. The interest rate is highest at the beginning and decreases over the term. So you start with a high monthly amount
/// </summary>
public sealed class LinearStrategy : IStrategy
{
    public double CalculateMonthlyPayment(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        int totalMonths = loanTermYears * 12;
        var monthlyInterestRate = (annualInterestRate / 100) / 12;
        var repayment = loanAmount / totalMonths;
        double interestRepaymentFirstMonth  = loanAmount * monthlyInterestRate;
        return repayment + interestRepaymentFirstMonth ;
    }

    public IEnumerable<Installment> CalculateMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        int totalMonths = loanTermYears * 12;
        double monthlyInterestRate = (annualInterestRate / 100) / 12;
        double repayment = loanAmount / totalMonths;
        double principal = loanAmount;
        
        var result = new List<Installment>(totalMonths);
      
        for (int month = 1; month <= totalMonths; month++)
        {
            double interest = principal * monthlyInterestRate;
            double monthlyPayment = repayment + interest;
            result.Add(new Installment(month, principal, repayment , interest, monthlyPayment));
            principal -= repayment;
        }

        return result;
    }
}