﻿using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Public.Courses;
using MetaEmp.Application.Features.Public.Courses.All;
using MetaEmp.Application.Features.Public.Courses.Create;
using MetaEmp.Application.Features.Public.Courses.Delete;
using MetaEmp.Application.Features.Public.Courses.One;
using MetaEmp.Application.Features.Public.Courses.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Areas.Public.Controllers;

[AllowAnonymous]
public class CoursesController : ApiController
{
    [HttpGet]
    public async Task<CourseResult[]> GetAll()
        => await Mediator.Send(new GetCoursesRequest());

    [HttpGet("{id}")]
    public async Task<CourseResult> GetOne([FromRoute] Guid id)
        => await Mediator.Send(new GetCourseRequest(id));

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCourseRequest request)
    {
        var result = await Mediator.Send(request);
        return Created($"/v1/Course/{result.Id}", result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCourseRequest request)
    {
        await Mediator.Send(request with {Id = id});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteCourseRequest(id));
        return NoContent();
    }
}