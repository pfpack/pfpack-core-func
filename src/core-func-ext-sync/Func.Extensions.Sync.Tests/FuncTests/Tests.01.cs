using PrimeFuncPack.UnitTest;
using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FuncTests
{
    [Fact]
    public void From_01_SourceFuncIsNull_ExpectArgumentNullException()
    {
        var sourceFunc = (Func<int, RecordType>)null!;
        var ex = Assert.Throws<ArgumentNullException>(() => _ = Func.From(sourceFunc));
        Assert.Equal("func", ex.ParamName);
    }

    [Theory]
    [MemberData(nameof(TestCaseSources.StructType), MemberType = typeof(TestCaseSources))]
    public void From_01_ThenInvoke_ExpectResultOfSourceFunc(
        StructType sourceFuncResult)
    {
        var actual = Func.From<object, StructType>(
            _ => sourceFuncResult);

        var actualResult = actual.Invoke(new());
        Assert.Equal(sourceFuncResult, actualResult);
    }
}
