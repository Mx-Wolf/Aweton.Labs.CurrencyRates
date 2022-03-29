using Aweton.Labs.CurrencyRates.DbContext;
using Aweton.Labs.CurrencyRates.Models;
using Aweton.Labs.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Aweton.Labs.CurrencyRates;

public class CurrencyRateFactory : ITaskSourceFactory<DateTime, DateTime, RateModel>
{
  private readonly CurrencyDbContext m_DbContext;

  public CurrencyRateFactory(CurrencyDbContext dbContext)
  {
    m_DbContext = dbContext;
  }

  public async Task<ITaskSource<DateTime, RateModel>> CreateSource(DateTime init)
  {
    var lastKnown = await m_DbContext.CbrDailyLog.MaxAsync((e)=>(DateTime?)e.ADate);
    throw new NotImplementedException();
  }
}
