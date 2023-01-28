using CCCrossApi.Models;
using pt.portugal.eid;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "default",
                    policy =>
                    {
                      policy.WithOrigins("*");
                    });
});

var app = builder.Build();

app.UseCors("default");

app.MapGet("/api/cc", () =>
{
  // DOC: https://amagovpt.github.io/autenticacao.gov/manual_sdk.html#windows

  try
  {
    PTEID_ReaderContext readerContext = PTEID_ReaderSet.instance().getReader();
    PTEID_EIDCard card = readerContext.getEIDCard();

    var data = CCData.Get(card);

    return Results.Ok(data);
  }
  catch (PTEID_ExNoCardPresent)
  {
    return Results.NotFound();
  }
});

app.Run();
