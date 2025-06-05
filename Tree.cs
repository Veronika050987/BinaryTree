using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTree
{
    class Tree
    {
		public Element Root { get; protected set; }
		public Tree()
		{
			Root = null;
			Console.WriteLine($"TConstructor:{GetHashCode()}");///////
		}
		~Tree()
		{
			Console.WriteLine($"TDestructor:{GetHashCode()}");
		}


		public void Insert(int Data)
		{
			Insert(Data, Root);
		}
		void Insert(int Data, Element Root)
		{
			if (this.Root == null) this.Root = new Element(Data);
			if (Root == null) return;
			if (Data < Root.Data)
			{
				if (Root.pLeft == null) Root.pLeft = new Element(Data);
				else Insert(Data, Root.pLeft);
			}
			else
			{
				if (Root.pRight == null) Root.pRight = new Element(Data);
				else Insert(Data, Root.pRight);
			}
		}
		public int MinValue()
		{
			return MinValue(Root);
		}
		int MinValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.pLeft == null ? Root.Data : MinValue(Root.pLeft);
			//if (Root.pLeft == null) return Root.Data;
			//else return MinValue(Root.pLeft);
		}
		public int MaxValue()
		{
			return MaxValue(Root);
		}
		int MaxValue(Element Root)
		{
			if (Root == null) return 0;
			else return Root.pRight == null ? Root.Data : MaxValue(Root.pRight);
		}
		public int Count()
		{
			return Count(Root);
		}
		int Count(Element Root)
		{
			return Root == null ? 0 : Count(Root.pLeft) + Count(Root.pRight) + 1;
		}
		public int Sum()
		{
			return Sum(Root);
		}
		int Sum(Element Root)
		{
			return Root == null ? 0 : Sum(Root.pLeft) + Sum(Root.pRight) + Root.Data;
		}
		public double Avg()
		{
			return (double)Sum(Root) / Count(Root);
		}
		public int Depth()
		{
			return Depth(Root);
		}

		private int Depth(Element root)
		{
			if (root == null)
			{
				return 0;
			}

			return 1 + Math.Max(Depth(root.pLeft), Depth(root.pRight));
		}

		//int Depth(Element Root)
		//{
		//	if (Root == null) return 0;
		//	int lDepth = Depth(Root.pLeft);
		//	int rDepth = Depth(Root.pRight);
		//	return (lDepth > rDepth ? lDepth : rDepth) + 1;
		//}
		//public void DepthPrint(int Depth)
		//{
		//	DepthPrint(Root, Depth);
		//	Console.WriteLine();
		//	Console.WriteLine();
		//	Console.WriteLine();
		//}
		private void DepthPrint(Element root, int depth, int totalDepth)
		{
			if (root == null) return;

			int interval = (int)Math.Pow(2, totalDepth - depth) - 2; // Adjusted space calculation
			PrintInterval(interval);

			if (root.pLeft != null)
			{
				DepthPrint(root.pLeft, depth + 1, totalDepth);
			}

			Console.Write(root.Data + " ");

			if (root.pRight != null)
			{
				DepthPrint(root.pRight, depth + 1, totalDepth);
			}
			PrintInterval(interval);
		}
		public void TreePrint()
		{
			if (Root == null) return;
			int totalDepth = Depth();
			for (int depth = 0; depth <= totalDepth; depth++)
			{
				DepthPrint(Root, depth, totalDepth);
				Console.WriteLine(); // Print a new line after each level
			}
		}
		private void PrintInterval(int interval)
		{
			Console.Write("".PadLeft(interval * 4, ' '));
		}
		public void Print()
		{
			Print(Root);
		}
		void Print(Element Root)
		{
			if (Root != null)
			{
				Print(Root.pLeft);
				Console.Write(Root.Data + " ");
				Print(Root.pRight);
			}
		}
	}
}
