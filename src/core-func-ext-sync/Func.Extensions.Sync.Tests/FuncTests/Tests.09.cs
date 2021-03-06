using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_09_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<RefType?, RecordType, RecordType?, DateTimeOffset, object, string, StructType?, string?, int, StructType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.RecordRefType), MemberType = typeof(TestCaseSources))]
    public void From_09_ThenInvoke_ExpectResultOfSourceFunc(
        RecordType sourceFuncResult)
    {
        var actual = Func.From<int, RecordType?, RefType?, long, decimal, RefType?, object, int, string?, RecordType>(
            (_, _, _, _, _, _, _, _, _) => sourceFuncResult);

        var actualResult = actual.Invoke(
            PlusFifteen, default, MinusFifteenIdRefType, long.MinValue, decimal.One, ZeroIdRefType, PlusFifteenIdLowerSomeStringNameRecord, int.MinValue, TabString);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
