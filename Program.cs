using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			Tree tree = new Tree();
			tree.Insert(50);
			tree.Insert(25);
			tree.Insert(75);
			tree.Insert(16);
			tree.Insert(32);
			tree.Insert(70);
			tree.Insert(80);
			tree.Print();
			Console.WriteLine("\n----------------------------------\n");

			Console.WriteLine("Original Tree:");
			tree.TreePrint();

			tree.Balance();

			Console.WriteLine("\nBalanced Tree:");
			tree.TreePrint();
		}
	}
}