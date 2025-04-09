using BudgeBuddyProject.Dtos;
using BudgeBuddyProject.Facades;
using BudgeBuddyProject.Queries;
using BudgeBuddyProject.Queries.Interfaces;
using BudgeBuddyProject.Repositories;
using BudgeBuddyProject.Repositories.Interfaces;
using BudgeBuddyProject.Services;
using BudgeBuddyProject.Services.Interfaces;
using BudgeBuddyProject.Validators;
using BudgeBuddyProjects.Data.Context;
using FluentValidation;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHangfire(configuration =>
    configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                 .UseSimpleAssemblyNameTypeSerializer()
                 .UseRecommendedSerializerSettings()
                 .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new SqlServerStorageOptions
                     {
                         CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                         SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                         QueuePollInterval = TimeSpan.FromSeconds(15),
                         UseRecommendedIsolationLevel = true,
                         DisableGlobalLocks = true
                     }));

builder.Services.AddHangfireServer();

BootstrapClass(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseRouting();

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
});


RecurringJobHanfire();

app.Run();

static void BootstrapClass(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserQuery, UserQuery>();
    builder.Services.AddScoped<IValidator<UserDto>, UserDtoValidator>();

    builder.Services.AddScoped<IFixedBillRepository, FixedBillRepository>();
    builder.Services.AddScoped<IFixedBillService, FixedBillService>();
    builder.Services.AddScoped<IFixedBillQuery, FixedBillQuery>();
    builder.Services.AddScoped<IValidator<FixedBillDto>, FixedBillDtoValidator>();

    builder.Services.AddScoped<ITransactionalDescriptionRepository, TransactionalDescriptionRepository>();
    builder.Services.AddScoped<ITransactionalDescriptionService, TransactionalDescriptionService>();
    builder.Services.AddScoped<ITransactionalDescriptionQuery, TransactionalDescriptionQuery>();
    builder.Services.AddScoped<IValidator<TransactionalDescriptionDto>, TransactionalDescriptionDtoValidator>();

    builder.Services.AddScoped<IBudgeTargetRepository, BudgeTargetRepository>();
    builder.Services.AddScoped<IBudgeTargetService, BudgeTargetService>();
    builder.Services.AddScoped<IBudgeTargetQuery, BudgeTargetQuery>();
    builder.Services.AddScoped<IValidator<BudgeTargetDto>, BudgeTargetDtoValidator>();

    builder.Services.AddScoped<IFinancialTransactionalRepository, FinancialTransactionalRepository>();
    builder.Services.AddScoped<IFinancialTransactionsService, FinancialTransactionsService>();
    builder.Services.AddScoped<IFinancialTransactionalQuery, FinancialTransactionQuery>();
    builder.Services.AddScoped<IValidator<FinancialTransactionsDto>, FinancialTransactionsDtoValidator>();

    builder.Services.AddScoped<ISendNotificationByEmailService, SendNotificationByEmailService>();
    builder.Services.AddScoped<IEmailService, EmailService>();
    builder.Services.AddScoped<IUserAndFixedBillToSendNotificationQuery, UserAndFixedBillToSendNotificationQuery>();
}

static void RecurringJobHanfire()
{
    RecurringJob.AddOrUpdate<EmailNotificationFacade>(
        "minha-tarefa-diaria",
        facade => facade.SendFixedBillNotificationByEmail(),
        Cron.Daily);
}