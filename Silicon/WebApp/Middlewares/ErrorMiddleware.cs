﻿namespace WebApp.Middlewares;

public class ErrorMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    //public async Task InvokeAsync(HttpContext context)
    //{
    //    await _next;
    //} 

}
