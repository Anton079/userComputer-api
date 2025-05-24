using UserComputer_api.System;

namespace UserComputer_api.Users.Exceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException() :base(ExceptionMessages.UserNotFoundException) { }
    }
}
