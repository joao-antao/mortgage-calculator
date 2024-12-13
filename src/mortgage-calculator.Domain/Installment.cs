namespace mortgage_calculator.Domain;

public sealed record Installment(int Month, double Principal, double Repayment, double Interest, double MonthlyPayment);