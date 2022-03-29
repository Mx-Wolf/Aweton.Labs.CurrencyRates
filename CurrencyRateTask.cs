using Aweton.Labs.CurrencyRates.Models;
using Aweton.Labs.Services.Abstraction;
using Microsoft.Extensions.Logging;
namespace Aweton.Labs.CurrencyRates;

public class CurrencyRateTask : ITaskSource<DateTime, RateModel>
{
  private readonly DateTime m_InitialDate;
  private readonly IMiceClock  m_MiceClock;
  private readonly ILogger<CurrencyRateTask> m_Logger;
  private bool disposedValue;

  public CurrencyRateTask(DateTime initialDate, IMiceClock miceClock, ILogger<CurrencyRateTask> logger)
  {
    m_InitialDate = initialDate;
    m_MiceClock = miceClock;
    m_Logger = logger;
  }

  public async Task<IEnumerable<DateTime>> LoadTasks() => await Task.FromResult(ListDates());
  private IEnumerable<DateTime> ListDates(){
    var current = m_MiceClock.Today();
    while(current<m_InitialDate){
      yield return current;
      current = current.AddDays(1);
    }
  }

  public Task RegisterFailure(Exception exception)
  {
    m_Logger.LogDebug(exception, $"initial date: {m_InitialDate}");
    return Task.CompletedTask;
  }

  public Task RegisterResult(RateModel result)
  {
    throw new NotImplementedException();
  }

  public Task RegisterSuccess()
  {
    throw new NotImplementedException();
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposedValue)
    {
      if (disposing)
      {
        // TODO: dispose managed state (managed objects)
      }

      // TODO: free unmanaged resources (unmanaged objects) and override finalizer
      // TODO: set large fields to null
      disposedValue = true;
    }
  }

  // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
  // ~CurrencyRateTask()
  // {
  //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
  //     Dispose(disposing: false);
  // }

  public void Dispose()
  {
    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    Dispose(disposing: true);
    GC.SuppressFinalize(this);
  }
}
