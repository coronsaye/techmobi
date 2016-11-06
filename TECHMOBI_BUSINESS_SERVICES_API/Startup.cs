using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TECHMOBI_BUSINESS_SERVICES_API.Startup))]

namespace TECHMOBI_BUSINESS_SERVICES_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
