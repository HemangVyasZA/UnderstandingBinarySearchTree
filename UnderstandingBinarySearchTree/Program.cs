using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //BinarySearchTree binarySearchTree = new BinarySearchTree();
            //binarySearchTree.Insert(26);
            //binarySearchTree.Insert(19);
            //binarySearchTree.Insert(33);
            //binarySearchTree.Insert(12);
            //binarySearchTree.Insert(24);
            //binarySearchTree.Insert(31);
            //binarySearchTree.Insert(40);
            //binarySearchTree.Insert(37);
            //binarySearchTree.Insert(22);
            //binarySearchTree.Insert(25);
            //binarySearchTree.Insert(23);
            //binarySearchTree.Insert(38);
            //binarySearchTree.Insert(21);

            //binarySearchTree.InOrderTraverse();

            //Console.WriteLine($"is 37 in the tree: {binarySearchTree.Search(37)}");
            //Console.WriteLine($"is 59 in the tree: {binarySearchTree.Search(59)}");

            //Console.WriteLine("Now we are removing node 24");
            //binarySearchTree.Remove(24);
            //binarySearchTree.InOrderTraverse();

            //Console.ReadLine();

            TestOtherBinarySearchTree();
        }
        static void TestOtherBinarySearchTree()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(2);
            binarySearchTree.Insert(11);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(15);
            binarySearchTree.Insert(9);
            binarySearchTree.Insert(10);
         

            binarySearchTree.InOrderTraverse();

            Console.WriteLine("Now we are removing node 6");

            binarySearchTree.Remove(6);
            binarySearchTree.InOrderTraverse();

            Console.ReadLine();
        }
    }
}
