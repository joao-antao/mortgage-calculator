namespace mortgage_calculator.Domain;

public sealed record Installment(int Month, double InterestPayment, double PrincipalRepayment, double RemainingBalance);