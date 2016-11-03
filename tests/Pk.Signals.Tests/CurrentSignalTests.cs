using System.Collections.Generic;
using System.Linq;
using Pk.Spatial.Tests;
using Shouldly;
using UnitsNet;
using Xunit;

// ReSharper disable ArrangeStaticMemberQualifier

namespace Pk.Signals.Tests
{
  [Trait(TestConstants.CategoryName, TestConstants.UnitTestsTag)]
  public class CurrentSignalTests
  {
    public static IEnumerable<object[]> AllWaveforms()
    {
      return Waveform.GetAll().Select(waveform => new object[]
                                                  {
                                                      waveform
                                                  });
    }


    [Theory]
    [InlineData(1, 0.7071067812)]
    [InlineData(23.4, 16.54629868)]
    [InlineData(100, 70.71067812)]
    public void ConstructionAsSinusoid(double peak, double rms)
    {
      var signalUnderTest = CurrentSignal.FromPeakAsSinusoid(ElectricCurrent.FromAmperes(peak));
      signalUnderTest.Peak.Amperes.ShouldBe(peak, Tolerance.ToWithinUnitsNetError);
      signalUnderTest.Rms.Amperes.ShouldBe(rms, Tolerance.ToWithinUnitsNetError);
    }


    [Theory]
    [InlineData(1, 0.7071067812)]
    [InlineData(23.4, 16.54629868)]
    [InlineData(100, 70.71067812)]
    public void ConstructionFromRmsAsSinusoid(double peak, double rms)
    {
      var signalUnderTest = CurrentSignal.FromRmsAsSinusoid(ElectricCurrent.FromAmperes(rms));
      signalUnderTest.Peak.Amperes.ShouldBe(peak, Tolerance.ToWithinUnitsNetError);
      signalUnderTest.Rms.Amperes.ShouldBe(rms, Tolerance.ToWithinUnitsNetError);
    }
 
    [Theory]
    [MemberData(nameof(CurrentSignalTests.AllWaveforms))]
    public void HoldsOntoWaveformGiven(Waveform waveform)
    {
      var signalUnderTest = new CurrentSignal(waveform, ElectricCurrent.FromAmperes(1));
      signalUnderTest.Waveform.ShouldBe(waveform);
    }
  }
}
