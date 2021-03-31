using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AD
{
    public class MIBTree : BinarySearchTree<MIBNode>
    {
        public MIBTree()
        {
            Insert(new MIBNode("1.3.6.1.4.1.9", "cisco"));
            Insert(new MIBNode("1.3.6.1.1.1.1", "system"));
            Insert(new MIBNode("1.3.6", "dod"));
            Insert(new MIBNode("1.3.6.1.1.1.4", "ip"));
            Insert(new MIBNode("1.3.6.1.3", "experimental"));
            Insert(new MIBNode("1.3.6.1.4.1", "enterprise"));
            Insert(new MIBNode("1.3.6.1.1.1.2", "interfaces"));
            Insert(new MIBNode("1.3.6.1.1", "directory"));
            Insert(new MIBNode("1.3", "org"));
            Insert(new MIBNode("1.3.6.1.4.1.2636", "juniperMIB"));
            Insert(new MIBNode("1.3.6.1.4.1.311", "microsoft"));
            Insert(new MIBNode("1.3.6.1", "internet"));
            Insert(new MIBNode("1", "iso"));
            Insert(new MIBNode("1.3.6.1.4", "private"));
            Insert(new MIBNode("1.3.6.1.1.1", "mib-2"));
            Insert(new MIBNode("1.3.6.1.2", "mgmt"));
        }

        public MIBNode FindNode(string oid)
        {
            BinaryNode<MIBNode> current = this.root;

            if (current == null) return null;

            while (true)
            {
                if (oid.CompareTo(current.data.oid) < 0)
                {
                    if (current.left == null) return null;

                    current = current.left;
                } else if (oid.CompareTo(current.data.oid) > 0)
                {
                    if (current.right == null) return null;

                    current = current.right;
                } else { return current.data; }
            }
        }

        public bool AllNodesAvailable(string oid)
        {
            bool Exists(string oidToFind)
            {
                return FindNode(oidToFind) != null;
            }

            Queue<string> splitOid = new Queue<string>(oid.Split("."));
            string currentOid = splitOid.Dequeue();

            while (splitOid.Count > 0)
            {
                if (!Exists(currentOid)) { return false; }

                currentOid += "." + splitOid.Dequeue();
            }

            return Exists(currentOid);
        }
    }
}