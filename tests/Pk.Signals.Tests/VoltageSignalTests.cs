using System.Collections.Generic;
using System.Linq;
using Pk.Spatial.Tests;
using Shouldly;
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


    [Theory]
    [MemberData(nameof(VoltageSignalTests.AllWaveforms))]
    public void HoldsOntoWaveformGiven(Waveform waveform)
    {
      var signalUnderTest = new VoltageSignal(waveform);
      signalUnderTest.Waveform.ShouldBe(waveform);
    }
  }
}
