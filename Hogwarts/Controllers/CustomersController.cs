using System.Linq;
using System.Threading.Tasks;
using Hogwarts.Models;
using Microsoft.AspNetCore.Http;/*מהקוד של חמי*/
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Http;

namespace Hogwarts.Controllers
{
    public class CustomersController : Controller
    {
        private readonly HogwartsContext _context;
        private const string IsAdminKey = "isAdmin";
        private const string CustomerKey = "customer";
        private const string CustomerIdKey = "customerId";

        public CustomersController(HogwartsContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Customer.ToListAsync());
            return RedirectToAction("Search", await _context.Customer.ToListAsync());
        }
        public async Task<IActionResult> Search(string Name, string Address, string MailAdress)
        {
            var result = from u in _context.Customer
                         where u.Name == Name && u.Address == Address && u.MailAdress == MailAdress
                         select u;

            return View(await result.ToListAsync());

        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        public IActionResult LogOff()
        {
            HttpContext.Session.Remove(CustomerKey);
            HttpContext.Session.Remove(CustomerIdKey);
            HttpContext.Session.Remove(IsAdminKey);
            return Redirect("~/Home/index");
        }


        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Login()
        {
            ViewBag.Fail = false;



            return View();
        }


        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Age,PhoneNumber,MailAdress,Password,Type")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //check if username already exists in database
                var isCustomerExist = CheckIfCustomerExist(customer);
                if (!isCustomerExist)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.SetString(CustomerKey, customer.Name);
                    HttpContext.Session.SetString(CustomerIdKey, customer.Id);

                }
                else
                {
                    // TODO - stay in the current view, and show an appropriate message
                    return View("Create", customer);
                }
                //return RedirectToAction(nameof(Index));
                return Redirect("~/Home/index");
                //return RedirectToAction("Create", "SignUpApplications");
            }
            return View(customer);
        }


        // Check if customer exist
        private bool CheckIfCustomerExist(Customer customer)
        {
            var customerEmailToLower = customer.MailAdress.ToLower();
            return _context.Customer.Where(c => c.MailAdress.ToLower() == customerEmailToLower).FirstOrDefault() != null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("MailAdress,Password")] Customer customer)
        {
            var matchedCustomer = _context.Customer.Where(x => x.MailAdress == customer.MailAdress.ToString() && x.Password == customer.Password.ToString()).FirstOrDefault();

            if (matchedCustomer != null)
            {
                HttpContext.Session.SetString(CustomerKey, matchedCustomer.Name);
                HttpContext.Session.SetString(CustomerIdKey, matchedCustomer.Id);

                // check if customer is admin
                var isAdmin = CheckIfCustomerAdmin(matchedCustomer);
                if (isAdmin)
                {
                    HttpContext.Session.SetString(IsAdminKey, "true");
                }
                return Redirect("~/Home/index");
            }

            ViewBag.Fail = true;
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Address,Age,PhoneNumber,MailAdress,Password,Type")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            // check if the logged in customer is admin          
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(CustomerKey)) && !string.IsNullOrEmpty(HttpContext.Session.GetString(IsAdminKey)))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var customer = await _context.Customer
                    .SingleOrDefaultAsync(m => m.Id == id);
                if (customer == null)
                {
                    return NotFound();
                }

                return View(customer);
            }
            else
                return RedirectToAction(nameof(Index), "Home");
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.Id == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }

        private bool CheckIfCustomerAdmin(Customer matchedCustomer)
        {
            // if the customer is elisheva return true
            var isAdmin = string.Compare("eli3162@gmail.com", matchedCustomer.MailAdress, true) == 0;
            return isAdmin;
        }
    }
}
