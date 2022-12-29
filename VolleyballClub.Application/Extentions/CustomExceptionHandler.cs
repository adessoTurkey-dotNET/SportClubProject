using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using VolleyballClub.Application.Dtos;

namespace VolleyballClub.Application.Extentions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        { 
            app.UseExceptionHandler(config =>
            {
                config.Run(async context => { 
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;
                        var response = CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status500InternalServerError, new List<string> { ex.Message});
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
