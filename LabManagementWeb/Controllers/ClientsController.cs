//-----------------------------------------------------------------------
// <copyright file="ClientsController.cs" company="GallowayConsulting">
//  Clients Controller
// </copyright>
//-----------------------------------------------------------------------

namespace LabManagementWeb.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using LabManagementWeb.Models;

    /// <summary>
    /// Clients Controller class
    /// </summary>
    public class ClientsController : Controller
    {
        /// <summary>
        /// Private instance of the application context
        /// </summary>
        private ApplicationDBContext db = new ApplicationDBContext();

        /// <summary>
        /// GET: Clients
        /// </summary>
        /// <returns>Client view</returns>
        public ActionResult Index()
        {
            return this.View(this.db.Clients.ToList());
        }

        /// <summary>
        /// GET: Clients/Details/5
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <returns>Client view</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = this.db.Clients.Find(id);
            if (client == null)
            {
                return this.HttpNotFound();
            }

            return this.View(client);
        }

        /// <summary>
        /// GET: Clients/Create
        /// </summary>
        /// <returns>Client view</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// POST: Clients/Create
        /// </summary>
        /// <param name="client">Client model</param>
        /// <returns>Client view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,PhoneNumber,PostalAddress,ContactName,DateCreated,DateModified")] Client client)
        {
            if (ModelState.IsValid)
            {
                this.db.Clients.Add(client);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(client);
        }

        /// <summary>
        /// GET: Clients/Edit/5
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <returns>Client view</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = this.db.Clients.Find(id);
            if (client == null)
            {
                return this.HttpNotFound();
            }

            return this.View(client);
        }

        /// <summary>
        /// POST: Clients/Edit/5 
        /// </summary>
        /// <param name="client">Client model</param>
        /// <returns>Client view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,PhoneNumber,PostalAddress,ContactName,DateCreated,DateModified")] Client client)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(client).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(client);
        }

        /// <summary>
        /// GET: Clients/Delete/5 
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <returns>Client view</returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = this.db.Clients.Find(id);
            if (client == null)
            {
                return this.HttpNotFound();
            }

            return this.View(client);
        }

        /// <summary>
        /// POST: Clients/Delete/5 
        /// </summary>
        /// <param name="id">Client ID</param>
        /// <returns>Redirect to index</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = this.db.Clients.Find(id);
            this.db.Clients.Remove(client);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">Disposing True or False</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
