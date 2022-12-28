namespace BuberDinner.Contracts.Dinner;

public record UpsertDinnerRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet);