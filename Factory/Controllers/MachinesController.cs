using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
  private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index() 
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = machine.MachineId });
    }
    public ActionResult Details(int id)
    {
      List<List<EngineerLicense>> elList = new List<List<EngineerLicense>>();
      List<List<Engineer>> engineerList = new List<List<Engineer>>();
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      var thisType = _db.Types
        .Include(types => types.Licenses)
        .ThenInclude(join => join.License)
        .FirstOrDefault(types => types.TypeId == thisMachine.TypeId);
      foreach (var license in thisType.Licenses)
      {
        List<EngineerLicense> licenseList = _db.EngineerLicense.Where(el => el.LicenseId == license.LicenseId).ToList();
        elList.Add(licenseList);
      }
      foreach (var license1 in elList)
      {
        foreach (var license2 in license1)
        {
          List<Engineer> eList = _db.Engineers.Where(engineers => engineers.EngineerId == license2.EngineerId).ToList();
          engineerList.Add(eList);
        }
      }
      ViewBag.Engineers = engineerList;
      return View(thisMachine);
    }
    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.LicenseId = new SelectList(_db.Licenses, "LicenseId", "Name");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = machine.MachineId });
    }
    public ActionResult Delete(int id)
    {
        var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
        return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
        _db.Machines.Remove(thisMachine);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}