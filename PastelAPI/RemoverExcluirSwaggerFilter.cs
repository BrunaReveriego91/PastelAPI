using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Configuration;

public class RemoverExcluirSwaggerFilter : IDocumentFilter
{
    private readonly IConfiguration _config;

    public RemoverExcluirSwaggerFilter(IConfiguration config)
    {
        _config = config;

    }

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var rotas = swaggerDoc.Paths
            .ToList();

        rotas.ForEach(x =>
        {
            if (VerifyAppSettings(x) == false)
                swaggerDoc.Paths.Remove(x.Key);
        }
        );


    }

    private bool VerifyAppSettings(KeyValuePair<string, OpenApiPathItem> rota)
    {
        var rotasPermitidas = _config.GetSection("AllowedRoutes:0").GetChildren().AsEnumerable();

        foreach (var item in rotasPermitidas)
        {
            if (rota.Key == item.Key)
                return Convert.ToBoolean(item.Value);
        }
        return true;
    }

}