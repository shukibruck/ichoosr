using iChoosr.Domain.Abstract;

namespace iChoosr.Domain.Policies;

public sealed class DivisibleByThreeAndFive : IDivisionStrategy
{
    public bool IsDivisible(int number) => number % 3 == 0 && number % 5 == 0;
}