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
            if (Session["isLogin"] == null)
            {
                TempData["login"] = 1;
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        public ActionResult getOwner()
        {
            return Json(getAllOwner(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getBuilding(int? id)
        {
            if (id == null)
            {
                return Json(new List<OwnerBuilding>());
            }
            return Json(getSomeOwnerBuilding(id.Value), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(Owner owner, List<OwnerBuilding> building)
        {
            db.Owner.Add(owner);
            db.SaveChanges();
            for (int i = 0; i < building.Count; i++)
            {
                if (i != 0)
                {
                    OwnerBuilding _building = new OwnerBuilding()
                    {
                        OwnerID = owner.ID,
                        BuildingName = building[i].BuildingName,
                        ConPerson = building[i].ConPerson,
                        ConPersonTel = building[i].ConPersonTel,
                        Address = building[i].Address
                    };
                    db.OwnerBuilding.Add(_building);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return Json(getOneOwner(id), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
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
        public ActionResult CreateOwnerBuilding(OwnerBuilding ownerBuilding)
        {
            OwnerBuilding _ownerBuilding = new OwnerBuilding()
            {
                BuildingName = ownerBuilding.BuildingName,
                ConPerson = ownerBuilding.ConPerson,
                ConPersonTel = ownerBuilding.ConPersonTel,
                Address = ownerBuilding.Address,
                OwnerID = ownerBuilding.OwnerID
            };
            db.OwnerBuilding.Add(_ownerBuilding);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EditOwnerBuilding(int? id)
        {
            if (id == null)
            {
                return Json(new OwnerBuilding());
            }
            return Json(getOneOwnerBuilding(id.Value), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EditOwnerBuilding(OwnerBuilding ownerBuilding)
        {
            OwnerBuilding _ownerBuilding = getOneOwnerBuilding(ownerBuilding.ID);
            _ownerBuilding.BuildingName = ownerBuilding.BuildingName;
            _ownerBuilding.ConPerson = ownerBuilding.ConPerson;
            _ownerBuilding.ConPersonTel = ownerBuilding.ConPersonTel;
            _ownerBuilding.Address = ownerBuilding.Address;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteOwnerBuilding(int id)
        {
            OwnerBuilding _ownerBuilding = getOneOwnerBuilding(id);
            db.OwnerBuilding.Remove(_ownerBuilding);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
