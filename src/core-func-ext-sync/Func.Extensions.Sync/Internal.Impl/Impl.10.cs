namespace System;

internal sealed class FuncImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> : IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
{
    private readonly Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func;

    internal FuncImpl(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
        =>
        this.func = func;

    public TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        =>
        func.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
}
