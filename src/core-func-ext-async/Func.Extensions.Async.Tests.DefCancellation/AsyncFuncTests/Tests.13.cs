using PrimeFuncPack.UnitTest;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncFuncTests
{
    [Fact]
    public void From_13_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<long, RecordType, string?, object?, RecordType?, object?, RecordType, DateTimeOffset, object, DateTimeKind, string, int, RecordType?, CancellationToken, Task<long>>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = AsyncFunc.From(sourceFunc));
        Assert.Equal("funcAsync", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(AsyncTestCaseSources.RefType), MemberType = typeof(AsyncTestCaseSources))]
    public async Task From_13_ThenInvokeAsync_ExpectResultOfSourceFunc(
        RefType sourceFuncResult)
    {
        var actual = AsyncFunc.From<decimal, StructType, RefType?, RecordType?, long, int, RefType, DateTimeKind, RefType, object?, string, RecordType, string?, RefType>(
            (_, _, _, _, _, _, _, _, _, _, _, _, _, _) => Task.FromResult(sourceFuncResult));

        var actualResult = await actual.InvokeAsync(
            decimal.One, SomeTextStructType, PlusFifteenIdRefType, ZeroIdNullNameRecord, default, default, MinusFifteenIdRefType, DateTimeKind.Unspecified, null!, new(), ThreeWhiteSpacesString, MinusFifteenIdNullNameRecord, EmptyString);

        Assert.Equal(sourceFuncResult, actualResult);
    }
}
