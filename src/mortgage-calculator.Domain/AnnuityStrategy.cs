namespace mortgage_calculator.Domain;

/// <summary>
/// An annuity mortgage is a mortgage where the total monthly amount (consisting of interest and repayment) remains the same during the fixed-interest period.
/// </summary>
public sealed class AnnuityStrategy : IStrategy
{
    /// <summary>
    /// Calculates the indicative gross monthly costs using the following formula:
    /// M = P * (r * (1 + r)^n) / ((1 + r)^n - 1)
    /// M: The gross monthly cost (fixed monthly payment).
    /// P: The loan amount (or principal).
    /// r: The monthly interest rate (annual interest rate / 12)
    /// n: The total number of payments (loan term in years * 12)
    /// </summary>
    /// <param name="loanAmount">The total debt borrowed from the mortgage lender.</param>
    /// <param name="interestRate">The percentage fee charged on a mortgage loan by the mortgage lender.</param>
    /// <param name="loanTermYears">The duration in years to repay the loan.</param>
    /// <returns>The indicative gross monthly costs</returns>
    public decimal GrossMonthlyCost(decimal loanAmount, decimal interestRate, int loanTermYears)
    {
        int totalPayments = loanTermYears * 12;
        decimal monthlyInterestRate = (interestRate / 100) / 12;
        decimal power = 1;

        for (int i = 0; i < totalPayments; i++)
            power *= (1 + monthlyInterestRate);

        return loanAmount * (monthlyInterestRate * power) / (power - 1);
    }
    
    /// <summary>
    /// Calculates monthly installments for interest payment and principal payment. The first decreases over time because it is calculated on the remaining balance,
    /// the last increases over time as more of the fixed payment goes towards reducing the loan balance. 
    /// </summary>
    /// <param name="loanAmount">The total debt borrowed from the mortgage lender.</param>
    /// <param name="interestRate">The percentage fee charged on a mortgage loan by the mortgage lender.</param>
    /// <param name="loanTermYears">The duration in years to repay the loan.</param>
    /// <returns>The indicative monthly mortgage instalments</returns>
    public IEnumerable<Instalment> GrossMonthlyInstalments(decimal loanAmount, decimal interestRate, int loanTermYears)
    {
        int totalMonths = loanTermYears * 12;
        decimal monthlyInterestRate = (interestRate / 100) / 12;
        decimal monthlyPayment = GrossMonthlyCost(loanAmount, interestRate, loanTermYears);
        decimal principal = loanAmount;

        var instalments = new List<Instalment>(totalMonths);
        
        for (int month = 1; month <= totalMonths; month++)
        {
            decimal interest = principal * monthlyInterestRate;
            decimal repayment = monthlyPayment - interest;
            instalments.Add(new Instalment(month, principal, repayment, interest, monthlyPayment));
            principal -= repayment;
        }

        return instalments;
    }
}