using System.Collections.Generic;

namespace Factory.Models
{
  public class Record
  {
    public Record()
    {
      this.Engineers = new HashSet<Engineer>();
      this.Machines = new HashSet<Machine>();
    }
    public int RecordId { get; set; }
    public string Issue { get; set; }
    public string Type { get; set; }
    public string Details { get; set; }
    public string IssueDate { get; set; } 
    public string FinishDate { get; set; }
    public int EngineerId { get; set; }
    public int MachineId { get; set; }
    public Engineer Engineer { get; set; }
    public Machine Machine { get; set; }
    public virtual ICollection<Engineer> Engineers { get; set; }
    public virtual ICollection<Machine> Machines { get; set; }
    
  }
}