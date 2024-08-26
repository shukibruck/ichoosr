using iChoosr.Domain.Abstract;

namespace iChoosr.Domain.Policies;

public sealed class DivisibleByFive : IDivisionStrategy
{
    public bool IsDivisible(int number) => number % 5 == 0;
}