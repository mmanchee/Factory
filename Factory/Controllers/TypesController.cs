using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class TypesController : Controller
  {
    private readonly FactoryContext _db;

    public TypesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Types.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Type Type)
    {
      _db.Types.Add(Type);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = Type.TypeId});
    }
    public ActionResult Edit(int id)
    {
      var thisType = _db.Types.FirstOrDefault(Type => Type.TypeId == id);
      return View(thisType);
    }

    [HttpPost]
    public ActionResult Edit(Type Type, int EngineerId)
    {
      _db.Entry(Type).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = Type.TypeId});
    }

    public ActionResult Details(int id)
    {
      var thisType = _db.Types.FirstOrDefault(Type => Type.TypeId == id);
      ViewBag.Machines = _db.Machines.Where(machines => machines.TypeId == id).ToList();
      return View(thisType);
    }
    public ActionResult DeleteLicense(int joinId, int TypeId)
    {
      var joinEntry = _db.LicenseType.FirstOrDefault(entry => entry.LicenseTypeId == joinId);
      _db.LicenseType.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = TypeId });
    }
  }
}