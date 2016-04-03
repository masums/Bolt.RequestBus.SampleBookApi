﻿using System;
using System.Web.Http.Routing;

namespace BookWorm.Api.Features.Shared.Extensions
{
    public static class UrlHelperExtensions
    {
        public static Uri BookById(this UrlHelper url, Guid id)
        {
            return new Uri(url.Route(RouteNames.BookById, new {id = id}), UriKind.RelativeOrAbsolute);
        }
    }

    public static class RouteNames
    {
        public const string BookById = "BookById";
    }
}