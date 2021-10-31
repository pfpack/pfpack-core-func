#nullable enable

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T1, T2, T3, T4, T5, T6, T7, TResult> From<T1, T2, T3, T4, T5, T6, T7, TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        =>
        new AsyncFuncImpl3<T1, T2, T3, T4, T5, T6, T7, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}
