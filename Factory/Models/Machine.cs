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
    public string Purchase { get; set; }
    public string SerialNumber { get; set; }
    public int LicenseId { get; set; }
    public virtual ICollection<Record> Records { get; set; }
  }
}