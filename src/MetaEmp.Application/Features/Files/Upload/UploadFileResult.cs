namespace MetaEmp.Application.Features.Files.Upload;

public class UploadFileResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string MimeType { get; set; }
    public FileTarget Target { get; set; }
    public Guid TargetId { get; set; }
}