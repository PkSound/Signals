using Pk.Spatial.Tests;
using Shouldly;
using Xunit;

namespace Pk.Signals.Tests
{
  [Trait(TestConstants.CategoryName, TestConstants.UnitTestsTag)]
  internal class VoltageSignalTests
  {
    [Fact]
    public void DefaultsToSinusoidWaveForm()
    {
      var signalUnderTest = new VoltageSignal(Waveform.Sinusoid);
      signalUnderTest.Waveform.ShouldBe(Waveform.Sinusoid);
    }
  }
}
