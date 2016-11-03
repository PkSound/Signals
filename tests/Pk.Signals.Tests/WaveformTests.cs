using System.Collections.Generic;
using Pk.Spatial.Tests;
using Shouldly;
using UnitsNet;
using Xunit;

namespace Pk.Signals.Tests
{
  [Trait(TestConstants.CategoryName, TestConstants.UnitTestsTag)]
  public class WaveformTests
  {
    private const double RmsTolerance = 1E-9;

    public static readonly IEnumerable<object[]> RmsExpectations = new[]
                                                                   {
                                                                       new object[] {Waveform.Sawtooth, 9.123456789, 5.267430233}, 
                                                                       new object[] {Waveform.Sinusoid, 3.568985612375,2.523653928 }, 
                                                                       new object[] {Waveform.Square, 1.000000025, 1.000000025}, 
                                                                       new object[] {Waveform.Triangle, 78.468523458,45.303823141 }, 
                                                                   };

    [Theory]
    [MemberData(nameof(RmsExpectations))]
    public void ShouldCalculateRms(Waveform waveform, double peakVoltage, double expectedRmsVoltage)
    {
      var result = waveform.CalculateRms(ElectricPotential.FromVolts(peakVoltage));
      result.Volts.ShouldBe(expectedRmsVoltage, RmsTolerance);
    }
  }
}
