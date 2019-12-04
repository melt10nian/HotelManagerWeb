using Models;
using System.Collections.Generic;

namespace IRepository
{
    public interface ICustomerService
    {
        List<CustomerInfo> GetCustomerInfos(string username);
    }
}