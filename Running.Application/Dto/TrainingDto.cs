using System;
using Running.Domain.Entities;

namespace Running.Application.Dto;

public class TrainingDto
{
    public int Id { get; set; }
    //public Guid UserId { get; set; }
    public DateTime TrainingDate { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string Description { get; set; }
    public IList<RunDto> Runs { get; set; }
    
}

