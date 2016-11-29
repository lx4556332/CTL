﻿using CTL.BLL.Interfaces;
using CTL.BLL.Services;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CTL.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IUoWBLL>().To<UoWBLL>().WithConstructorArgument("DatabaseConnection");
        }
    }
}