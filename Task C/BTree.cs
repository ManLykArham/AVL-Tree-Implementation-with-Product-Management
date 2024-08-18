using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    class BinTree<T> where T : IComparable
    {
        protected Node<T> root; //Root declared protected so that it can be used in other child classes 
        public BinTree()  //creates an empty tree
        {
            root = null;
        }
        public BinTree(Node<T> node)  //creates a tree with node as the root
        {
            root = node;
        }

        public void InOrder(ref string buffer)
        {
            inOrder(root, ref buffer);
        }

        private void inOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)//!= => tree not equal to null
            {
                inOrder(tree.Left, ref buffer);
                buffer += tree.Data.ToString() + ",";
                inOrder(tree.Right, ref buffer);
            }
        }

        public void PreOrder(ref string buffer)
        {
            preOrder(root, ref buffer);
        }
        private void preOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)//!= => tree not equal to null
            {
                buffer += tree.Data.ToString() + ",";
                preOrder(tree.Left, ref buffer);
                preOrder(tree.Right, ref buffer);
            }
        }
        public void PostOrder(ref string buffer)
        {
            postOrder(root, ref buffer);
        }
        private void postOrder(Node<T> tree, ref string buffer)
        {
            if (tree != null)//!= => tree not equal to null
            {
                postOrder(tree.Left, ref buffer);
                postOrder(tree.Right, ref buffer);
                buffer += tree.Data.ToString() + ",";
            }
        }
        public int Height() //Return the max level of the tree
        {
            return height(root);
        }

        protected int height(Node<T> tree)//'Protected' so that another class can inherit this method.(This class child in this case, AVLTree.cs)
        {
            if (tree == null)
                return 0;
            else
                return 1 + Math.Max(height(tree.Left), height(tree.Right));
        }

    }
}
