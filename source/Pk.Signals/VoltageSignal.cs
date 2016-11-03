using UnitsNet;
using UnitsNet.CustomCode.Extensions;
using UnitsNet.Units;

namespace Pk.Signals
{
  public struct VoltageSignal
  {
    public VoltageSignal(Waveform waveform, ElectricPotential rms)
    {
      this.Waveform = waveform;
      this.Rms = rms;
      this.Peak = ElectricPotential.FromVolts(this.Waveform.CalculatePeak(this.Rms.Volts));
      this.Gain = new AmplitudeRatio(this.Rms);
    }


    public VoltageSignal(Waveform waveform, AmplitudeRatio gain)
    {
      this.Waveform = waveform;
      this.Gain = gain;
      this.Rms = gain.ToElectricPotential();
      this.Peak = ElectricPotential.FromVolts(this.Waveform.CalculatePeak(this.Rms.Volts));
    }


    public AmplitudeRatio Gain { get; }
    public ElectricPotential Peak { get; }
    public ElectricPotential Rms { get; }
    public Waveform Waveform { get; }
    public static VoltageSignal AsSinusoid(AmplitudeRatio gain) { return new VoltageSignal(Waveform.Sinusoid, gain); }


    public static VoltageSignal FromPeakAsSinusoid(ElectricPotential peak)
    {
      var rms = ElectricPotential.FromVolts(Waveform.Sinusoid.CalculateRms(peak.Volts));
      return new VoltageSignal(Waveform.Sinusoid, rms);
    }


    public static VoltageSignal FromRmsAsSinusoid(ElectricPotential rms)
    {
      return new VoltageSignal(Waveform.Sinusoid, rms);
    }


    public static VoltageSignal Unity(Waveform waveform, AmplitudeRatioUnit unit)
    {
      var gain = AmplitudeRatio.From(0, unit);
      return new VoltageSignal(waveform, gain);
    }
  }
}
