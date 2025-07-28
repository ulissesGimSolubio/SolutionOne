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

//Configura��es de mvc
//Configura��o de inje��o de depend�ncia
//Configura��o do identity
builder
    .AddMvcConfiguration()
    .AddDependencyInjectionConfiguration()
    .AddIdentityConfiguration();

var app = builder.Build();

app.UseMvcConfiguration();

app.Run();
