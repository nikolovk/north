﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MVC.Startup))]

namespace MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuthentication(app);
        }
    }
}