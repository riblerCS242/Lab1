using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLib
{
    public class Node<KeyType, PayloadType> where
        KeyType : IComparable<KeyType>
    {
        public Node<KeyType, PayloadType> LeftChild = null;
        public Node<KeyType, PayloadType> RightChild = null;
        public KeyType Key { get; set; }
        public PayloadType Payload { get; set; }

        public Node(KeyType key, PayloadType payload)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Tuple<KeyType, PayloadType>> InOrderTraversal(
            Node<KeyType, PayloadType> root, List<Tuple<KeyType, PayloadType>> inOrderList)
        {
            throw new NotImplementedException();
        }

        public void ToString(StringBuilder builder)
        {
            throw new NotImplementedException();
        }

        public static void RotateRight(ref Node<KeyType,
            PayloadType> root)
        {
        }

        public static void RotateLeft(ref Node<KeyType, PayloadType> root)
        {
        }

        public static void Insert(Node<KeyType, PayloadType> root,
            KeyType key, PayloadType payload)
        {
        }

        public static void InsertAtRoot(ref Node<KeyType, PayloadType> root,
        KeyType key, PayloadType payload)
        {
        }

        public int Height()
        {
            throw new NotImplementedException();
        }
    }
}
