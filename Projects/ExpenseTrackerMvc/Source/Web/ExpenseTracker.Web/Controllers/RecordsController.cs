namespace ExpenseTracker.Web.Controllers
{
    using System.Web.Mvc;

    public class RecordsController : Controller
    {
        // GET: Records
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
