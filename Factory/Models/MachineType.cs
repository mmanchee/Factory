using System.Collections.Generic;

namespace Factory.Models
{
  public class MachineType
  {
    public MachineType()
    {
      this.Licenses = new HashSet<LicenseType>();
    }

    public int MachineTypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<LicenseType> Licenses { get; set; }
  }
}