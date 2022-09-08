using System;
using Running.Domain.Entities;

namespace Running.Application.Dto;

public class RunCreateDto
{
    public int TrainingId { get; set; }
    public int TypeOfRunId { get; set; }
    public Decimal? Distance { get; set; }
    public TimeSpan? Time { get; set; }
    public string Description { get; set; }
    public int Pulse { get; set; }
    public int PulseMax { get; set; }
}

