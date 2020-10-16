using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class LicensesController : Controller
  {
    private readonly FactoryContext _db;

    public LicensesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Licenses.ToList());
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(License license, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerLicense.Add(new EngineerLicense() { EngineerId = EngineerId, LicenseId = license.LicenseId });
      }
      _db.Licenses.Add(license);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = license.LicenseId});
    }
    public ActionResult Edit(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(License => License.LicenseId == id);
      return View(thisLicense);
    }

    [HttpPost]
    public ActionResult Edit(License license, int EngineerId)
    {
      if (EngineerId != 0)
      {
        bool tf = _db.EngineerLicense.Any( x => x.LicenseId == license.LicenseId && x.EngineerId == EngineerId );
        if (!tf)
        {
          _db.EngineerLicense.Add(new EngineerLicense() { EngineerId = EngineerId, LicenseId = license.LicenseId });
        }
      }
      _db.Entry(license).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = license.LicenseId});
    }

    public ActionResult Details(int id)
    {
      var thisLicense = _db.Licenses
        .Include(License => License.Engineers)
        .ThenInclude(join => join.Engineer)
        .FirstOrDefault(License => License.LicenseId == id);
      ViewBag.Machines = _db.Machines.Where(machines => machines.LicenseId == id).ToList();
      return View(thisLicense);
    }
    public ActionResult Delete(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisLicense = _db.Licenses.FirstOrDefault(license => license.LicenseId == id);
      _db.Licenses.Remove(thisLicense);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult DeleteEngineer(int joinId, int LicenseId)
    {
      var joinEntry = _db.EngineerLicense.FirstOrDefault(entry => entry.EngineerLicenseId == joinId);
      _db.EngineerLicense.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = LicenseId });
    }
  }
}