using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Contracts;

public interface ICompanyCarsProvider
{
    Task<List<CompanyCarInfo>> GetAllCompanyCars();
}