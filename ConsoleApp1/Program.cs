using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Minimum sum of a subarray of size K: "
       + FindLength("araaci", 1));
            Console.WriteLine("Minimum sum of a subarray of size K: "
                + FindLength("araaci", 1));
            Console.WriteLine("Minimum sum of a subarray of size K: "
                + FindLength("cbbebi", 10));

            Console.ReadLine();
        }

        //Given an array of positive numbers and a positive number ‘k,’
        //find the maximum sum of any contiguous subarray of size ‘k’.

        //Example 1:

        //Input: [2, 1, 5, 1, 3, 2], k=3 

        //i = 3, k =3
        //
        //Output: 9
        //Explanation: Subarray with maximum sum is [5, 1, 3].
        //Example 2:

        //Input: [2, 3, 4, 1, 5], k=2 
        //Output: 7
        //Explanation: Subarray with maximum sum is [3, 4].
        public static int FindMaxSumSubArray(int k, int[] arr)
        {
            //first loop through k number of items to get initial sum

            //loop through the remaining numbers
            //subtract the item at [i - k + 1] from the sum
            //add the item at [i] to the sum
            //if old sum is less than new sum, replace old sum with new sum
            //continue loop

            var currMaxSum = 0;
            for (int i = 0; i < k; i++)
            {
                currMaxSum += arr[i];
            }
            var tempSum = currMaxSum;
            for (int i = k; i < arr.Length; i++)
            {
                var s = arr[i - k];
                tempSum = tempSum - s + arr[i];

                if (tempSum > currMaxSum)
                {
                    currMaxSum = tempSum;
                }
            }

            return currMaxSum;
        }


        /*
         Given an array of positive numbers and a positive number ‘S,’ 
        find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’. 
        Return 0 if no such subarray exists.

            Example 1:

            Input: [2, 1, 5, 2, 3, 2], S=7 
            Output: 2
            Explanation: The smallest subarray with a sum greater than or equal to '7' is [5, 2].
            Example 2:

            Input: [2, 1, 5, 2, 8], S=7 
            Output: 1
            Explanation: The smallest subarray with a sum greater than or equal to '7' is [8].
            Example 3:

            Input: [3, 4, 1, 1, 6], S=8 
            Output: 3
            Explanation: Smallest subarrays with a sum greater than or equal to '8' are [3, 4, 1] 
            or [1, 1, 6].



         */
        public static int FindMinSubArray(int S, int[] arr)
        {
            // TODO: Write your code here
            /*
             * loop through all items
             * note i and j positions
             * note currsum
             * check if currsum >= S
                * if true
                * increment j by removing the value at j from the sum
                * set new value of currsum
             *              
             */

            int j = 0;
            int currSum = 0;
            var length = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                currSum += arr[i];

                while (currSum >= S)
                {
                    if (i - j + 1 < length)
                    {
                        length = i - j + 1;
                    }

                    currSum -= arr[j];
                    j++;
                                        
                }

            }
            return length;
        }

        /*
         * Problem 3
         * 
         * Given a string, find the length of the longest substring in it with no more than K distinct characters.

            Example 1:

            Input: String="araaci", K=2
       
            Output: 4
            Explanation: The longest substring with no more than '2' distinct characters is "araa".
            Example 2:

            Input: String="araaci", K=1
            Output: 2
            Explanation: The longest substring with no more than '1' distinct characters is "aa".
            Example 3:

            Input: String="cbbebi", K=3
            Output: 5
            Explanation: The longest substrings with no more than '3' distinct characters are "cbbeb" & "bbebi".
            Example 4:

            Input: String="cbbebi", K=10
            Output: 6
            Explanation: The longest substring with no more than '10' distinct characters is "cbbebi".
         */

        public static int FindLength(string str, int k)
        {
            /*
             * loop through each character
                * add item to dictionary 
                * check if dictionary has maximum of k distinct characters
                 
             */

            var dict = new Dictionary<char, int>();
            var windowStart = 0;
            var length = int.MinValue;
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                if (dict.ContainsKey(str[windowEnd]))
                {
                    dict[str[windowEnd]]++;
                }
                else
                {
                    dict.Add(str[windowEnd], 1);
                }

                while (dict.Count > k)
                {
                    var val = dict[str[windowStart]];

                    if (val > 1)
                    {
                        dict[str[windowStart]]--;
                    }
                    else
                    {
                        dict.Remove(str[windowStart]);
                    }


                    windowStart++;
                }

                length = Math.Max(windowEnd - windowStart + 1, length);

            }

            return length;
        }
    }
}
