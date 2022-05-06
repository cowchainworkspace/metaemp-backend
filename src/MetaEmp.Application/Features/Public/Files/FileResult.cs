namespace MetaEmp.Application.Features.Public.Files;

public class FileResult
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte[] Bytes { get; set; }
    public string MimeType { get; set; }
}