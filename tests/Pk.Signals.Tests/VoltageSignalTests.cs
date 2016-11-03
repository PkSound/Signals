using System.Collections.Generic;
using System.Linq;
using Pk.Spatial.Tests;
using Shouldly;
using UnitsNet;
using UnitsNet.Units;
using Xunit;

// ReSharper disable ArrangeStaticMemberQualifier

namespace Pk.Signals.Tests
{
  [Trait(TestConstants.CategoryName, TestConstants.UnitTestsTag)]
  public class VoltageSignalTests
  {
    public static IEnumerable<object[]> AllWaveforms()
    {
      return Waveform.GetAll().Select(waveform => new object[]
                                                  {
                                                      waveform
                                                  });
    }


    [Fact]
    public void ConstructionFromGain()
    {
      var signalUnderTest = new VoltageSignal(Waveform.Sinusoid, AmplitudeRatio.FromDecibelVolts(0));
      signalUnderTest.Peak.Volts.ShouldBe(1.414213562, Tolerance.ToWithinUnitsNetError);

      signalUnderTest = VoltageSignal.Unity(Waveform.Sinusoid, AmplitudeRatioUnit.DecibelUnloaded);
      signalUnderTest.Peak.Volts.ShouldBe(1.095445116, Tolerance.ToWithinUnitsNetError);

      signalUnderTest = VoltageSignal.AsSinusoid(AmplitudeRatio.FromDecibelsUnloaded(1));
      signalUnderTest.Rms.Volts.ShouldBe(0.869111757, Tolerance.ToWithinUnitsNetError);
    }


    [Theory]
    [MemberData(nameof(VoltageSignalTests.AllWaveforms))]
    public void HoldsOntoWaveformGiven(Waveform waveform)
    {
      var signalUnderTest = new VoltageSignal(waveform, ElectricPotential.FromVolts(1));
      signalUnderTest.Waveform.ShouldBe(waveform);
    }


    [Fact]
    public void ReportsGainOfSignal()
    {
      var signalUnderTest = VoltageSignal.FromPeakAsSinusoid(ElectricPotential.FromVolts(3.0));
      signalUnderTest.Gain.DecibelsUnloaded.ShouldBe(8.750612638, Tolerance.ToWithinUnitsNetError);
      signalUnderTest.Peak.Volts.ShouldBe(3.0);


      signalUnderTest = VoltageSignal.FromRmsAsSinusoid(1);
      signalUnderTest.Gain.DecibelsUnloaded.ShouldBe(2.218487499, Tolerance.ToWithinUnitsNetError);
      signalUnderTest.Rms.Volts.ShouldBe(1);
    }
  }
}
