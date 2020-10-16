namespace Factory.Models
{
  public class LicenseType
  {       
    public int LicenseTypeId { get; set; }
    public int TypeId { get; set; }
    public int LicenseId { get; set; }
    public Type Type { get; set; }
    public License License { get; set; }
  }
}