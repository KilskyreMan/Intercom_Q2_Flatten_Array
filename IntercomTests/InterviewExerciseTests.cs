using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Intercom.Tests
{
    [TestClass()]
    public class InterviewExerciseTests
    {
        [TestMethod()]
        public void EmptyArray()
        {
            int[] emptyArray = new int[0];
            CollectionAssert.AreEqual(emptyArray, Intercom.Interview.FlattenArray(null), "Null List");
            CollectionAssert.AreEqual(emptyArray, Intercom.Interview.FlattenArray(new ArrayList()), "Empty List");
        }

        [TestMethod()]
        public void SampleTest()
        {
            // [[1,2,[3]],4] → [1,2,3,4]
            ArrayList sampleTest = new ArrayList() { new ArrayList() { 1, 2, new ArrayList() { 3 } } , 4 };

            int[] expectedResult = new int[] { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expectedResult, Intercom.Interview.FlattenArray(sampleTest));
        }

        [TestMethod()]
        public void SimpleTest()
        {
            ArrayList simpleTest = new ArrayList() { 5, 4, 3, 2, 1 };

            int[] expectedResult = new int[] { 5, 4, 3, 2, 1 };
            CollectionAssert.AreEqual(expectedResult, Intercom.Interview.FlattenArray(simpleTest));
        }

        [TestMethod()]
        public void SillyBuggerTest()
        {
            ArrayList sampleTest = new ArrayList()
            {
                new ArrayList() { 1, 2, new ArrayList() { "Three :)" } } , 4
            };

            int[] emptyArray = new int[0];
            CollectionAssert.AreEqual(emptyArray, Intercom.Interview.FlattenArray(sampleTest));
        }
    }
}