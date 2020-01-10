using IRepository;
using log4net;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class CustomerService : ICustomerService
    {
        ILog Logger = LogManager.GetLogger($"{typeof(CustomerService)}");

        public CustomerInfos GetCustomerInfoById(int id)
        {
            var methodName = $"{typeof(CustomerService)}.{nameof(GetCustomerInfoById)}";
            var result = new CustomerInfos();
            try
            {
                Logger.Debug($"{methodName} is entry.");
                using (var context = new HotelDBContext())
                {
                    result = context.CustomerInfo.FirstOrDefault(a => a.Id == id);
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

        public List<CustomerInfos> GetCustomerInfos(string username)
        {
            var methodName = $"{typeof(CustomerService)}.{nameof(GetCustomerInfos)}";
            var result = new List<CustomerInfos>();
            try
            {
                Logger.Debug($"{methodName} is entry.");

                using (var context = new HotelDBContext())
                {
                    var customerInfo = context.CustomerInfo.ToList();
                    result.AddRange(customerInfo);
                    //var customerInfo = new CustomerInfo()
                    //{
                    //    Name = "Cindy",
                    //    IdNumber = "150422199204211556",
                    //    Birthday = new DateTime(1992, 04, 21),
                    //};
                    //context.CustomerInfo.Add(customerInfo);
                    //var count = context.SaveChanges();
                    //Logger.Info($"result count:{count}");

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

        public void Save(CustomerInfos customerInfo)
        {
            var methodName = $"{typeof(CustomerService)}.{nameof(GetCustomerInfos)}";
            try
            {
                Logger.Debug($"{methodName} is entry.");
                using (var context = new HotelDBContext())
                {
                    if (customerInfo.Id > 0)
                    {
                        var existRecord = context.CustomerInfo.FirstOrDefault(a => a.Id == customerInfo.Id);
                        if (existRecord != null)
                        {
                            existRecord.Name = customerInfo.Name;
                            existRecord.PhoneNumber = customerInfo.PhoneNumber;
                            existRecord.Disable = customerInfo.Disable;
                        }
                    }
                    else
                    {
                        context.CustomerInfo.Add(customerInfo);
                    }
                    context.SaveChanges();
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
        }
    }
}