using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PrimeFuncPack.Core.Tests;

partial class AsyncTestCaseSources
{
    private static IEnumerable<object?[]> InnerBuildSource<T>(this IEnumerable<T> source)
        =>
        source.SelectMany(InnerBuildSourceSlice);

    private static IEnumerable<object?[]> InnerBuildSourceSlice<T>(T item, int index)
    {
        yield return new object?[] { item, InnerBuildCancellationTokenNone(index) };
        yield return new object?[] { item, new CancellationToken(canceled: true) };
    }

    private static CancellationToken InnerBuildCancellationTokenNone(int index)
        =>
        (index % 4) switch
        {
            0 => default,
            1 => CancellationToken.None,
            2 => new CancellationToken(),
            _ => new CancellationToken(canceled: false),
        };
}
