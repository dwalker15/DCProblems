using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTree
{
    class Program
    {
        // Given: sorted array
        // Goal: convert array into a height-balanced BST
        // Tests:
        //	input: [1,2,5,6,7]
        //	output: [5, 2, 6, 1, null, null, 7]
        //
        //	input: [1,2,5,6,7,9,11]
        //	output: [6, 2, 9, 1, 5, 7, 11]
        //
        //	intput: [1,2,3,4,5,6,7,8,9,10,11,12,13,14,15]
        //	output: [8, 4, 12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15] 
        static void Main(string[] args)
        {
            //int[] input1 = new int[5] { 1, 2, 5, 6, 7 };
            //int[] output1 = BalanceTree(input1);
            int[] input2 = new int[7] { 1, 2, 5, 6, 7, 9, 11 };
            int[] output2 = BalanceTree(input2);
            Debug.Assert(output2.Equals(new int[] { 6, 2, 9, 1, 5, 7, 11 }));
            int[] input3 = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] output3 = BalanceTree(input3);
        }

        public static int[] BalanceTree(int[] array)
        {

            int partition = (int)Math.Floor( array.Length / 2.0);
            int[] root = new int[1];
            int n = 0;
            int i = -1;
            while (array.Length >= n)
            {
                i++;
                n = (int)Math.Pow(2, i);
            }
            int[] tree = new int[n - 1];
            tree[0] = array[partition];
            int leftPartition = partition, rightPartition = partition;
            int[] leftHalf = array;
            int[] rightHalf = array;
            for (int j = 1; j < i; j++)
            {
                int count = (int) Math.Pow(2, j);
        
                for (int k = 0; k < count / 2; k++)
                {
                    leftHalf = leftHalf.Take(leftPartition).ToArray();
                    leftPartition = (int) Math.Floor(leftHalf.Length / 2.0);
                    tree[j + k] = leftHalf[leftPartition];

                    rightHalf = rightHalf.Skip(rightPartition + 1).Take(rightPartition).ToArray();
                    rightPartition = (int) Math.Floor(rightHalf.Length / 2.0);
                    tree[j + k + 1] = rightHalf[rightPartition];
                }
            }

            return tree;

        }

    }
}
