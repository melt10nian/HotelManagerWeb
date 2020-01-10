using Models;
using System.Collections.Generic;

namespace IRepository
{
    public interface ICustomerService
    {
        List<CustomerInfos> GetCustomerInfos(string username);
        CustomerInfos GetCustomerInfoById(int id);
        void Save(CustomerInfos customerInfo);
    }
}