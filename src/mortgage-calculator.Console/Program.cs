using mortgage_calculator.Console;
using mortgage_calculator.Domain;

var calculator = new MortgageCalculator(new LinearStrategy());

// Costs to consider in NL:
// Property transfer tax (overdrachtsbelasting) = 2%
// Valuation report (taxatierapport) = ~400 - ~800
// Transfer deed (overdrachtsakte) = ~800
// Mortgage deed (hypotheekakte) = ~600

var loanAmount = 216000;
var annualInterestRate = 4; // Let's assume this is the interest rate to a fixed-rate period of 20 years mortgage.
var loanTermYears = 30;

var monthlyPayment = calculator.CalculateGrossMonthlyPayment(loanAmount, annualInterestRate, loanTermYears);
Console.WriteLine($"Indication of (gross) monthly cost is: {monthlyPayment:F2}");

var installments = calculator.CalculateGrossMonthlyInstallments(loanAmount, annualInterestRate, loanTermYears);
foreach (var installment in installments)
{
    Console.WriteLine($"Month {installment.Month}: Principal (start month) = {installment.Principal:F2}, Repayment = {installment.Repayment:F2}, Interest = {installment.Interest:F2}, Monthly payment (gross) = {installment.MonthlyPayment:F2}");
}