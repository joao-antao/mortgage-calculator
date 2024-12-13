using mortgage_calculator.Console;
using mortgage_calculator.Domain;

// Todo: Should the strategy define which interest rate to apply?
var calculator = new MortgageCalculator(new LinearStrategy());

var loanAmount = 698800;
var annualInterestRate = 4.03; // Let's assume this is the interest rate to a fixed-rate period of 20 years mortgage.
var loanTermYears = 30;

var monthlyPayment = calculator.CalculateMonthlyPayment(loanAmount, annualInterestRate, loanTermYears);
Console.WriteLine($"Indication of (gross) monthly costs: {monthlyPayment:F2}");

var installments = calculator.CalculateMonthlyInstallments(loanAmount, annualInterestRate, loanTermYears);
foreach (var installment in installments)
{
    Console.WriteLine($"Month {installment.Month}: Principal (start month) = {installment.Principal:F2}, Repayment = {installment.Repayment:F2}, Interest = {installment.Interest:F2}, Monthly payment (gross) = {installment.MonthlyPayment:F2}");
}