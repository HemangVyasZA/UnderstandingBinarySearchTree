using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingBinarySearchTree
{
    public class BinarySearchTreeNode
    {
        public BinarySearchTreeNode(int Value)
        {
            Data = Value;
        }
        public int Data
        {
            get;set;
        }
        public BinarySearchTreeNode LeftNode
        {
            get;set;
        }
        public BinarySearchTreeNode RightNode
        {
            get; set;
        }
        public BinarySearchTreeNode Parent
        {
            get; set;
        }
        public int Depth
        {
            get;set;
        }
        public int Height
        {
            get; set;
        }
    }
}
