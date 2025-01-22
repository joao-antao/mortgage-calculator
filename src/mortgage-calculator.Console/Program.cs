using mortgage_calculator.Console;
using mortgage_calculator.Domain;

var calculator = new MortgageCalculator(new LinearStrategy());

const decimal loanAmount = 216000;
const decimal annualInterestRate = 4m;
const int loanTermYears = 30;

var monthlyPayment = calculator.CalculateGrossMonthlyPayment(loanAmount, annualInterestRate, loanTermYears);
Console.WriteLine($"Indication of (gross) monthly cost is: {monthlyPayment:F2}");

var installments = calculator.CalculateGrossMonthlyInstalments(loanAmount, annualInterestRate, loanTermYears);
foreach (var installment in installments)
{
    Console.WriteLine($"Month {installment.Month}: Principal (start month) = {installment.Principal:F2}, Repayment = {installment.Repayment:F2}, Interest = {installment.Interest:F2}, Monthly payment (gross) = {installment.MonthlyPayment:F2}");
}