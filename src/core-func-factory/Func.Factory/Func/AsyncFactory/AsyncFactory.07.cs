#nullable enable

using System.Threading;
using System.Threading.Tasks;

namespace System
{
    partial class Func
    {
        public static IAsyncFunc<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7, TResult>(
            Func<T1, T2, T3, T4, T5, T6, T7, CancellationToken, ValueTask<TResult>> funcAsync)
            =>
            new ImplAsyncFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(
                funcAsync ?? throw new ArgumentNullException(nameof(funcAsync)));
    }
}