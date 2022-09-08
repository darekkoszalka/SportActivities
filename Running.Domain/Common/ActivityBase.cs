using System;
using Running.Domain.Entities;

namespace Running.Domain.Common;

public abstract class ActivityBase
{
    public int Id { get; set; }
    public int TrainingId { get; set; }
    public Training Training { get; set; }
    public string Description { get; set; }
    public int Pulse { get; set; }
    public int PulseMax { get; set; }
}

