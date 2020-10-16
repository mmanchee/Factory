namespace Factory.Models
{
  public class EngineerLicense
  {       
    public int EngineerLicenseId { get; set; }
    public int EngineerId { get; set; }
    public int LicenseId { get; set; }
    public Engineer Engineer { get; set; }
    public License License { get; set; }
  }
}