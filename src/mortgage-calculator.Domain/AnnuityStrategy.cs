﻿namespace mortgage_calculator.Domain;

/// <summary>
/// An annuity mortgage is a mortgage where the total monthly amount (consisting of interest and repayment) remains the same during the fixed-interest period.
/// </summary>
public sealed class AnnuityStrategy : IStrategy
{
    /// <summary>
    /// Calculates the indicative gross monthly costs using the following formula:
    /// P = (r * PV) / (1 - (1 + r) ^ -n)
    /// P: Total monthly payment (same every month).
    /// r: Monthly interest rate (annual interest rate divided by 12).
    /// PV: Loan principal (amount borrowed).
    /// n: Total number of payments.
    /// </summary>
    /// <param name="loanAmount">The total debt borrowed from a financial institution.</param>
    /// <param name="annualInterestRate">The percentage fee charged on a mortgage loan by a financial institution.</param>
    /// <param name="loanTermYears">The duration in years to repay the loan.</param>
    /// <returns></returns>
    public double GrossMonthlyCost(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        double monthlyInterestRate = (annualInterestRate / 100) / 12;
        int totalPayments = loanTermYears * 12;
        return (monthlyInterestRate * loanAmount) / (1 - Math.Pow(1 + monthlyInterestRate, -totalPayments));
    }
    
    /// <summary>
    /// Calculates monthly installments for interest payment and principal payment. The first decreases over time because it is calculated on the remaining balance,
    /// the last increases over time as more of the fixed payment goes towards reducing the loan balance. 
    /// </summary>
    /// <param name="loanAmount">The total debt borrowed from a financial institution.</param>
    /// <param name="annualInterestRate">The percentage fee charged on a mortgage loan by a financial institution.</param>
    /// <param name="loanTermYears">The duration in years to repay the loan.</param>
    public IEnumerable<Installment> GrossMonthlyInstallments(double loanAmount, double annualInterestRate, int loanTermYears)
    {
        int totalMonths = loanTermYears * 12;
        double monthlyInterestRate = (annualInterestRate / 100) / 12;
        double monthlyPayment = GrossMonthlyCost(loanAmount, annualInterestRate, loanTermYears);
        double principal = loanAmount;

        var result = new List<Installment>(totalMonths);
        
        for (int month = 1; month <= totalMonths; month++)
        {
            double interest = principal * monthlyInterestRate;
            double repayment = monthlyPayment - interest;
            result.Add(new Installment(month, principal, repayment, interest, monthlyPayment));
            principal -= repayment;
        }

        return result;
    }
}