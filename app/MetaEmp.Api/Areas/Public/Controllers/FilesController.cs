using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Public.Files;
using MetaEmp.Application.Features.Public.Files.Delete;
using MetaEmp.Application.Features.Public.Files.Get;
using MetaEmp.Application.Features.Public.Files.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FileResult = Microsoft.AspNetCore.Mvc.FileResult;

namespace MetaEmp.Api.Areas.Public.Controllers;

public class FilesController : ApiController
{
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<FileResult> GetFile([FromRoute] Guid id, CancellationToken cancel)
    {
        var result = await Mediator.Send(new GetFileRequest(id), cancel);
        return new FileContentResult(result.Bytes, result.MimeType);
    }

    [HttpPost("{targetId:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<UploadFileResult>> UploadFile(IFormFile file, [FromQuery] FileTarget target,
        [FromRoute] Guid targetId,
        CancellationToken cancel)
    {
        var result = await Mediator.Send(new UploadFileRequest(file, target, targetId), cancel);
        return CreatedAtAction(nameof(GetFile), new { id = result.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    public async Task<ActionResult<DeleteFileResult>> GetFile([FromRoute] Guid id)
    {
        await Mediator.Send(new DeleteFileRequest(id));
        return NoContent();
    }
}