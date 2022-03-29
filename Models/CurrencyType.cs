namespace Aweton.Labs.CurrencyRates.Models;

public class CurrencyType{
  public CurrencyType(string currCodeChr)
  {
    CurrCodeChr = currCodeChr;
  }
  public int CurrencyTypesId {get;set;}
  public string CurrCodeChr {get;set;}
}
