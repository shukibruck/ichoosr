using iChoosr.Domain.Abstract;

namespace iChoosr.Domain.Policies;

public sealed class DivisibleByThree : IDivisionStrategy
{
    public bool IsDivisible(int number) => number % 3 == 0;
}