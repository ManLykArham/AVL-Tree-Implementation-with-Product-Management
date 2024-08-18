using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {
        // Field to track the repetition of items
        private int repetition = 0;

        // Stores items in an ArrayList
        private ArrayList store = new ArrayList();

        // Returns the number of repetitions of a specific item
        public int Repetition()
        {
            return repetition;
        }

        // Resets the repetition count to zero
        public int resetRepetition()
        {
            return repetition = 0;
        }

        // Stores the inserted item in the ArrayList
        private void storeTree(T item)
        {
            store.Add(item);
        }

        // Checks the repetition of an item in the store
        public void Checkrep(ref T item)
        {
            checkrep(store, ref item);
        }

        // Counts the occurrences of an item in the ArrayList
        private void checkrep(ArrayList sss, ref T item)
        {
            if (store != null)
            {
                for (int i = 0; i < store.Count; i++)
                {
                    if (item.CompareTo(store[i]) == 0)
                    {
                        repetition++;
                    }
                }
            }
        }

        // Overrides the InsertItem method to also store the item in the ArrayList
        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
            storeTree(item);
        }

        // Inserts an item into the AVL Tree and balances the tree
        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
                tree = new Node<T>(item);
            else if (item.CompareTo(tree.Data) < 0)
                insertItem(item, ref tree.Left);
            else if (item.CompareTo(tree.Data) > 0)
                insertItem(item, ref tree.Right);

            tree.BalanceFactor = height(tree.Left) - height(tree.Right);

            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);
        }

        // Rotates the subtree to the left to balance the AVL tree
        private void rotateLeft(ref Node<T> tree)
        {
            if (tree.Right.BalanceFactor > 0)
                rotateRight(ref tree.Right);

            Node<T> oldTree = tree;
            Node<T> newTree = tree.Right;
            oldTree.Right = newTree.Left;
            newTree.Left = oldTree;

            tree = newTree;
        }

        // Rotates the subtree to the right to balance the AVL tree
        private void rotateRight(ref Node<T> tree)
        {
            if (tree.Left.BalanceFactor < 0)
                rotateLeft(ref tree.Right);

            Node<T> oldTree = tree;
            Node<T> newTree = tree.Left;
            oldTree.Left = newTree.Right;
            newTree.Right = oldTree;

            tree = newTree;
        }
    }
}
