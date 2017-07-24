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
            List<OwnerBuilding> _someBuilding = getSomeOwnerBuilding(id);
            foreach (OwnerBuilding _building in _someBuilding)
            {
                db.OwnerBuilding.Remove(_building);
            }
            db.Owner.Remove(getOneOwner(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Print()
        {
            return View(getAllOwner());
        }
        //for OwnerBuilding
        /*************************************************************************************************/
        public ActionResult ListOwnerBuilding(int? id)
        {
            if (id > 0)
            {
                ViewBag.ownerId = id;
                return View(getSomeOwnerBuilding(id.Value));
            }
            return RedirectToAction("Index");
        }
        public ActionResult CreateOwnerBuilding(int? id)
        {
            if (id > 0)
            {
                ViewBag.ownerId = id;
                Session["ownerId"] = id.ToString();
                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOwnerBuilding(OwnerBuilding ownerBuilding)
        {
            OwnerBuilding _ownerBuilding = new OwnerBuilding()
            {
                BuildingName = ownerBuilding.BuildingName,
                ConPerson = ownerBuilding.ConPerson,
                ConPersonTel = ownerBuilding.ConPersonTel,
                Address = ownerBuilding.Address,
                OwnerID = Convert.ToInt32(Session["ownerId"].ToString())
            };
            Session["ownerId"] = null;
            db.OwnerBuilding.Add(_ownerBuilding);
            db.SaveChanges();
            return RedirectToAction("ListOwnerBuilding", new { id = _ownerBuilding.OwnerID });
        }
        public ActionResult EditOwnerBuilding(int? id)
        {
            if (id > 0)
            {
                ViewBag.ownerId = id;
                return View(getOneOwnerBuilding(id.Value));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOwnerBuilding(int id, OwnerBuilding ownerBuilding)
        {
            OwnerBuilding _ownerBuilding = getOneOwnerBuilding(id);
            _ownerBuilding.BuildingName = ownerBuilding.BuildingName;
            _ownerBuilding.ConPerson = ownerBuilding.ConPerson;
            _ownerBuilding.ConPersonTel = ownerBuilding.ConPersonTel;
            _ownerBuilding.Address = ownerBuilding.Address;
            db.SaveChanges();
            return RedirectToAction("ListOwnerBuilding", new { id = _ownerBuilding.OwnerID });
        }
        public ActionResult DeleteOwnerBuilding(int id)
        {
            OwnerBuilding _ownerBuilding = getOneOwnerBuilding(id);
            db.OwnerBuilding.Remove(_ownerBuilding);
            db.SaveChanges();
            return RedirectToAction("ListOwnerBuilding", new { id = _ownerBuilding.OwnerID });
        }
    }
}
