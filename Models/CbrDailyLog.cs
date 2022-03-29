namespace Aweton.Labs.CurrencyRates.Models;

public class CbrDailyLog
{
  public CbrDailyLog(byte[] hashBytes, DateTime aDate, DateTime postedAt)
  {
    HashBytes = hashBytes;
    ADate = aDate;
    PostedAt = postedAt;
  }
  public int CbrDailyLogID { get; set; }
  public DateTime ADate { get; set; }
  public int Rows { get; set; }
  public byte[] HashBytes { get; set; }
  public DateTime PostedAt { get; set; }
}
