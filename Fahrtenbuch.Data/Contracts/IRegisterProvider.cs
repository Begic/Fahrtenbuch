using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Contracts;

public interface IRegisterProvider
{
    Task AddUser(RegisterInfo registerInfoToEdit);
}