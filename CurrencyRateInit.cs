using Aweton.Labs.Services.Abstraction;
namespace Aweton.Labs.CurrencyRates;

public class CurrencyRateInit : ITaskInit<DateTime>
{
  private readonly IMiceClock m_MiceClock;

  public CurrencyRateInit(IMiceClock miceClock)
  {
    m_MiceClock = miceClock;
  }

  public Task<DateTime> ComputeInit()
  {    
    return Task.FromResult(m_MiceClock.Today().AddDays(2));
  }
}
