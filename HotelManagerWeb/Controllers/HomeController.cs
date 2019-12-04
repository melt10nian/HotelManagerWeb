using IRepository;
using log4net;
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
            var fistCustomer = _customerService.GetCustomerInfos("Jeff");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}