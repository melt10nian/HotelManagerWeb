using IRepository;
using log4net;
using Models;
using System.Web.Mvc;

namespace HotelManagerWeb.Controllers
{
    public class HomeController : Controller
    {
        ILog Logger = LogManager.GetLogger("HomeController");
        public ICustomerService _customerService;
        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            Logger.Info("Start to get customer infos.");
            var customerList = _customerService.GetCustomerInfos("");
            return View(Json(customerList));
        }
        public ActionResult Edit(int id)
        {
            var result = new CustomerInfos();
            if (id > 0)
            {
                result = _customerService.GetCustomerInfoById(id);
            }
            return View(result);
        }
        public ActionResult Save(CustomerInfos customerInfo)
        {
            _customerService.Save(customerInfo);
            var customerList = _customerService.GetCustomerInfos("");
            return View("Index", Json(customerList));
        }
    }
}