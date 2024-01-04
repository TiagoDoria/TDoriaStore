using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TDStore.Config.Identity;
using TDStore.Identity.Data;
using TDStore.Identity.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Identity configuration

builder.Services.AddDbContext<IdentityStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityErrorMessages>()
                .AddEntityFrameworkStores<IdentityStoreDbContext>()
                .AddDefaultTokenProviders();


// Configuração do jwt
builder.Services.AddJwtConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
