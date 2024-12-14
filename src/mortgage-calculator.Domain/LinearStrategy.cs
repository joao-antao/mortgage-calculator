namespace mortgage_calculator.Domain;

/// <summary>
/// A linear mortgage is a mortgage where you pay off the same amount each month over the term. The interest rate is highest at the beginning and decreases over the term.
/// </summary>
public sealed class LinearStrategy : IStrategy
{
    /// <summary>
    /// To calculate the gross monthly cost for a linear mortgage, we need to consider the principal loan amount, the interest rate, and the loan term (the number of years one will be paying the mortgage). The gross monthly cost consists of both the interest and principal repayment, and it changes over time with a linear mortgage. A linear mortgage means that the principal repayment is constant every month, and only the interest portion decreases as the principal is paid down.
    /// Step 1 - Calculate the monthly principal repayment:
    /// > Monthly principal repayment = Loan amount / Loan term (in months)
    /// Step 2 - Calculate the interest repayment in the first month:
    /// > Interest repayment = Loan amount * Annual interest rate / 12
    /// Step 3 - Calculate gross monthly cost in the first month:
    /// > Gross monthly cost = Monthly principal repayment + monthly interest repayment
    /// </summary>
    /// <param name="loanAmount">The total debt borrowed from a financial institution.</param>
    /// <param name="annualInterestRate">The percentage fee charged on a mortgage loan by a financial institution.</param>
    /// <param name="loanTermYears">The duration in years to repay the loan.</param>
    /// <returns></returns>
    public double GrossMonthlyCost(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        int totalMonths = loanTermYears * 12;
        var monthlyPrincipalRepayment = loanAmount / totalMonths;
        var monthlyInterestRate = (annualInterestRate / 100) / 12;
        double monthlyInterestRepayment  = loanAmount * monthlyInterestRate;
        return monthlyPrincipalRepayment + monthlyInterestRepayment;
    }

    /// <summary>
    /// Calculate the monthly costs over the total loan term.
    /// </summary>
    /// <param name="loanAmount">The total debt borrowed from a financial institution.</param>
    /// <param name="annualInterestRate">The percentage fee charged on a mortgage loan by a financial institution.</param>
    /// <param name="loanTermYears">The duration in years to repay the loan.</param>
    /// <returns></returns>
    public IEnumerable<Installment> GrossMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        var totalMonths = loanTermYears * 12;
        var monthlyInterestRate = (annualInterestRate / 100) / 12;
        var monthlyPrincipalRepayment = loanAmount / totalMonths;
        var principal = loanAmount;
        
        var result = new List<Installment>(totalMonths);
      
        for (var month = 1; month <= totalMonths; month++)
        {
            var monthlyInterestRepayment = principal * monthlyInterestRate;
            var monthlyPayment = monthlyPrincipalRepayment + monthlyInterestRepayment;
            result.Add(new Installment(month, principal, monthlyPrincipalRepayment, monthlyInterestRepayment, monthlyPayment));
            principal -= monthlyPrincipalRepayment;
        }

        return result;
    }
}