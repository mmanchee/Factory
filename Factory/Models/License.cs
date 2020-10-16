using System.Collections.Generic;

namespace Factory.Models
{
  public class License
  {
    public License()
    {
      this.Engineers = new HashSet<EngineerLicense>();
      this.MachineTypes = new HashSet<LicenseType>();
    }

    public int LicenseId { get; set; }
    public string Name { get; set; }
    public string LicenseDate { get; set; }
    public virtual ICollection<EngineerLicense> Engineers { get; set; }
    public virtual ICollection<LicenseType> MachineTypes { get; set; }
  }
}