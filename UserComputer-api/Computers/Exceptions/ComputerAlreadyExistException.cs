using UserComputer_api.System;

namespace UserComputer_api.Computers.Exceptions
{
    public class ComputerAlreadyExistException:Exception
    {
        public ComputerAlreadyExistException():base(ExceptionMessages.ComputerAlreadyExistException) { }
    }
}
