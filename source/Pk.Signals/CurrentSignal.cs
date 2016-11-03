using UnitsNet;

namespace Pk.Signals
{
  public struct CurrentSignal
  {
    public CurrentSignal(Waveform waveform, ElectricCurrent peak)
    {
      this.Waveform = waveform;
      this.Peak = peak;
      this.Rms = ElectricCurrent.FromAmperes(this.Waveform.CalculateRms(this.Peak.Amperes));
    }


    public ElectricCurrent Peak { get; }
    public ElectricCurrent Rms { get; }
    public Waveform Waveform { get; }


    public static CurrentSignal AsSinusoid(ElectricCurrent peak)
    {
      return new CurrentSignal(Waveform.Sinusoid, peak);
    }
  }
}
