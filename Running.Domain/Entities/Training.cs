using System.Text;

namespace Running.Domain.Entities;

public class Training
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime TrainingDate { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string Description { get; set; }
    public IList<Run> Runs { get; set; }
}