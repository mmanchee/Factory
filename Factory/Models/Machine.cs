using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Engineers = new HashSet<EngineerMachine>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public string Purchase { get; set; }
    public string SerialNumber { get; set; }
    public int MachineType { get; set; }
    public virtual ICollection<EngineerMachine> Engineers { get; set; }
  }
}