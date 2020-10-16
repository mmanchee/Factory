using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
  private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index() 
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Engineer engineer, int LicenseId)
    {
      if (LicenseId != 0)
      {
        _db.EngineerLicense.Add(new EngineerLicense() { EngineerId = engineer.EngineerId, LicenseId = LicenseId });
      }
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = engineer.EngineerId });
    }
    public ActionResult Details(int id)
    {
      List<List<LicenseType>> ltList = new List<List<LicenseType>>();
      List<List<Machine>> machineList = new List<List<Machine>>();
      var thisEngineer = _db.Engineers
        .Include(engineers => engineers.Licenses)
        .ThenInclude(join => join.License)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      foreach (var license in thisEngineer.Licenses)
      {
        List<LicenseType> typeList = _db.LicenseType.Where(lt => lt.LicenseId == license.LicenseId).ToList();
        ltList.Add(typeList);
      }
      foreach (var type1 in ltList)
      {
        foreach (var type2 in type1)
        {
          List<Machine> mList = _db.Machines.Where(machines => machines.TypeId == type2.TypeId).ToList();
          machineList.Add(mList);
        }
      }
      ViewBag.Machines = machineList;
      return View(thisEngineer);
    }
    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(Engineers => Engineers.EngineerId == id);
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Name");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult Edit(Engineer engineer, int LicenseId)
    {
      if (LicenseId != 0)
      {
        bool tf = _db.EngineerLicense.Any( x => x.LicenseId == LicenseId && x.EngineerId == engineer.EngineerId );
        if (!tf)
        {
          _db.EngineerLicense.Add(new EngineerLicense() { EngineerId = engineer.EngineerId, LicenseId = LicenseId });
        }
      }
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = engineer.EngineerId });
    }
    public ActionResult Delete(int id)
    {
        var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
        return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
        _db.Engineers.Remove(thisEngineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult DeleteLicense(int joinId, int EngineerId)
    {
      var joinEntry = _db.EngineerLicense.FirstOrDefault(entry => entry.EngineerLicenseId == joinId);
      _db.EngineerLicense.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = EngineerId});
    }
  }
}