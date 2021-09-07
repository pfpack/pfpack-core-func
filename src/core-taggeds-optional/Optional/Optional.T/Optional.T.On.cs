﻿#nullable enable

using System.Threading.Tasks;

namespace System
{
    partial struct Optional<T>
    {
        public Optional<T> On(
            Func<T, Unit> onPresent,
            Func<Unit> onElse)
        {
            _ = onPresent ?? throw new ArgumentNullException(nameof(onPresent));
            _ = onElse ?? throw new ArgumentNullException(nameof(onElse));

            return InnerOn(onPresent, onElse, InnerThis);
        }

        public Optional<T> On(
            Action<T> onPresent,
            Action onElse)
        {
            _ = onPresent ?? throw new ArgumentNullException(nameof(onPresent));
            _ = onElse ?? throw new ArgumentNullException(nameof(onElse));

            return InnerOn(onPresent.InvokeThenToUnit, onElse.InvokeThenToUnit, InnerThis);
        }

        public Task<Optional<T>> OnAsync(
            Func<T, Task<Unit>> onPresentAsync,
            Func<Task<Unit>> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InnerOn(onPresentAsync, onElseAsync, InnerThisAsync);
        }

        public Task<Optional<T>> OnAsync(
            Func<T, Task> onPresentAsync,
            Func<Task> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InnerOn(onPresentAsync, onElseAsync, InnerThisAsync);
        }

        public ValueTask<Optional<T>> OnValueAsync(
            Func<T, ValueTask<Unit>> onPresentAsync,
            Func<ValueTask<Unit>> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InnerOn(onPresentAsync, onElseAsync, InnerThisValueAsync);
        }

        public ValueTask<Optional<T>> OnValueAsync(
            Func<T, ValueTask> onPresentAsync,
            Func<ValueTask> onElseAsync)
        {
            _ = onPresentAsync ?? throw new ArgumentNullException(nameof(onPresentAsync));
            _ = onElseAsync ?? throw new ArgumentNullException(nameof(onElseAsync));

            return InnerOn(onPresentAsync, onElseAsync, InnerThisValueAsync);
        }
    }
}
