using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Persistence;

public interface IDinnerRepository
{
    Dinner? GetDinnerById(Guid id);
    void CreateDinner(Dinner breakfast);
    void UpsertDinner(Dinner breakfast);
    void DeleteDinner(Guid id);
}