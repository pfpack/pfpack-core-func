#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]
        public void ToString_SourceIsDefault_ExpectResultOfDefaultFailreToString()
        {
            var source = default(Result<SomeRecord, StructType>);
            var actual = source.ToString();

            var expected = default(StructType).ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_SourceIsSuccessAndValueIsNull_ExpectEmptyString()
        {
            var source = Result<object?, SomeError>.Success(null);

            var actual = source.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_SourceIsSuccessAndValueToStringReturnsNull_ExpectEmptyString()
        {
            var sourceValue = new StubToStringRefType(null);
            var source = new Result<StubToStringRefType, StructType>(sourceValue);

            var actual = source.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToString_SourceIsSuccessAndValueToStringDoesNotReturnNull_ExpectResultOfValueToString(
            string resultOfValueToString)
        {
            var sourceValue = new StubToStringStructType(resultOfValueToString);
            var source = Result<StubToStringStructType, SomeError>.Success(sourceValue);

            var actual = source.ToString();
            Assert.AreEqual(resultOfValueToString, actual);
        }

        [Test]
        public void ToString_SourceIsFailureAndValueToStringReturnsNull_ExpectEmptyString()
        {
            var sourceValue = new StubToStringStructType(null);
            var source = Result<RefType?, StubToStringStructType>.Failure(sourceValue);

            var actual = source.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToString_SourceIsFailureAndValueToStringDoesNotReturnNull_ExpectResultOfValueToString(
            string resultOfValueToString)
        {
            var sourceValue = new StubToStringStructType(resultOfValueToString);
            var source = new Result<StructType, StubToStringStructType>(sourceValue);

            var actual = source.ToString();
            Assert.AreEqual(resultOfValueToString, actual);
        }
    }
}
