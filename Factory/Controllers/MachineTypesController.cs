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
      return View(_db.MachineTypes.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(MachineType machineType)
    {
      _db.MachineTypes.Add(machineType);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = machineType.MachineTypeId});
    }
    public ActionResult Edit(int id)
    {
      var thisType = _db.MachineTypes.FirstOrDefault(machineType => machineType.MachineTypeId == id);
      return View(thisType);
    }

    [HttpPost]
    public ActionResult Edit(MachineType machineType, int EngineerId)
    {
      _db.Entry(machineType).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = machineType.MachineTypeId});
    }

    public ActionResult Details(int id)
    {
      var thisType = _db.MachineTypes.FirstOrDefault(machineType => machineType.MachineTypeId == id);
      ViewBag.Machines = _db.Machines.Where(machines => machines.MachineTypeId == id).ToList();
      return View(thisType);
    }
    public ActionResult DeleteLicense(int joinId, int machineTypeId)
    {
      var joinEntry = _db.LicenseType.FirstOrDefault(entry => entry.LicenseTypeId == joinId);
      _db.LicenseType.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = machineTypeId });
    }
  }
}