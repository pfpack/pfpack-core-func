using System.Threading.Tasks;

namespace System;

partial class AsyncFunc
{
    public static IAsyncFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> From<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TResult>> funcAsync)
        =>
        new AsyncFuncImpl2<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
}
