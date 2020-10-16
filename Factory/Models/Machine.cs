using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Records = new HashSet<Record>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public string Purchase { get; set; }
    public string SerialNumber { get; set; }
    public virtual ICollection<Record> Records { get; set; }
  }
}