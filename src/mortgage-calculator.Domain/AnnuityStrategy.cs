namespace mortgage_calculator.Domain;

/// <summary>
/// An annuity mortgage is a mortgage where the total monthly amount (consisting of interest and repayment) remains the same during the fixed-interest period.
/// </summary>
public sealed class AnnuityStrategy : IStrategy
{
    /// <summary>
    /// Calculates the monthly payment using the following formula:
    /// P = (r * PV) / (1 - (1 + r) ^ -n)
    /// P: Total monthly payment (same every month).
    /// r: Monthly interest rate (annual interest rate divided by 12).
    /// PV: Loan principal (amount borrowed).
    /// n: Total number of payments.
    /// </summary>
    /// <param name="loanAmount"></param>
    /// <param name="annualInterestRate">The percentage fee charged on a mortgage loan by a lender.</param>
    /// <param name="loanTermYears">The fixed-rate term is the agreed period (years) during which the interest rate remains the same.</param>
    /// <returns></returns>
    public double CalculateMonthlyPayment(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyInterestRate = (annualInterestRate / 100) / 12;
        int totalPayments = loanTermYears * 12;
        return (monthlyInterestRate * loanAmount) / (1 - Math.Pow(1 + monthlyInterestRate, -totalPayments));
    }
    
    /// <summary>
    /// Calculates monthly installments for interest payment and principal repayment. The first decreases over time because it is calculated on the remaining balance,
    /// the last increases over time as more of the fixed payment goes towards reducing the loan balance. 
    /// </summary>
    /// <param name="loanAmount"></param>
    /// <param name="annualInterestRate"></param>
    /// <param name="loanTermYears"></param>
    public IEnumerable<Installment> CalculateMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyInterestRate = (annualInterestRate / 100) / 12;
        double monthlyPayment = CalculateMonthlyPayment(loanAmount, annualInterestRate, loanTermYears);
        double remainingBalance = loanAmount;
        int numberPayments = loanTermYears * 12;

        var result = new List<Installment>(numberPayments);
        
        for (int month = 1; month <= numberPayments; month++)
        {
            double interestPayment = monthlyInterestRate * remainingBalance; // The interest on the remaining loan balance for that month.
            double principalRepayment = monthlyPayment - interestPayment; // The portion of the payment that reduces the loan principal.
            remainingBalance -= principalRepayment;
            result.Add(new Installment(month, interestPayment, principalRepayment, remainingBalance));
        }

        return result;
    }
}