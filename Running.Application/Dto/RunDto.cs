using System;
using Running.Domain.Entities;

namespace Running.Application.Dto;

public class RunDto
{
    public string TypeOfRunName { get; set; }
    public string TypeOfRunDescription { get; set; }
    public Decimal? Distance { get; set; }
    public TimeSpan? Time { get; set; }
    public string Description { get; set; }
    public int Pulse { get; set; }
    public int PulseMax { get; set; }
}

