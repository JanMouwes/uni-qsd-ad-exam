using System.Collections.Generic;

namespace AD
{
    public class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!
        //!! Vul deze klasse met je eigen BinarySearchTree
        //!!
        //!! LET OP!
        //!! De namespace is "AD".
        //!! Waarschijnlijk zijn je uitwerkingen van het huiswerk nog "Huiswerk5"
        //!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

         public void Insert(T x)
        {
            if (this.root == null)
            {
                this.root = new BinaryNode<T>(x, null, null);

                return;
            }

            Insert(x, root);
        }

        public void Insert(T x, BinaryNode<T> node)
        {
            if (x.CompareTo(node.data) < 0)
            {
                if (node.left == null)
                {
                    node.left = new BinaryNode<T>(x, null, null);

                    return;
                }

                node = node.left;
            } else if (x.CompareTo(node.data) > 0)
            {
                if (node.right == null)
                {
                    node.right = new BinaryNode<T>(x, null, null);

                    return;
                }

                node = node.right;
            } else { throw new BinarySearchTreeDoubleKeyException(); }

            Insert(x, node);
        }

        public T FindMin(BinaryNode<T> rootNode)
        {
            if (IsEmpty()) throw new BinarySearchTreeEmptyException();

            BinaryNode<T> node = rootNode;

            while (node.left != null) { node = node.left; }

            return node.data;
        }

        public T FindMax(BinaryNode<T> rootNode)
        {
            if (IsEmpty()) throw new BinarySearchTreeEmptyException();

            BinaryNode<T> node = rootNode;

            while (node.right != null) { node = node.right; }

            return node.data;
        }

        public T FindMin() => FindMin(root);

        public T FindMax() => FindMax(root);

        public BinaryNode<T> FindNode(T value)
        {
            BinaryNode<T> node = root;

            while (node != null)
            {
                if (node.data.CompareTo(value) == 0) return node;

                node = value.CompareTo(node.data) < 0 ? node.left : node.right;
            }

            throw new BinarySearchTreeElementNotFoundException();
        }

        public BinaryNode<T> FindParent(BinaryNode<T> rootNode, T value)
        {
            BinaryNode<T> node   = rootNode;
            BinaryNode<T> parent = null;

            while (node != null)
            {
                if (node.data.CompareTo(value) == 0) { return parent; }

                parent = node;
                node   = value.CompareTo(node.data) < 0 ? node.left : node.right;
            }

            return parent;
        }

        public BinaryNode<T> FindParent(T value) => FindParent(this.root, value);

        public void RemoveMin()
        {
            if (IsEmpty()) throw new BinarySearchTreeEmptyException();

            if (this.root == null)
            {
                this.root = null;

                return;
            }
            
            BinaryNode<T> node   = root;
            BinaryNode<T> parent = null;

            while (node.left != null)
            {
                parent = node;
                node   = node.left;
            }


            RemoveNode(parent, node);
        }

        public void RemoveNode(BinaryNode<T> rootNode, BinaryNode<T> node)
        {
            BinaryNode<T> parent = FindParent(rootNode, node.data);

            if (parent == null)
            {
                this.root = null;

                return;
            }

            bool isLeft = node.data.CompareTo(parent.data) < 0;

            if (node.left != null && node.right != null)
            {
                T replacementValue = isLeft ? FindMax(node.right) : FindMin(node.left);

                Remove(node, replacementValue);
                node.data = replacementValue;

                return;
            }

            node = (node.left != null ^ node.right != null) ? node.left ?? node.right : null;

            if (isLeft) { parent.left = node; } else { parent.right = node; }
        }

        public void Remove(BinaryNode<T> rootNode, T x) => RemoveNode(rootNode, FindNode(x));
        public void Remove(T x)                         => Remove(this.root, x);

        public string InOrder()
        {
            LinkedList<T> list = new LinkedList<T>();

            TraverseInOrder(node => list.AddLast(node.data));

            return string.Join(" ", list);
        }

        public override string ToString()
        {
            return IsEmpty() ? "" : InOrder();
        }
    }
}
