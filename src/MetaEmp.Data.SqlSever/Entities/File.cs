using MetaEmp.Core.Abstractions.Entities;

namespace MetaEmp.Data.SqlSever.Entities;

public class File : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public byte[] Bytes { get; set; }
    public string MimeType { get; set; }
}