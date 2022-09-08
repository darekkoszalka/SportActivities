using System;
using Running.Domain.Entities;

namespace Running.Application.Dto;

public class TrainingUpdateDto
{
    public int Id { get; set; }
    public DateTime TrainingDate { get; set; }
    public string Description { get; set; }
    public IList<RunCreateDto> Runs { get; set; }
}

