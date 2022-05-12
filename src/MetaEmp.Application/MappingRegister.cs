using System.Text.Json;
using Mapster;
using MetaEmp.Application.Features.Public.Companies;
using MetaEmp.Application.Features.Public.Companies.Create;
using MetaEmp.Application.Features.Public.Companies.Update;
using MetaEmp.Application.Features.Public.Courses;
using MetaEmp.Application.Features.Public.Courses.Create;
using MetaEmp.Application.Features.Public.Courses.Update;
using MetaEmp.Application.Features.Public.Specialists;
using MetaEmp.Application.Features.Public.Specialists.Create;
using MetaEmp.Application.Features.Public.Specialists.Update;
using MetaEmp.Application.Features.Public.Users;
using MetaEmp.Core;
using MetaEmp.Data.SqlSever.Entities;
using MetaEmp.Data.SqlSever.Entities.CompanyEntities;
using MetaEmp.Data.SqlSever.Entities.EducationEntities;
using MetaEmp.Data.SqlSever.Entities.SpecialistEntities;

namespace MetaEmp.Application;

internal class MappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        SpecialistMappings(config);
        CourseMappings(config);
        CompanyMappings(config);

        config.NewConfig<AppUser, User>()
            .Map(m => m.Id, s => s.Id)
            .Map(m => m.Username, s => s.UserName);
    }

    private void CompanyMappings(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCompanyRequest, Company>()
            .Map(c => c.Socials, cc => Serialize(cc.Socials));

        config.NewConfig<UpdateCompanyRequest, Company>()
            .Map(c => c.Socials, cc => Serialize(cc.Socials))
            .IgnoreNullValues(true);

        config.NewConfig<Company, CompanyResult>()
            .Map(c => c.Socials, cr => Deserialize<Socials>(cr.Socials));
    }

    private void SpecialistMappings(TypeAdapterConfig config)
    {
        config.NewConfig<Specialist, SpecialistResult>()
            .Map(sr => sr.ListOfSkills, s => Deserialize<List<string>>(s.ListOfSkillsJson));

        config.NewConfig<CreateSpecialistRequest, Specialist>()
            .Map(s => s.ListOfSkillsJson, cs => Serialize(cs.ListOfSkills));

        config.NewConfig<UpdateSpecialistRequest, Specialist>()
            .Map(s => s.ListOfSkillsJson, us => Serialize(us.ListOfSkills))
            .IgnoreNullValues(true);
    }

    private void CourseMappings(TypeAdapterConfig config)
    {
        config.NewConfig<CourseProfile, CourseResult>()
            .Map(cr => cr.Roads, cp => Deserialize<List<string>>(cp.RoadsJson));

        config.NewConfig<CreateCourseRequest, CourseProfile>()
            .Map(cc => cc.RoadsJson, cp => Serialize(cp.Roads));

        config.NewConfig<UpdateCourseRequest, CourseProfile>()
            .Map(uc => uc.RoadsJson, cp => Serialize(cp.Roads));
    }

    private static string Serialize<T>(T data) => JsonSerializer.Serialize(data, JsonConventions.CamelCase);

    private static T Deserialize<T>(string? data)
        => JsonSerializer.Deserialize<T>(data, JsonConventions.CamelCase);
}