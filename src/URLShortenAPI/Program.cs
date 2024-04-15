using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using URLShortenAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddShrinkUrlSettings(builder.Configuration);
//builder.Services.Configure<ShrinkUrlSettings>(builder.Configuration.GetSection(nameof(ShrinkUrlSettings)));
//builder.Services.AddSingleton(provider=>provider.GetRequiredService<IOptions<ShrinkUrlSettings>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/shorten", ([FromBody]string url, ShrinkUrlSettings urlSettings) => URLShortener.Shorten(url, urlSettings))
//app.MapPost("/shorten", (string url,ShrinkUrlSettings urlSettings) => {
//    //throw new ArgumentException();
//    //throw new FormatException();
//    //var url = "https://www.quantbe.com/welcome/canada/logs/validate";
//    var encryptedURL = Cryptography.EncryptUrl(url, urlSettings.MaxLength);
//    var url2 = "https://www.google.com";
//    var eurl2 = Cryptography.EncryptUrl(url2, urlSettings.MaxLength);
//    var url3 = "https://www.facebook.com";
//    var eurl3 = Cryptography.EncryptUrl(url3, urlSettings.MaxLength);
//    var url4 = "http://www.facebook.com";
//    var eurl4 = Cryptography.EncryptUrl(url4, urlSettings.MaxLength);
//    return new List<string>() {
//        url, encryptedURL,
//        url2,eurl2,
//        url3,eurl3,
//        url4,eurl4,
//        urlSettings.BaseUrl,urlSettings.MaxLength.ToString()

//    };
//})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

