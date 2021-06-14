using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Interfaces;
using Infrastructure.Utilities.Interceptors;
using Infrastructure.Utilities.Security.Jwt;
using Services.Concrete;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IoTService.Autofac
{
    public class AutofacBusinessModule:Module
    {
        //single repository design pattern IoC pattern autofac framework u sayesinde yaptık
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<PhotoService>().As<IPhotoService>();
            builder.RegisterType<EfPhotoDal>().As<IPhotoDal>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
