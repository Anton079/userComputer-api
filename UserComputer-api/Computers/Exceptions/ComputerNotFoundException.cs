using UserComputer_api.System;

namespace UserComputer_api.Computers.Exceptions
{
    public class ComputerNotFoundException:Exception
    {
        public ComputerNotFoundException() : base(ExceptionMessages.ComputerNotFoundException) { }
    }
}
