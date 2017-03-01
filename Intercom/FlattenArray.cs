using System;
using System.Collections;
using System.Collections.Generic;

namespace Intercom
{
    public static class Interview
    {
        /// <summary>
        /// Given an array of arbitrarily nested arrays of integers, convert into a flat array of integers. 
        /// e.g. [[1,2,[3]],4] → [1,2,3,4].
        /// 
        /// Any exceptions raised will result in an empty array (see unit tests for examples).
        /// </summary>
        public static int[] FlattenArray(ArrayList toFlatten)
        {
            List<int> result = new List<int>();
            try
            {
                FlattenRecursively(toFlatten, ref result);
            }
            catch
            {
                result.Clear();
            }
            return result.ToArray();
        }

        /// <summary>
        /// Private method to flatten array. 
        /// Will recurse through an element of the array if deemed to be an array itself.
        /// If element is an integer - append to result, anything else - throw an exception.
        /// </summary>
        private static void FlattenRecursively(ArrayList toFlatten, ref List<int> result)
        {
            if (result == null)
            {
                result = new List<int>();
            }

            for (int i = 0; i < toFlatten.Count; ++i)
            {
                if (toFlatten[i] is ArrayList)
                {
                    FlattenRecursively(toFlatten[i] as ArrayList, ref result);
                }
                else if (toFlatten[i] is int)
                {
                    result.Add((int)toFlatten[i]);
                }
                else
                {
                    throw new Exception("Stop being silly, expected an arbitrary array of arrays or integers.");
                }
            }
        }
    }
}
