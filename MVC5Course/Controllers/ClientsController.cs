using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModels;

namespace MVC5Course.Controllers
{
    public class ClientsController : BaseController
    {
        // GET: Clients
        public ActionResult Index(string search,int? DPCreditRating, string DPGender)
        {

            var IQclient = db.Client.Include(c=>c.Occupation);
            if(!string.IsNullOrEmpty(search))
            {
                IQclient=IQclient.Where(p => p.FirstName.Contains(search));
            }
            if (DPCreditRating.HasValue)
            {
                IQclient = IQclient.Where(p => p.CreditRating==DPCreditRating);
            }
            if (!string.IsNullOrEmpty(DPGender))
            {
                IQclient = IQclient.Where(p => p.Gender.Contains(DPGender));
            }
            IQclient =IQclient.OrderByDescending(p =>p.ClientId).Take(10);

            var options = (from s1 in db.Client select s1.CreditRating).Distinct().ToList();
            ViewBag.DPCreditRating =new SelectList( options);

            ViewBag.DPGender = new SelectList(new string[]{ "M","F"});
            return View(IQclient.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ClientLoginViewModel p_ClientLoginViewModel)
        {
            return View("LoginResult", p_ClientLoginViewModel);
        }
        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        [ChildActionOnly]
        public ActionResult Create()
        {
            ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName");
            Client l_Client = new Client
            {
                Gender = "M",
                DateOfBirth = (DateTime?)DateTime.Now,
                CreditRating=0
            };
            return View(l_Client);
        }

        // POST: Clients/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,FirstName,MiddleName,LastName,Gender,DateOfBirth,CreditRating,XCode,OccupationId,TelephoneNumber,Street1,Street2,City,ZipCode,Longitude,Latitude,Notes")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Client.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // POST: Clients/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id ,FormCollection from )
        {
            var client = db.Client.Find(id);
            try
            {
                
                if (TryUpdateModel(client,null,null,new string[] { "Notes" }))
                {
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            ViewBag.OccupationId = new SelectList(db.Occupation, "OccupationId", "OccupationName", client.OccupationId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Client.Find(id);
            db.Client.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
