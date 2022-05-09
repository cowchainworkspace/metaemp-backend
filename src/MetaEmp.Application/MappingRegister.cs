using System.Text.Json;
using Mapster;
using MetaEmp.Application.Features.Public.Companies;
using MetaEmp.Application.Features.Public.Companies.Create;
using MetaEmp.Application.Features.Public.Companies.Update;
using MetaEmp.Application.Features.Public.Specialists;
using MetaEmp.Application.Features.Public.Specialists.Create;
using MetaEmp.Application.Features.Public.Users;
using MetaEmp.Core;
using MetaEmp.Data.SqlSever.Entities;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application;

internal class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        SpecialistMappings(config);
        
        config.NewConfig<AppUser, User>()
            .Map(m => m.Id, s => s.Id)
            .Map(m => m.Username, s => s.UserName);

        config.NewConfig<CreateCompanyRequest, Company>()
            .Map(c => c.Socials, cc => Serialize(cc.Socials));
        
        config.NewConfig<UpdateCompanyRequest, Company>()
            .Map(c => c.Socials, cc => Serialize(cc.Socials));

        config.NewConfig<Company, CompanyResult>()
            .Map(c => c.Socials, cr => Deserialize<Socials>(cr.Socials));
    }

    private static string Serialize<T>(T data) => JsonSerializer.Serialize(data, JsonConventions.CamelCase);
    private static T Deserialize<T>(string? data)
        => JsonSerializer.Deserialize<T>(data, JsonConventions.CamelCase);

    private void SpecialistMappings(TypeAdapterConfig config)
    {
        config.NewConfig<Specialist, SpecialistResult>()
            .Map(sr => sr.ListOfSkills, s => Deserialize<List<string>>(s.ListOfSkillsJson));

        config.NewConfig<CreateSpecialistRequest, Specialist>()
            .Map(s => s.ListOfSkillsJson, cs => Serialize(cs.ListOfSkills));
    }
}