using System;
namespace AccountManager.Domain.Common;

public abstract class AuditEntity
{
    public DateTime RegisterDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
}

