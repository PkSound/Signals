namespace Pk.Signals
{
  public struct VoltageSignal
  {
    public VoltageSignal(Waveform waveform) { this.Waveform = waveform; }
    public Waveform Waveform { get; }
  }
}
