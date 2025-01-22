namespace mortgage_calculator.Domain;

public sealed record Instalment(int Month, decimal Principal, decimal Repayment, decimal Interest, decimal MonthlyPayment);
