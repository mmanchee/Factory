using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer() //Constructor
    {
      this.Licenses = new HashSet<EngineerLicense>();
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public string HireDate { get; set; }
    public string Contact { get; set; }
    public virtual ICollection<EngineerLicense> Licenses { get; set; }
  }
}