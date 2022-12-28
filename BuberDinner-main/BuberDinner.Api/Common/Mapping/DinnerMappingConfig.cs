using BuberDinner.Application.Lunch.Common;
using BuberDinner.Contracts.Dinner;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class DinnerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DinnerResult, DinnerResponse>();
    }
}