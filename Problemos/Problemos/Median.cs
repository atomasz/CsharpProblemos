using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problemos
{
    public static class Median
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var combinedLength = nums1.Length + nums2.Length;

            var needAv = combinedLength % 2 == 0;
            var nums1Index = 0;
            var nums2Index = 0;
            var lengthToGo = (combinedLength / 2);

            if (nums1.Length == 0)
            {
                if (!needAv)
                {
                    return nums2[lengthToGo];
                }
                else
                {
                    return (double)(nums2[lengthToGo] + nums2[lengthToGo - 1]) / 2;
                }
            }

            if (nums2.Length == 0)
            {
                if (!needAv)
                {
                    return nums1[lengthToGo];
                }
                else
                {
                    return (double)(nums1[lengthToGo] + nums1[lengthToGo - 1]) / 2;
                }
            }

            var firstIndexValue = 0;
            var secIndexValue = 0;
            while ((nums1Index + nums2Index) <= (lengthToGo))
            {
                if (nums1Index == nums1.Length)
                {
                    secIndexValue = firstIndexValue;
                    firstIndexValue = nums2[nums2Index];
                    nums2Index++;
                    continue;
                }
                else if (nums2Index == nums2.Length)
                {
                    secIndexValue = firstIndexValue;
                    firstIndexValue = nums1[nums1Index];
                    nums1Index++;
                    continue;
                }


                var nums1Value = nums1[nums1Index];
                var nums2Value = nums2[nums2Index];
                secIndexValue = firstIndexValue;
                if (nums1Value < nums2Value)
                {
                    firstIndexValue = nums1Value;
                    nums1Index++;
                }
                else
                {
                    firstIndexValue = nums2Value;
                    nums2Index++;
                }
            }

            if (!needAv)
                return firstIndexValue;

            return (double)(firstIndexValue + secIndexValue) / 2;
        }
    }
}
