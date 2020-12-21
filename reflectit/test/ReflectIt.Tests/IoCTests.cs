using System;
using Xunit;

namespace ReflectIt.Tests
{
    public class IoCTests
    {
        [Fact]
        public void Can_Resolve_Types()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.Equal(typeof(SqlServerLogger), logger.GetType());

        }
        [Fact]
        public void Can_Resolve_Types_Without_Default_Constructors()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();

            var repository = ioc.Resolve<IRepository<Employee>>();

            Assert.Equal(typeof(SqlRepository<Employee>), repository.GetType());

        }
         
        [Fact]
        public void Can_Resolve_Concrete_Type()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For(typeof(IRepository<>)).Use(typeof(SqlRepository<>));

            var service = ioc.Resolve<InvoiceService>();

            Assert.NotNull(service);

        }
    }
}
