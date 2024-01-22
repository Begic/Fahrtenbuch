using Fahrtenbuch.Data.Models;

namespace Fahrtenbuch.Data.Contracts;

public interface ICompanyCarProvider
{
    Task<List<CompanyCarInfo>> GetAllCompanyCars();
    Task DeleteCompanyCar(int carId);
    Task EditCompanyCar(EditCompanyCarInfo editModel);
}