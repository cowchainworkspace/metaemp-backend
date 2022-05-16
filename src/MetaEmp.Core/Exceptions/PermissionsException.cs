namespace MetaEmp.Core.Exceptions;

public class PermissionsException : ForbidException
{
    public PermissionsException() : base("You have no permissions to do this")
    {
    }
}