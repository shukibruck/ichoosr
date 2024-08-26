using iChoosr.Domain.Abstract;
using iChoosr.Domain.Policies;
using Microsoft.Extensions.DependencyInjection;

namespace iChoosr.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDivisionStrategy, DivisibleByFive>();
            serviceCollection.AddScoped<IDivisionStrategy, DivisibleByThree>();
            serviceCollection.AddScoped<IDivisionStrategy, DivisibleByThreeAndFive>();

            return serviceCollection;
        }
    }
}