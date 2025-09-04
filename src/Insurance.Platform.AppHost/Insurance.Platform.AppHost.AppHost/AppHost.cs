using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var sqlPass = ResourceBuilder.Create(new ParameterResource("sqlpass", x => "1q2w3e4r@#$", true), builder);
var sql = builder.AddSqlServer("sqlserver", password: sqlPass, port: 1433)
 .WithDataVolume()
 .WithLifetime(ContainerLifetime.Session)
 .AddDatabase("Sql", databaseName: "isurance-plataform");


var test = builder.Configuration.GetConnectionString("Sql");

builder.AddProject<Projects.Insurance_Plataform_Api>("isurance-plataform-api")
 .WithReference(sql, "DefaultConnection");


var app = builder.Build();

await app.RunAsync();

class ResourceBuilder
{
    public static IResourceBuilder<T> Create<T>(T resource, IDistributedApplicationBuilder distributedApplicationBuilder) where T : IResource
    {
        return new ResourceBuilder<T>(resource, distributedApplicationBuilder);
    }
}

class ResourceBuilder<T>(T resource, IDistributedApplicationBuilder distributedApplicationBuilder) : IResourceBuilder<T> where T : IResource
{
    public IDistributedApplicationBuilder ApplicationBuilder { get; } = distributedApplicationBuilder;

    public T Resource { get; } = resource;

    public IResourceBuilder<T> WithAnnotation<TAnnotation>(TAnnotation annotation, ResourceAnnotationMutationBehavior behavior = ResourceAnnotationMutationBehavior.Append) where TAnnotation : IResourceAnnotation
    {
        throw new NotImplementedException();
    }
}