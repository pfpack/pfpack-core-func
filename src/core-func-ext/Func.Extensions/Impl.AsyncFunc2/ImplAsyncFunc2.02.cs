#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class ImplAsyncFunc2<T1, T2, TResult> : IAsyncFunc<T1, T2, TResult>
{
    private readonly Func<T1, T2, TResult> func;

    internal ImplAsyncFunc2(
        Func<T1, T2, TResult> func)
        =>
        this.func = func;

    public Task<TResult> InvokeAsync(T1 arg1, T2 arg2, CancellationToken cancellationToken = default)
        =>
        cancellationToken.IsCancellationRequested
            ? Task.FromCanceled<TResult>(cancellationToken)
            : Task.FromResult(func.Invoke(arg1, arg2));
}
