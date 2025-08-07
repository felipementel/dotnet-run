#!/home/felipementel/.dotnet/dotnet run
#:sdk Microsoft.NET.Sdk.Web
#:package Microsoft.AspNetCore.OpenApi@10.*-*
#:package Microsoft.AspNetCore.Http@2.3.*-*
#:package Scalar.AspNetCore@2.6.*-*

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hthttp;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddOpenApi();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolver = CanalDEPLOYJsonContext.Default;
});

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapGet("/", () => "Canal DEPLOY");
app.MapGet("/user/{id}", ([FromRoute] string id) =>
{
    return TypedResults.Ok(new CanalDEPLOYUser { Nome = $"user", Chave = $"User ID: {id}" });
});

await app.RunAsync();

public class CanalDEPLOYUser
{
    public string Nome { get; set; }
    public string Chave { get; set; }
}

[JsonSerializable(typeof(CanalDEPLOYUser))]
public partial class CanalDEPLOYJsonContext : JsonSerializerContext { }
