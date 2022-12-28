namespace BuberDinner.Domain.Entities;

public class Dinner
{
    public Guid Id {get;}
    public string Name {get; private set;}
    public string Description {get; private set;}
    public DateTime StartDateTime {get; private set;}
    public DateTime EndDateTime {get; private set;}
    public DateTime LastModifiedDateTime {get; private set;}
    public List<string> Savory {get; private set;}
    public List<string> Sweet {get; private set;}

    public Dinner(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime lastModifiedDateTime,
        List<string> savory,
        List<string> sweet)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }

    public void Update(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        List<string> savory,
        List<string> sweet)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = DateTime.UtcNow;
        Savory = savory;
        Sweet = sweet;
    }
}