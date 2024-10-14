namespace DotnetPractice.Core.Entities;

public class Team
{
    public Team(Guid id, string name)
    {
        if(id == Guid.Empty)
        {
            throw new Exception("Id cannot be null");
        }

        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
}