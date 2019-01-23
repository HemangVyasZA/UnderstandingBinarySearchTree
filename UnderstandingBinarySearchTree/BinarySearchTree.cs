using System;

namespace UnderstandingBinarySearchTree
{

    public class BinarySearchTree
    {

        public BinarySearchTreeNode Root
        {
            get;
            private set;
        }
        public BinarySearchTree()
        {
            Root = null;
        }
        public BinarySearchTree(BinarySearchTreeNode RootNode)
        {
            Root = RootNode;
        }

        public void Insert(int Value)
        {
            //DO NOT forget after adding node in tree to set pointer to Root Node.
            Root = insertWithoutRecursion(Root, Value);
            updateHeightOfAllNodes(Root);
        }
        public bool Search(int value)
        {
            var node = searchRecursively(Root, value);
            return node != null;
        }
        public void Remove(int Value)
        {
            //DO NOT forget after removing node in tree to set pointer to Root Node.
            Root = removeRecursively(Root, Value);
            updateHeightOfAllNodes(Root);
        }
        public void InOrderTraverse()
        {
            inOrderTraverseRecursively(Root);
        }

        private BinarySearchTreeNode insertWithoutRecursion(BinarySearchTreeNode rootNode, int value)
        {
            BinarySearchTreeNode newNode = new BinarySearchTreeNode(value);
            
            //When tree is empty, we create root node
            if (rootNode == null)
            {
                rootNode = newNode;
                rootNode.Depth = 0;
                rootNode.Parent = null;
                return rootNode;
            }

            BinarySearchTreeNode currentNode = rootNode;

            while (true)
            {
                //if value is small, create node on left side of current node
                if (value < currentNode.Data)
                {
                    //if there is a node on left side, move forward by setting current node to that left node
                    if (currentNode.LeftNode != null)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    //if there is no node on left side, set Left node to newly created node
                    else
                    {
                        currentNode.LeftNode = newNode;
                        currentNode.LeftNode.Depth = currentNode.Depth + 1;
                        currentNode.LeftNode.Parent = currentNode;
                        break;
                    }
                }
                else//value is equal or greater than, create node on right side of current node
                {
                    //if there is a node on right side, move forward by setting current node to that right node
                    if (currentNode.RightNode != null)
                    {
                        currentNode = currentNode.RightNode;
                    }
                    //if there is no node on right side, set Right node to newly created node
                    else
                    {
                        currentNode.RightNode = newNode;
                        currentNode.RightNode.Depth = currentNode.Depth + 1;
                        currentNode.RightNode.Parent = currentNode;
                        break;
                    }
                }
              
            }
            return rootNode;//return tree, after adding new node on either left or right.
        }
        private void inOrderTraverseRecursively(BinarySearchTreeNode rootNode)
        {
            if (rootNode != null)
            {
                inOrderTraverseRecursively(rootNode.LeftNode);
                string parentData = rootNode.Parent == null ? "null" : rootNode.Parent.Data.ToString();
                Console.WriteLine($"Data is {rootNode.Data}, Parent is {parentData}, Depth is {rootNode.Depth}, Height is {rootNode.Height}");
                inOrderTraverseRecursively(rootNode.RightNode);
            }
        }

        /// <summary>
        /// Calculate height of current node. How far current node is from its furthest node.
        /// </summary>
        /// <param name="rootNode">Current Node</param>
        /// <returns>The height of the node</returns>
        private int updateHeightOfAllNodes(BinarySearchTreeNode rootNode)
        {
            if (rootNode == null)
            {
                return -1;
            }
            else
            {
                int leftHeight = updateHeightOfAllNodes(rootNode.LeftNode);
                int rightHeight = updateHeightOfAllNodes(rootNode.RightNode);
                rootNode.Height =  Math.Max(leftHeight, rightHeight) + 1;
                return rootNode.Height;
            }
           
        }
        private BinarySearchTreeNode searchRecursively(BinarySearchTreeNode node,int value)
        {
            //Stop recursion if you find value you are looking for, OR you reach end of the tree.
            if (node == null || node.Data == value)
            {
                return node;
            }
            else
            {
                if (value < node.Data)
                {
                    return searchRecursively(node.LeftNode, value);
                }
                else
                {
                    return searchRecursively(node.RightNode, value);
                }
            }
        }
        private BinarySearchTreeNode removeRecursively(BinarySearchTreeNode node, int value)
        {
            //Either tree is empty, OR you reach end of the tree.Then stop recursion here.
            if (node == null)
            {
                return node;
            }

            //Recursively, find node to be deleted.
            if (value < node.Data)
            {
                node.LeftNode = removeRecursively(node.LeftNode, value);
                node.LeftNode.Parent = node;
            }
            else if (value > node.Data)
            {
                node.RightNode = removeRecursively(node.RightNode, value);
                node.RightNode.Parent = node;
            }
            else//we have found node to be deleted
            {
                // node with only one child or no child 
                if (node.LeftNode == null)
                {
                    return node.RightNode;
                }
                else if (node.RightNode == null)
                {               
                    return node.LeftNode;
                }
               
                // node with two children: Get the inorder successor (smallest in the right subtree) 
                // OR if you want, you can get the inorder predecessor (biggest in the left subtree) 
                node.Data = minValueInRightSubTree(node.RightNode);
                node.RightNode = removeRecursively(node.RightNode, node.Data);
            }
            return node;//once you finish deletion, return updated tree.
        }
        //If you want to find min value, you need to go Left most node in the tree.
        private int minValueInRightSubTree(BinarySearchTreeNode node)
        {
            int minimumValue = node.Data;
            while (node.LeftNode != null)
            {
                minimumValue = node.LeftNode.Data;
                node = node.LeftNode;
            }
            return minimumValue;
        }
    }
}
