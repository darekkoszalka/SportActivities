namespace Running.Domain.Entities;

public class TypeOfRun
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual IList<Run> Runs { get; set; }
}