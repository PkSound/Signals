using UnitsNet;
using UnitsNet.CustomCode.Extensions;
using UnitsNet.Units;

namespace Pk.Signals
{
  public struct VoltageSignal
  {
    public VoltageSignal(Waveform waveform, ElectricPotential peak)
    {
      this.Peak = peak;
      this.Waveform = waveform;
      this.Rms = ElectricPotential.FromVolts(this.Waveform.CalculateRms(this.Peak.Volts));
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


    public static VoltageSignal AsSinusoid(ElectricPotential peak)
    {
      return new VoltageSignal(Waveform.Sinusoid, peak);
    }


    public static VoltageSignal Unity(Waveform waveform, AmplitudeRatioUnit unit)
    {
      var gain = AmplitudeRatio.From(0, unit);
      return new VoltageSignal(waveform, gain);
    }

    public static VoltageSignal AsSinusoid(AmplitudeRatio gain)
    {
      return new VoltageSignal(Waveform.Sinusoid, gain);
    }
  }
}
