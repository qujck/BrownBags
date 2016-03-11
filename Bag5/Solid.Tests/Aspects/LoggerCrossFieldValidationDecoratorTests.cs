using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Solid.Aspects;
using Solid.Model;

namespace Solid.Tests.Unit.Aspects
{
    public class LoggerCrossFieldValidationDecoratorTests
    {
        [Test]
        public void Validate_Always_CallsTheLogger()
        {
            var decorator = this.DecoratorFactory();
        }


        LoggerSingleFieldValidatorDecorator DecoratorFactory()
        {
            return new LoggerSingleFieldValidatorDecorator(
                new MockSingleFieldValidator(),
                new StubLogger());
        }

        private class MockSingleFieldValidator : ISingleFieldValidator
        {
            public void Validate(FileData data)
            {
                throw new NotImplementedException();
            }
        }

        private class StubLogger : ILogger
        {
            public void Log(Func<string> messageFactory)
            {
                throw new NotImplementedException();
            }
        }
    }
}
