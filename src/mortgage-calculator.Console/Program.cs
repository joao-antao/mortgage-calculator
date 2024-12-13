using mortgage_calculator;
using mortgage_calculator.Console;
using mortgage_calculator.Domain;

// Todo: Should the strategy define which interest rate to apply?
var calculator = new MortgageCalculator(new AnnuityStrategy());

var loanAmount = 294000;
var annualInterestRate = 2.51; // Let's assume this is the interest rate to a fixed-rate period of 20 years annuity mortgage.
var loanTermYears = 30;

var monthlyPayment = calculator.CalculateMonthlyPayment(loanAmount, annualInterestRate, loanTermYears);
Console.WriteLine($"Monthly payment: {monthlyPayment:F2}");

var installments = calculator.CalculateMonthlyInstallments(loanAmount, annualInterestRate, loanTermYears);
foreach (var installment in installments)
{
    Console.WriteLine($"Month {installment.Month}: Interest = {installment.InterestPayment:F2}, Principal = {installment.PrincipalRepayment:F2}, Remaining Balance = {installment.RemainingBalance:F2}");
}