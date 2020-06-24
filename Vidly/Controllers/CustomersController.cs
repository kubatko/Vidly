using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyDbContext _dbContext = new VidlyDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(_dbContext.Customers.Include(c => c.MembershipType).ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _dbContext.Customers.Include(c => c.MembershipType).Where(c => c.Id == id).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _dbContext.Customers.Add(customer);
            else
            {
                var customerInDb = _dbContext.Customers.SingleOrDefault(i => i.Id == customer.Id);

                // Security hole - not use
                //TryUpdateModel(customerInDb,"",new string[] { "Name", "Email" });

                // rather use below
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                // or best bellow
                //Mapper.Map(customer, customerInDb);

            }

            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult New()
        {
            var membershipTypes = _dbContext.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MemberShipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(i => i.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes = _dbContext.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }   
     
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
