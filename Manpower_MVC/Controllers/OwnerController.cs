using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Manpower_MVC.Models;
using Manpower_MVC.Controllers.Api;

namespace Manpower_MVC.Controllers
{
    public class OwnerController : ApiController
    {
        public ActionResult Index()
        {
            return View(getAllOwner());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Owner owner)
        {
            db.Owner.Add(owner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View(getOneOwner(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Owner owner)
        {
            Owner _owner = getOneOwner(id);
            _owner.OwnerID = owner.OwnerID;
            _owner.OwnerName = owner.OwnerName;
            _owner.Tel = owner.Tel;
            _owner.Tel2 = owner.Tel2;
            _owner.ConPerson = owner.ConPerson;
            _owner.ConPersonPhone = owner.ConPersonPhone;
            _owner.ConPersonTel = owner.ConPersonTel;
            _owner.UnifiedNum = owner.UnifiedNum;
            _owner.Address = owner.Address;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            db.Owner.Remove(getOneOwner(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
