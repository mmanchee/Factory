using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Name { get; set; }
    public int MachineTypeId { get; set; }
    public string Purchase { get; set; }
    public string SerialNumber { get; set; }
  }
}