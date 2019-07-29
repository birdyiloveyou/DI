using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DI
{
    internal interface IA
    {
        void Write();
    }

    internal interface IB
    {
    }

    internal interface IC
    {
    }

    internal class A : IA
    {
        public void Write()
        {
            Console.WriteLine("GOOD");
        }
    }

    internal class B : IB
    {
    }

    internal class C : IC
    {
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new ContainerBuilder();
            container.RegisterType<A>().As<IA>();
            container.RegisterType<B>().As<IB>();
            container.RegisterType<C>().As<IC>();
            container.RegisterType<Wrapper>();
            var ans = container.Build();
            var wrapper = ans.Resolve<Wrapper>();
            wrapper.test();
            Console.ReadLine();
        }
    }

    internal class Wrapper
    {
        private IA _ia;
        private IB _ib;
        private IC _ic;

        public Wrapper(IA ia, IB ib, IC ic)
        {
            _ia = ia;
            _ib = ib;
            _ic = ic;
        }

        public void test()
        {
            _ia.Write();
        }
    }
}