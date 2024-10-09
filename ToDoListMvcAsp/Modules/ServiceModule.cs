using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoListMvcAsp.Services;

namespace ToDoListMvcAsp.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register the ITodoService to use the TodoService implementation
            builder.RegisterType<TodoService>().As<ITodoService>().SingleInstance();
        }
    }
}