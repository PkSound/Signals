using UnitsNet;

namespace Pk.Signals
{
  public struct CurrentSignal
  {
    public CurrentSignal(Waveform waveform, ElectricCurrent rms)
    {
      this.Waveform = waveform;
      this.Rms = rms;
      this.Peak = ElectricCurrent.FromAmperes(Waveform.Sinusoid.CalculatePeak(this.Rms.Amperes));
    }


    public ElectricCurrent Peak { get; }
    public ElectricCurrent Rms { get; }
    public Waveform Waveform { get; }


    public static CurrentSignal FromPeakAsSinusoid(ElectricCurrent peak)
    {
      var rms = ElectricCurrent.FromAmperes(Waveform.Sinusoid.CalculateRms(peak.Amperes));
      return new CurrentSignal(Waveform.Sinusoid, rms);
    }


    public static CurrentSignal FromRmsAsSinusoid(ElectricCurrent rms)
    {
      return new CurrentSignal(Waveform.Sinusoid, rms);
    }
  }
}
