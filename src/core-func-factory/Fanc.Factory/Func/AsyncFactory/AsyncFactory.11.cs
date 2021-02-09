#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class Func
    {
        public static IAsyncFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, CancellationToken, ValueTask<TResult>> func)
            =>
            new ImplAsyncFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
                func ?? throw new ArgumentNullException(nameof(func)));
    }
}