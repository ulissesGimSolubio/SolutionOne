using Ecomerce.Configuration;
using Ecomerce.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

//Configurações de mvc
//Configuração de injeção de dependência
//Configuração do identity
builder
    .AddMvcConfiguration()
    .AddDependencyInjectionConfiguration()
    .AddIdentityConfiguration();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();
