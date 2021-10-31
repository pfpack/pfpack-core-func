#nullable enable

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> From<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        =>
        new AsyncFuncImpl3<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            func ?? throw new ArgumentNullException(nameof(func)));
}
