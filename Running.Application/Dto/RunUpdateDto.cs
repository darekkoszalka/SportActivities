using System;
namespace Running.Application.Dto;

public class RunUpdateDto
{
    //public int Id { get; set; }
    public int TypeOfRunId { get; set; }
    public Decimal? Distance { get; set; }
    public TimeSpan? Time { get; set; }
    public string Description { get; set; }
    public int Pulse { get; set; }
    public int PulseMax { get; set; }
}

