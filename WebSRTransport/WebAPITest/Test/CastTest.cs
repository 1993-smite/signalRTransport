using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Extensions;
using WebAPI.Models;

namespace WebAPITest.Test
{
    public class Foo
    {

    }

    public class Foo1
    {

    }

    public class Foo2 : Foo
    {

    }


    [TestFixture]
    class CastTest
    {
        [Test]
        public void Cast()
        {
            var foo = new Foo();
            var foo1 = new Foo1();
            var foo2 = new Foo2();

            var f = foo.Cast<Foo,Foo1>();
            var f1 = foo1.Cast<Foo1, Foo2>();
            var f2 = foo2.Cast<Foo2, Foo1>();
            var f3 = foo1.Cast<Foo1, Foo>();
            var f4 = foo2.Cast<Foo2, Foo>();
        }
    }
}
