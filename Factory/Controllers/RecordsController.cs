using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class RecordsController : Controller
  {
    private readonly FactoryContext _db;

    public RecordsController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Records.ToList());
    }
    public ActionResult Details(int id)
    {
      var thisRecord = _db.Records
        .Include(records => records.Engineers)
        .Include(records => records.Machines)
        .FirstOrDefault(Record => Record.RecordId == id);
        return View(thisRecord);
    }
    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Record Record)
    {
      _db.Records.Add(Record);
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = Record.RecordId});
    }
    public ActionResult Edit(int id)
    {
      var thisRecord = _db.Records.FirstOrDefault(Record => Record.RecordId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
      return View(thisRecord);
    }

    [HttpPost]
    public ActionResult Edit(Record record)
    {
      _db.Entry(record).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", null, new { id = record.RecordId});
    }

    
    public ActionResult Delete(int id)
    {
      var thisRecord = _db.Records.FirstOrDefault(record => record.RecordId == id);
      return View(thisRecord);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRecord = _db.Records.FirstOrDefault(record => record.RecordId == id);
      _db.Records.Remove(thisRecord);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}