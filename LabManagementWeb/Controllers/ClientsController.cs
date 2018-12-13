using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LabManagementWeb.DAL;
using LabManagementWeb.Models;

namespace LabManagementWeb.Controllers
{
    public class ClientsController : Controller
    {
        private IClientsRepository clientsRepository;

        public ClientsController()
        {
            this.clientsRepository = new ClientsRepository(new ApplicationDbContext());
        }

        // GET: Clients
        [Authorize]
        public ActionResult Index()
        {
            var clients = from j in clientsRepository.GetClients()
                           select j;
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = clientsRepository.GetClientByID(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Name,Company,MailingAddress,EmailAddress,PhoneNumber,FaxNumber,SendInvToSame,InvoiceName,InvoiceCompany,InvoiceMailingAddress,InvoiceEmailAddress,InvoicePhoneNumber,InvoiceFaxNumber,DateCreated, DateModified")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientsRepository.InsertClient(client);
                clientsRepository.Save();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = clientsRepository.GetClientByID(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Name,Company,MailingAddress,EmailAddress,PhoneNumber,FaxNumber,SendInvToSame,InvoiceName,InvoiceCompany,InvoiceMailingAddress,InvoiceEmailAddress,InvoicePhoneNumber,InvoiceFaxNumber,DateCreated, DateModified")] Client client)
        {
            if (ModelState.IsValid)
            {
                clientsRepository.UpdateClient(client);
                clientsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = clientsRepository.GetClientByID(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = clientsRepository.GetClientByID(id);
            clientsRepository.DeleteClient(id);
            clientsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                clientsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
