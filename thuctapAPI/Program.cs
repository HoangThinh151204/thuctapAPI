using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using thuctapAPI.Data;
using thuctapAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader()));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountAreaService, AccountAreaService>();
builder.Services.AddScoped<IAccountNotificationService, AccountNotificationService>();
builder.Services.AddScoped<IAccountSurveyRequestService, AccountSurveyRequestService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IAreaService, AreaSercive>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IBaselineService, BaselineService>();
builder.Services.AddScoped<IBroadcastGroupService, BroadcastGroupService>();
builder.Services.AddScoped<IBroadcastsService, BroadcastService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobImageService, JobImageService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IPositionsService, PositionsService>();
builder.Services.AddScoped<IQuestionsService, QuestionsService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISurveyArticleService, SurveyArticleService>();
builder.Services.AddScoped<ISurveyRequestsService, SurveyRequestService>();
builder.Services.AddScoped<IVitstorService, VisitorService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
