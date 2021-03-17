﻿#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> Or(Func<Optional<T>> otherFactory)
            =>
            InternalHandleFoldThis(
                Pipeline.Pipe,
                otherFactory ?? throw new ArgumentNullException(nameof(otherFactory)));

        public Task<Optional<T>> OrAsync(Func<Task<Optional<T>>> otherFactoryAsync)
            =>
            InternalHandleFoldThis(
                Task.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));

        public ValueTask<Optional<T>> OrValueAsync(Func<ValueTask<Optional<T>>> otherFactoryAsync)
            =>
            InternalHandleFoldThis(
                ValueTask.FromResult,
                otherFactoryAsync ?? throw new ArgumentNullException(nameof(otherFactoryAsync)));
    }
}
