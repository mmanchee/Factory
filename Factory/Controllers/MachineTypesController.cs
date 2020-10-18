using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachineTypesController : Controller
  {
    private readonly FactoryContext _db;

    public MachineTypesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.MachineTypes.ToList());
    }
    public ActionResult Create()
    {
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(MachineType machineType, int LicenseId)
    {
      _db.MachineTypes.Add(machineType);
      if (LicenseId != 0)
      {
        _db.LicenseType.Add(new LicenseType() { MachineTypeId = machineType.MachineTypeId, LicenseId = LicenseId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = machineType.MachineTypeId});
    }
    public ActionResult Edit(int id)
    {
      var thisType = _db.MachineTypes.FirstOrDefault(machineType => machineType.MachineTypeId == id);
      var thisLicense = _db.LicenseType.FirstOrDefault(lt => lt.MachineTypeId == id);
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Name", thisLicense.LicenseId);
      return View(thisType);
    }

    [HttpPost]
    public ActionResult Edit(MachineType machineType, int LicenseId)
    {
      if (LicenseId != 0)
      {
        bool tf = _db.LicenseType.Any( x => x.LicenseId == LicenseId && x.MachineTypeId == machineType.MachineTypeId );
        if (!tf)
        {
          _db.LicenseType.Add(new LicenseType() { MachineTypeId = machineType.MachineTypeId, LicenseId = LicenseId });
        }
      }
      _db.Entry(machineType).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = machineType.MachineTypeId});
    }

    public ActionResult Details(int id)
    {
      List<License> licenseList = new List<License>();
      var thisType = _db.MachineTypes
        .Include(machineType => machineType.Licenses)
        .ThenInclude(join => join.License)
        .FirstOrDefault(machineType => machineType.MachineTypeId == id);
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