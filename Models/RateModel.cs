namespace Aweton.Labs.CurrencyRates.Models;

public class RateModel
{
  public RateModel(string userName)
  {
    UserName = userName;
  }
  public int CurrencyRatesId { get; set; }
  public int RateTypesId { get; set; }
  public int CurrencyTypesId { get; set; }
  public double Rate { get; set; }
  public DateTime ADate { get; set; }
  public string UserName { get; set; }
}