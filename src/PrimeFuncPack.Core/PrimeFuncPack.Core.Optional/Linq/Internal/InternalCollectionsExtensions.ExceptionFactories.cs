﻿#nullable enable

namespace System.Linq
{
    partial class InternalCollectionsExtensions
    {
        private static Exception CreateMoreThanOneElementException()
            =>
            new InvalidOperationException("The collection contains more than one element.");

        private static Exception CreateMoreThanOneMatchException()
            =>
            new InvalidOperationException("The collection contains more than one element matching the predicate.");
    }
}