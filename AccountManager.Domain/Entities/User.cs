using System;
using AccountManager.Domain.Common;

namespace AccountManager.Domain.Entities;

public class User : AuditEntity
{
    public Guid Id { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}

