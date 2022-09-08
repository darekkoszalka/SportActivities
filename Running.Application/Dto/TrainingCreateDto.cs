using System;
using Running.Domain.Entities;

namespace Running.Application.Dto;

public class TrainingCreateDto
{
    public Guid UserId { get; set; }
    public DateTime TrainingDate { get; set; }
    public string Description { get; set; }
    public IList<RunCreateDto> Runs { get; set; }
}

