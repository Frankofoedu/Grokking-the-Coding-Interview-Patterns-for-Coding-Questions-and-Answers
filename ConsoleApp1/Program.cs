using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Minimum sum of a subarray of size K: "
       + findMinSubArray(7, new int[] { 2, 1, 5, 2, 8 }));
            Console.WriteLine("Minimum sum of a subarray of size K: "
                + findMinSubArray(7, new int[] { 2, 1, 5, 2, 3, 2 }));
 Console.WriteLine("Minimum sum of a subarray of size K: "
                + findMinSubArray(8, new int[] { 3, 4, 1, 1, 6 }));

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
        public static int findMaxSumSubArray(int k, int[] arr)
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
        public static int findMinSubArray(int S, int[] arr)
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


    }
}
