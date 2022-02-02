﻿using System;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Abp.WebApi.Validation;
using System.Threading;

namespace UniSolution.FabianoRangel26.Web
{
    public class MvcApplication : AbpWebApplication<FabianoRangel26WebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
#if DEBUG
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.config"))
            );
#else
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.Production.config"))
            );
#endif
            base.Application_Start(sender, e);

            //try
            //{
            //    //new AbpApiValidationFilter(AbpBootstrapper.IocManager, null).ExecuteActionFilterAsync(null, default(CancellationToken), null);

            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception);
            //    throw;
            //}
        }
    }
}
