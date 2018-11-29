using System;
using System.Collections.Generic;
using System.Text;

namespace BookExchangeConsoleApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool IsBookOwnerExistsAlready(string ownerName);
    }
}
