﻿using System.Text.Json.Serialization;
using MediatR;

namespace MetaEmp.Application.Features.Public.Companies.Vacancies.Update;

public record UpdateVacancyRequest([property: JsonIgnore] Guid Id,
    string Title,
    string[] Requirements,
    string Description) : IRequest;