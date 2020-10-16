using System.Collections.Generic;

namespace Factory.Models
{
  public class Type
  {
    public Type()
    {
      this.Licenses = new HashSet<LicenseType>();
    }

    public int TypeId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<LicenseType> Licenses { get; set; }
  }
}