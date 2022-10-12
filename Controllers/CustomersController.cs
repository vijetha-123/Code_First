using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codefirst.Models;
using codefirst.data;
using codefirst.Utilities;
using NToastNotify;

namespace codefirst.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly Customer_DbContext _context;

        public CustomersController(ILogger<CustomersController> logger, IToastNotification toastNotification, Customer_DbContext context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.cust_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cust_ID,cust_name,cust_age,d_order,cust_dob,cust_mob,cust_mail,cust_pswd,cust_confirmpswd")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.cust_pswd=EncryptDecrypt.Encrypt(customer.cust_pswd);
                _context.Add(customer);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Employee created successfully");
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cust_ID,cust_name,cust_age,d_order,cust_dob,cust_mob,cust_mail,cust_pswd,cust_confirmpswd")] Customer customer)
        {
            if (id != customer.cust_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customer.cust_pswd = EncryptDecrypt.Encrypt(customer.cust_pswd);
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddWarningToastMessage("Employee updated successfully");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.cust_ID))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.cust_ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customers == null)
            {
                return Problem("Entity set 'Customer_DbContext.Customers'  is null.");
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddErrorToastMessage("Employee deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return _context.Customers.Any(e => e.cust_ID == id);
        }
    }
}
