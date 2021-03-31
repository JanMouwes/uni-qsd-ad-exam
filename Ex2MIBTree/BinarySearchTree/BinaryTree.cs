using System;
using System.Collections.Generic;
using System.Linq;

namespace AD
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Cunstructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T rootItem)
        {
            root = new BinaryNode<T>(rootItem, null, null);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            int NodeSize(BinaryNode<T> node) => node != null ? 1 + NodeSize(node.left) + NodeSize(node.right) : 0;

            return NodeSize(root);
        }

        public int Height()
        {
            int NodeHeight(BinaryNode<T> node) => node != null ? 1 + Math.Max(NodeHeight(node.left), NodeHeight(node.right)) : -1;

            return NodeHeight(root);
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            if (t1.root == t2.root && t1.root != null) { throw new ArgumentException("BinaryTree t1 is the same as BinaryTree t2 and is not empty"); }

            this.root = new BinaryNode<T>(rootItem, t1.root, t2.root);

            if (t1 != this) { t1.root = null; }

            if (t2 != this) { t2.root = null; }
        }

        public string ToPrefixString()
        {
            string TraverseNode(BinaryNode<T> node)
            {
                return node != null ? $"[ {node.data} {TraverseNode(node.left)} {TraverseNode(node.right)} ]" : "NIL";
            }

            return TraverseNode(root);
        }

        public string ToInfixString()
        {
            string TraverseNode(BinaryNode<T> node)
            {
                return node != null ? $"[ {TraverseNode(node.left)} {node.data} {TraverseNode(node.right)} ]" : "NIL";
            }

            return TraverseNode(root);
        }

        public string ToPostfixString()
        {
            string TraverseNode(BinaryNode<T> node)
            {
                return node != null ? $"[ {TraverseNode(node.left)} {TraverseNode(node.right)} {node.data} ]" : "NIL";
            }

            return TraverseNode(root);
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public void TraversePreOrder(Action<BinaryNode<T>> callback)
        {
            void TraverseNode(BinaryNode<T> node)
            {
                if (node == null) return;

                callback(node);

                TraverseNode(node.left);
                TraverseNode(node.right);
            }

            TraverseNode(root);
        }

        public void TraverseInOrder(Action<BinaryNode<T>> callback)
        {
            void TraverseNode(BinaryNode<T> node)
            {
                if (node == null) return;

                TraverseNode(node.left);

                callback(node);

                TraverseNode(node.right);
            }

            TraverseNode(root);
        }

        public void TraversePostOrder(Action<BinaryNode<T>> callback)
        {
            void TraverseNode(BinaryNode<T> node)
            {
                if (node == null) return;

                TraverseNode(node.left);
                TraverseNode(node.right);

                callback(node);
            }

            TraverseNode(root);
        }

        public IEnumerable<BinaryNode<T>> Where(Predicate<BinaryNode<T>> callback)
        {
            LinkedList<BinaryNode<T>> list = new LinkedList<BinaryNode<T>>();

            TraversePreOrder(node =>
            {
                if (node == null || !callback(node)) return;

                list.AddLast(node);
            });

            return list;
        }

        public int NumberOfLeaves()
        {
            return this.Where(node => (node.left == null) && (node.right == null)).Count();
        }

        public int NumberOfNodesWithOneChild()
        {
            return this.Where(node => (node.left == null) != (node.right == null)).Count();
        }

        public int NumberOfNodesWithTwoChildren()
        {
            return this.Where(node => (node.left != null) && (node.right != null)).Count();
        }
    }
}