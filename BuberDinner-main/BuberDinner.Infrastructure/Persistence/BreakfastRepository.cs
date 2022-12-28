using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class BreakfastRepository : IDinnerRepository
{
    private static readonly Dictionary<Guid, Dinner> _breakfasts = new();

    public void CreateDinner(Dinner breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public void DeleteDinner(Guid id)
    {
        _breakfasts.Remove(id);
    }

    public Dinner? GetDinnerById(Guid id)
    {
        return _breakfasts.TryGetValue(id, out var breakfast) ? breakfast : null;
    }

    public void UpsertDinner(Dinner breakfast)
    {
        _breakfasts[breakfast.Id] = breakfast;
    }
}