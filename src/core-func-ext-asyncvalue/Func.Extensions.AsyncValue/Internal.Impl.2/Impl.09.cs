using System.Threading;
using System.Threading.Tasks;

namespace System;

internal sealed class AsyncValueFuncImpl2<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> : IAsyncValueFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask<TResult>> funcAsync;

    internal AsyncValueFuncImpl2(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask<TResult>> funcAsync)
        =>
        this.funcAsync = funcAsync;

    public ValueTask<TResult> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, CancellationToken cancellationToken = default)
        =>
        funcAsync.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
}
