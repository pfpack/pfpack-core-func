using System.Threading;
using System.Threading.Tasks;

namespace System;

partial class AsyncValueFunc
{
    public static IAsyncValueFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> From<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, CancellationToken, ValueTask<TResult>> funcAsync)
        =>
        new AsyncValueFuncImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}
