using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Models
{
  public class Record
  {
    public int RecordId { get; set; }
    public string Issue { get; set; }
    public string RecordType { get; set; }
    public string Details { get; set; }
    public string IssueDate { get; set; } 
    public string FinishDate { get; set; }
    public int EngineerId { get; set; }
    public int MachineId { get; set; }
    public static List<SelectListItem> TypeList()
    {
      List<SelectListItem> items = new List<SelectListItem>();
      items.Add(new SelectListItem { Text = "Critical", Value = "Critical"});
      items.Add(new SelectListItem { Text = "Moderate", Value = "Moderate"});
      items.Add(new SelectListItem { Text = "Minor", Value = "Minor" });
      items.Add(new SelectListItem { Text = "Maintenance", Value = "Maintenance" });
      return items;
    }
  }
}