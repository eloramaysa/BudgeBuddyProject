using BudgeBuddyProject.Dtos;
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

// 1. Configurações básicas da API
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

// 2. Configuração do CORS
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

// 3. Configuração do Swagger
builder.Services.AddSwaggerGen();

// 4. Configuração do Banco de Dados
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 5. Configuração do Hangfire
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

// 6. Bootstrap (se necessário)
BootstrapClass(builder);

// Build da aplicação
var app = builder.Build();

// 7. Configuração do Pipeline HTTP (Middlewares)
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

// A ordem dos middlewares é crucial
app.UseRouting();

// CORS deve vir depois do Routing e antes da Autorização
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication(); // Se estiver usando autenticação
app.UseAuthorization();

// 8. Configuração dos Endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard(); // Mapeia o dashboard do Hangfire
});

// 9. Configuração do Hangfire Dashboard
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    // Configurações adicionais do dashboard, se necessário
    // Authorization = new[] { new HangfireAuthorizationFilter() }
});

// 10. Configuração de Jobs Recorrentes
RecurringJobHanfire();

// Inicia a aplicação
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
    builder.Services.AddScoped<IEmailService, EmailService2>();
    builder.Services.AddScoped<IUserAndFixedBillToSendNotificationQuery, UserAndFixedBillToSendNotificationQuery>();
}

static void RecurringJobHanfire()
{
    //RecurringJob.AddOrUpdate<EmailNotificationFacade>(
    //    "minha-tarefa-diaria",
    //    facade => facade.SendFixedBillNotificationByEmail(),
    //    Cron.Minutely);
}