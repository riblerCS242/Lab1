using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLib
{

    public class BinaryTree<KeyType, ValueType>
           where KeyType : IComparable<KeyType>
    {
        Node<KeyType, ValueType> Root = null;

        //public BinaryTree<KeyType, ValueType>()
        //{
        //    Root = null;
        //}
        //    |

        public string printConnections()
        {
            StringBuilder builder = new StringBuilder();
            if (Root != null)
            {
                //Root.printConnections(builder);
            }
            return builder.ToString();
        }

        public int Height()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            return builder.ToString();
        }

        public void Insert(KeyType key,
        ValueType payload)
        {
        }

        public IEnumerable<Tuple<KeyType, ValueType>> InOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public void InsertAtRoot(KeyType key, ValueType payload)
        {
        }
    }
}
