using IRepository;
using log4net;
using Models;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class CustomerService : ICustomerService
    {
        ILog Logger = LogManager.GetLogger($"{typeof(CustomerService)}");
        public List<CustomerInfo> GetCustomerInfos(string username)
        {
            var methodName = $"{typeof(CustomerInfo)}.{nameof(GetCustomerInfos)}";
            var result = new List<CustomerInfo>();
            try
            {
                Logger.Debug($"{methodName} is entry.");

                using (var context = new HotelDBContext())
                {
                    var customerInfo = new CustomerInfo()
                    {
                        Name = "Cindy",
                        IdNumber = "150422199204211556",
                        Birthday = new DateTime(1992, 04, 21),
                    };
                    context.CustomerInfo.Add(customerInfo);
                    var count = context.SaveChanges();
                    Logger.Info($"result count:{count}");
                    result = new List<CustomerInfo> { customerInfo };
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"There is an error occurred in {methodName}:{ex.ToString()}");
            }
            finally
            {
                Logger.Debug($"{methodName} is finished.");
            }
            return result;
        }
    }
}