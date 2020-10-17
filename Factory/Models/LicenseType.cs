namespace Factory.Models
{
  public class LicenseType
  {       
    public int LicenseTypeId { get; set; }
    public int MachineTypeId { get; set; }
    public int LicenseId { get; set; }
    public MachineType MachineType { get; set; }
    public License License { get; set; }
  }
}