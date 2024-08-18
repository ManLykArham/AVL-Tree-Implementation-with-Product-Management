using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    class BSTree<T> : BinTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);

            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);

            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);
        }
        public void Count(ref int Items)
        {
            count(root, ref Items);
        }

        private void count(Node<T> tree, ref int Items)
        {
            if (tree != null)//!= => tree not equal to null
            {
                count(tree.Left, ref Items);
                Items = Items + 1;
                count(tree.Right, ref Items);
            }
        }
        public Boolean Contains(ref T item) //Return true if the item is contained in the BSTree, false 	  //otherwise.
        {
            return contains(root, ref item);
        }

        private Boolean contains(Node<T> tree, ref T item)
        {
            if (tree != null)//!= => tree not equal to null
            {
                if (item.CompareTo(tree.Data) == 0) //If tree.data is equal to item
                {
                    return true;
                }
                else if (item.CompareTo(tree.Data) < 0)//If item is less than tree.data, then traverse to the left subtree
                {
                    return contains(tree.Left, ref item);
                }
                else if (item.CompareTo(tree.Data) > 0)//If item is more than tree.data, then traverse to the right subtree
                {
                    return contains(tree.Right, ref item);
                }
            }
            return false;

        }

    }
}
