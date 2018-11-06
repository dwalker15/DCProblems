using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticEvaluator
{
	class Program
	{

		static void Main(string[] args)
		{
			string[] tree = new string[7] { "*", "+", "+", "3", "2", "4", "5"};
			double result = Operate(tree);
            Debug.Assert(result == 45);

		}

		public static double Operate(string[] tree)
		{
			string root = tree[0];
			double result, leftResult, rightResult = 0;
			int leftIndex = 1;
			int rightIndex = 2;
			string[] ops = new string[4] {"+", "-", "*", "/"};
			leftResult = ops.Contains(tree[leftIndex]) ? Operate(tree, leftIndex, 2 * leftIndex + 1, 2 * leftIndex + 2) : double.Parse(tree[leftIndex]);
			rightResult = ops.Contains(tree[rightIndex]) ? Operate(tree, rightIndex, 2 * rightIndex + 1, 2 * rightIndex+ 2) : double.Parse(tree[rightIndex]);
			string op = ops.Where(x => x == root).FirstOrDefault();
			switch (op)
			{
				case "+":
					result = leftResult + rightResult;
					break;

				case "-":
					result = leftResult - rightResult;
					break;

				case "*":
					result = leftResult * rightResult;
					break;

				case "/":
					result = leftResult / rightResult;
					break;
				default:
					result = 0;
					break;
			}
			return result;
		}

		public static double Operate(string[] tree, int opIndex, int leftIndex, int rightIndex)
		{
			double result = 0;
			string root = tree[opIndex];
			double leftResult, rightResult = 0;
			string[] ops = new string[4] { "+", "-", "*", "/" };
			leftResult = ops.Contains(tree[leftIndex]) ? Operate(tree, leftIndex, 2 * leftIndex + 1, 2 * leftIndex + 2) : double.Parse(tree[leftIndex]);
			rightResult = ops.Contains(tree[rightIndex]) ? Operate(tree, rightIndex, 2 * rightIndex + 1, 2 * rightIndex + 2) : double.Parse(tree[rightIndex]);
			string op = ops.Where(x => x == root).FirstOrDefault();
			switch (op)
			{
				case "+":
					result = leftResult + rightResult;
					break;

				case "-":
					result = leftResult - rightResult;
					break;

				case "*":
					result = leftResult * rightResult;
					break;

				case "/":
					result = leftResult / rightResult;
					break;
				default:
					result = 0;
					break;
			}
			return result;


		}

	}
}
