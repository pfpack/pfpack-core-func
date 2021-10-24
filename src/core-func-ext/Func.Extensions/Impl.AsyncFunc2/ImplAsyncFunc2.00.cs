#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class ImplAsyncFunc2<TResult> : IAsyncFunc<TResult>
{
    private readonly Func<TResult> func;

    internal ImplAsyncFunc2(
        Func<TResult> func)
        =>
        this.func = func;

    public Task<TResult> InvokeAsync(CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : Task.FromResult(func.Invoke());
}
