using System;
using Headspring;

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

    private readonly Func<double, double> calculatePeak;
    private readonly Func<double, double> calculateRms;


    private Waveform(int value, string displayName, Func<double, double> calculateRms,
                     Func<double, double> calculatePeak) : base(value, displayName)
    {
      this.calculateRms = calculateRms;
      this.calculatePeak = calculatePeak;
    }


    public double CalculatePeak(double rms) { return this.calculatePeak(rms); }
    public double CalculateRms(double peak) { return this.calculateRms(peak); }
  }
}
