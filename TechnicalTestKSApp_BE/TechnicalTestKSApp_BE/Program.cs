using TechnicalTestKSApp_BE_DA.Interfaces;
using TechnicalTestKSApp_BE_DA;
using TechnicalTestKSApp_BE_BL.Interfaces;
using TechnicalTestKSApp_BE_BL.Interfaces.Logics;
using TechnicalTestKSApp_BE_BL.Logics;
using TechnicalTestKSApp_BE_BL.Models;
using TechnicalTestKSApp_BE.Filters;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using Dapper;
using TechnicalTestKSApp_BE_BL.Repositories;
using TechnicalTestKSApp_BE_BL.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDbContext, SqlContext>(dbContext => new SqlContext(new SqlConnection(builder.Configuration["Connnectionstrings:MaxiTechTestEmployeeBeneficiary"])));

builder.Services.AddScoped<IResponse, ResponseBase>();

builder.Services.AddScoped<IGeneralInformationBL, GeneralInformationBL>();
builder.Services.AddScoped<IBeneficiaryBL, BeneficiaryBL>();
builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
builder.Services.AddScoped<IGeneralInformationRepository, GeneralInformationRepository>();

//builder.Services.AddControllersWithViews(options =>
//{
//    options.Filters.Add<ModelValidationFilter>();
//});

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {   
            IResponse response = new ResponseBase(context.ModelState.IsValid);
            response.Errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value?.Errors.Select(x => x.ErrorMessage));
            return new BadRequestObjectResult(response)
            {
                ContentTypes =
                {
                    Application.Json,
                    Application.Xml
                }
            };
        };  
    })
    .AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy =>
{
    policy
        //.WithOrigins("https://localhost:4200/")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        //.SetIsOriginAllowed((host) => true)
        //.AllowCredentials()
        ;
});

app.UseAuthorization();

app.MapControllers();

app.Run();
