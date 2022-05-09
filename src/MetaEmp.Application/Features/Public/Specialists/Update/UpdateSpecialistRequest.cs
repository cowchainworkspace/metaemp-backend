﻿using System.Text.Json.Serialization;
using MediatR;
using MetaEmp.Data.SqlSever.Enums;

namespace MetaEmp.Application.Features.Public.Specialists.Update;

public record UpdateSpecialistRequest : IRequest<Unit>
{
    [JsonIgnore] 
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string? Title { get; set; }
    public string? UserStatus { get; set; }
    public string? About { get; set; }
    public string? ListOfSkillsJson { get; set; }
    
    public ApprovingStatus Status { get; set; }
    public string? RejectedReason { get; set; }
}