using System.Collections.Generic;

namespace Factory.Models
{
  public class License
  {
    public License()
    {
      this.Engineers = new HashSet<EngineerLicense>();
    }

    public int LicenseId { get; set; }
    public string Name { get; set; }
    public string LicenseDate { get; set; }
    public virtual ICollection<EngineerLicense> Engineers { get; set; }
  }
}