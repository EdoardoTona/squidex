﻿// ==========================================================================
//  WebUsages.cs
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex Group
//  All rights reserved.
// ==========================================================================

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Squidex.Pipeline;

namespace Squidex.Config.Web
{
    public static class WebExtensions
    {
        public static void UseMyCors(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        }

        public static void UseMyForwardingRules(this IApplicationBuilder app)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto,
                ForwardLimit = null,
                RequireHeaderSymmetry = false
            });

            app.UseMiddleware<EnforceHttpsMiddleware>();
        }
    }
}
