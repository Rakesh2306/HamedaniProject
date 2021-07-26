using AutoMapper;
using HamedaniProject.Models;
using HamedaniProject.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HamedaniProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private HamedaniProjectNewEntities _context;

        public CustomerController()
        {
            _context = new HamedaniProjectNewEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult CreateNewCustomer()
        {
            var memberShipTable = _context.MembershipTypeTables.ToList();

            var customer = new CustomerTable();


            NewCustomerViewModel newCustomer = new NewCustomerViewModel()
            {
                Customer = customer,
                Membershiptable = memberShipTable
            };

;

            return View(newCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewCustomer(CustomerTable customer)
        {
            if (!ModelState.IsValid)
            {
                var memberShipTable = _context.MembershipTypeTables.ToList();
                NewCustomerViewModel newCustomer = new NewCustomerViewModel()
                {
                    Customer = customer,
                    Membershiptable = memberShipTable
                };
                return View("CreateNewCustomer", newCustomer);
            }
            else
            {
                _context.CustomerTables.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("GetAllCustomers", "Customer");
            }
         
        }

        public ActionResult GetAllCustomers()
        {
            List<CustomerTable> customer = _context.CustomerTables.ToList();

            SampleDataViewModel sampleDataView = new SampleDataViewModel()
            {
                samples = customer
            };

            return View(sampleDataView);
        }

        public ActionResult AllCustomers()
        {
            
            var customers = new List<Customer>()
            {
                new Customer {Id=1,Name="Eliot Alderson"},
                new Customer {Id=2,Name="Darlene"},
                new Customer {Id=3,Name = "White Rose"}
            };

            var allCustomers = new AllCustomerViewModel()
            {
                Customer = customers
            };
            return View(allCustomers);
        }

        public ActionResult Details(int Id)
        {
            var customerDetail = _context.CustomerTables.SingleOrDefault(c => c.Id == Id);

            var membershipTable = _context.MembershipTypeTables.ToList();

            //CustomerDetails customerDetails = new CustomerDetails();

            //customerDetails.Name = customerDetail.Name;
            //customerDetails.Id = customerDetail.Id;
            //customerDetails.birthDate =(DateTime) customerDetail.Birthdate;
            //customerDetails.membershipTypeTable = customerDetail.MembershipTypeTable;



            NewCustomerViewModel newCustomerViewModel = new NewCustomerViewModel()
            {
                Customer = customerDetail,
                Membershiptable = membershipTable

            };
           

            //return View(customerDetail);
            return View(newCustomerViewModel);
        }


        public ActionResult UpdateCustomerDetails(CustomerTable customer)
        {
            var customerInDb = _context.CustomerTables.Single(c => c.Id == customer.Id);

            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.Name = customer.Name;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            _context.SaveChanges();

            return RedirectToAction("GetAllCustomers", "Customer");

        }

    }
}