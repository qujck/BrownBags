using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRSConsole1
{
    public static class Extensions
    {
        public static ICommandHandler<TCommand> WrappedWithConsoleLogger<TCommand>(
            this ICommandHandler<TCommand> instance) where TCommand : ICommand
        {
            return new CommandHandlerConsoleLogger<TCommand>(instance);
        }
    }
}
