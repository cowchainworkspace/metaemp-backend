using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Abstractions;

[Area("protected")]
[Route("/v{version:apiVersion}/protected/[controller]")]
public class ProtectedController : ApiController
{
    
}