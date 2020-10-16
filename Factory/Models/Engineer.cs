using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer() //Constructor
    {
      this.Machines = new HashSet<EngineerMachine>();
    }

    public int EngineerId { get; set; }
    public string Name { get; set; }
    public string HireDate { get; set; }
    public string Contact { get; set; }
    public virtual ICollection<EngineerMachine> Machines { get; set; }
  }
}