using PrimeFuncPack.UnitTest;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_02_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<decimal, string?, StructType?>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.RecordRefType), MemberType = typeof(TestCaseSources))]
    public void From_02_ThenInvoke_ExpectResultOfSourceFunc(
        RecordType sourceFuncResult)
    {
        var actual = Func.From<long, RefType, RecordType>(
            (_, _) => sourceFuncResult);

        var actualResult = actual.Invoke(long.MaxValue, PlusFifteenIdRefType);
        Assert.Equal(sourceFuncResult, actualResult);
    }
}
