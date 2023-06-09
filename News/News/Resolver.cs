﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
namespace News
{
    public class Resolver
    {

        private static IContainer container;

        public static void Intialize(IContainer container)
        {
            Resolver.container = container;
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
