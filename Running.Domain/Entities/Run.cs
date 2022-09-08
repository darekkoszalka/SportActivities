using Running.Domain.Common;

namespace Running.Domain.Entities;

public class Run : ActivityBase
{
    public int TypeOfRunId { get; set; }
    public TypeOfRun TypeOfRun { get; set; }
    public Decimal? Distance { get; set; }
    public TimeSpan? Time { get; set; }

}