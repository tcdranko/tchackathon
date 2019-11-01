﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace TCRateAndFeedback
{
    static class Settings
    {
        public static string AadInstance => ConfigurationManager.AppSettings["ida:AADInstance"];
        public static string Tenant => ConfigurationManager.AppSettings["ida:Tenant"];
        public static string ClientId => ConfigurationManager.AppSettings["ida:ClientId"];
        public static string GraphResourceId => ConfigurationManager.AppSettings["ida:GraphResourceId"];
        public static string GraphApiVersion => ConfigurationManager.AppSettings["ida:GraphApiVersion"];
        public static string GraphApiEndpoint => ConfigurationManager.AppSettings["ida:GraphEndpoint"];

        public static Uri RedirectUri => new Uri(ConfigurationManager.AppSettings["ida:RedirectUri"]);
        public static string Authority => String.Format(CultureInfo.InvariantCulture, AadInstance, Tenant);
        
        public static string ServicesBaseUri => ConfigurationManager.AppSettings["ServicesBaseUri"];
    }
}