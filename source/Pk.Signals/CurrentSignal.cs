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

    public static CurrentSignal FromPeakAsSinusoid(double peak)
    {
      var rms = ElectricCurrent.FromAmperes(Waveform.Sinusoid.CalculateRms(peak));
      return new CurrentSignal(Waveform.Sinusoid, rms);
    }


    public static CurrentSignal FromRmsAsSinusoid(double rms)
    {
      return CurrentSignal.FromRmsAsSinusoid(ElectricCurrent.FromAmperes(rms));
    }

    public static CurrentSignal FromPeakAsSinusoid(ElectricCurrent peak)
    {
      return  CurrentSignal.FromPeakAsSinusoid(peak.Amperes);
    }


    public static CurrentSignal FromRmsAsSinusoid(ElectricCurrent rms)
    {
      return new CurrentSignal(Waveform.Sinusoid, rms);
    }
  }
}
