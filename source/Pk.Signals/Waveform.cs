using System;
using Headspring;
using UnitsNet;

namespace Pk.Signals
{
  public sealed class Waveform : Enumeration<Waveform>
  {
    public static readonly Waveform Sinusoid = new Waveform(0, nameof(Sinusoid), peak => peak/Math.Sqrt(2.0),
                                                            rms => rms*Math.Sqrt(2.0));

    public static readonly Waveform Sawtooth = new Waveform(3, nameof(Sinusoid), peak => peak/Math.Sqrt(3.0),
                                                            rms => rms*Math.Sqrt(3.0));

    public static readonly Waveform Square = new Waveform(1, nameof(Sinusoid), peak => peak, rms => rms);

    public static readonly Waveform Triangle = new Waveform(2, nameof(Sinusoid), peak => peak/Math.Sqrt(3.0),
                                                            rms => rms*Math.Sqrt(3.0));

    private readonly Func<ElectricPotential, ElectricPotential> calculatePeak;
    private readonly Func<ElectricPotential, ElectricPotential> calculateRms;


    private Waveform(int value, string displayName, Func<ElectricPotential, ElectricPotential> calculateRms,
                     Func<ElectricPotential, ElectricPotential> calculatePeak) : base(value, displayName)
    {
      this.calculateRms = calculateRms;
      this.calculatePeak = calculatePeak;
    }


    public ElectricPotential CalculatePeak(ElectricPotential rms) { return this.calculatePeak(rms); }
    public ElectricPotential CalculateRms(ElectricPotential peak) { return this.calculateRms(peak); }
  }
}
