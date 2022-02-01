using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using TreeLib;

namespace TreeLibTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // A simple test to make sure that the test runners are working.
        public void T00_someTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        // The height of an empty tree is -1
        // The height of a non-empty tree is 1 + the height of the larger child
        public void T01_HeightOfEmptyTree()
        {
            BinaryTree<string, int> emptyTree =
                new BinaryTree<string, int>();

            Assert.AreEqual(-1, emptyTree.Height());
        }

        [TestMethod]
        public void T02_nodeHeightTest()
        {
            const int payload = 10;
            Node<string, int> myNode =
                new Node<string, int>("a", payload);
            Node<string, int>.Insert(myNode, "b", payload);
            Node<string, int>.Insert(myNode, "c", payload);
            Assert.AreEqual(2, myNode.Height());
        }

        [TestMethod]
        public void T03_smallInOrderTraversal()
        {
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            int[] payloads = new int[] { 10, 11, 12 };
            tree.Insert("j", payloads[0]);
            tree.Insert("d", payloads[1]);
            tree.Insert("r", payloads[2]);

            string[] key = new string[] { "d", "j", "r" };

            int result = 0;
            foreach (Tuple<string, int> nodeValue in tree.InOrderTraversal())
            {
                Assert.AreEqual(key[result].ToString(), nodeValue.Item1);
                Assert.AreEqual(payloads[result++], nodeValue.Item2);
            }
        }

        [TestMethod]
        public void T04_largeInOrderTraversal()
        {
            const int payload = 10;
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            tree.Insert("u", payload);
            tree.Insert("n", payload);
            tree.Insert("i", payload);
            tree.Insert("v", payload);
            tree.Insert("e", payload);
            tree.Insert("r", payload);
            tree.Insert("s", payload);
            tree.Insert("t", payload);
            tree.Insert("y", payload);
            tree.Insert("o", payload);
            tree.Insert("f", payload);
            tree.Insert("l", payload);
            tree.Insert("c", payload);
            tree.Insert("h", payload);
            tree.Insert("b", payload);
            tree.Insert("g", payload);

            // Inorder traversal of binary tree should yield a sorted order
            string name = "universtyoflchbg";
            char[] charArray = name.ToCharArray();
            Array.Sort(charArray);

            int result = 0;
            foreach (Tuple<string, int> nodeTuple in tree.InOrderTraversal())
            {
                Assert.AreEqual(charArray[result++].ToString(), nodeTuple.Item1);
                Assert.AreEqual(payload, nodeTuple.Item2);
            }
        }

        [TestMethod]
        // Convert a node to a string using the following format
        // (nodekey (leftSubtree) (rightSubtree))
        // use () for null trees, but not when both children are null
        public void T05_singleNodeToStringTest()
        {
            Node<string, int> root = new Node<string, int>("u", 10);
            StringBuilder builder = new StringBuilder();
            root.ToString(builder);
            Assert.AreEqual("(u)", builder.ToString());
        }


        public void T06_treeToStringTest()
        {
            Node<string, int> root = new Node<string, int>("u", 10);
            Node<string, int>.Insert(root, "n", 11);
            StringBuilder builder = new StringBuilder();
            root.ToString(builder);
            Assert.AreEqual("u (n) ()", builder.ToString());
        }

        [TestMethod]
        public void T07_insertAtLeafTest()
        {
            // The BinaryTree class contains a Node that is the root.
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            Assert.AreEqual("()", tree.ToString());

            tree.Insert("J", 10);
            Assert.AreEqual("(J)", tree.ToString());

            tree.Insert("E", 10);
            Assert.AreEqual("(J (E) ())", tree.ToString());

            tree.Insert("P", 10);
            Assert.AreEqual("(J (E) (P))", tree.ToString());

            tree.Insert("A", 10);
            Assert.AreEqual("(J (E (A) ()) (P))", tree.ToString());

            tree.Insert("C", 10);
            Assert.AreEqual("(J (E (A () (C)) ()) (P))", tree.ToString());

            tree.Insert("M", 10);
            Assert.AreEqual("(J (E (A () (C)) ()) (P (M) ()))",
                tree.ToString());

            tree.Insert("S", 10);
            Assert.AreEqual("(J (E (A () (C)) ()) (P (M) (S)))",
                tree.ToString());
        }

        [TestMethod]
        public void T08_rotateLeftTest()
        {
            Node<string, int> node =
                new Node<string, int>("U", 10);

            Node<string, int>.Insert(node, "N", 10);
            Node<string, int>.RotateRight(ref node);
            StringBuilder builder = new StringBuilder();
            node.ToString(builder);
            Assert.AreEqual("(N () (U))", builder.ToString());
        }

        [TestMethod]
        public void T09_rotateRightTest()
        {
            Node<string, int> node =
                new Node<string, int>("N", 10);
            Node<string, int>.Insert(node, "U", 10);
            Node<string, int>.RotateLeft(ref node);
            StringBuilder builder = new StringBuilder();
            node.ToString(builder);
            Assert.AreEqual("(U (N) ())", builder.ToString());
        }

        [TestMethod]
        public void T10_nodeInsertAtRoot()
        {
            Node<string, int> root = new
                Node<string, int>("U", 10);
            Node<string, int>.InsertAtRoot(ref root, "N", 10);
            StringBuilder builder = new StringBuilder();
            root.ToString(builder);
            Assert.AreEqual("(N () (U))", builder.ToString());

            Node<string, int>.InsertAtRoot(ref root, "I", 10);
            Node<string, int>.InsertAtRoot(ref root, "V", 10);
            Node<string, int>.InsertAtRoot(ref root, "E", 10);
            Node<string, int>.InsertAtRoot(ref root, "R", 10);
            Node<string, int>.InsertAtRoot(ref root, "S", 10);
            Node<string, int>.InsertAtRoot(ref root, "T", 10);
            builder.Clear();
            root.ToString(builder);
            Assert.AreEqual("(T (S (R (E () (I () (N))) ()) ()) (V (U) ()))",
                builder.ToString());
            Node<string, int>.InsertAtRoot(ref root, "Y", 10);
            builder.Clear();
            root.ToString(builder);
            Assert.AreEqual("(Y (T (S (R (E () (I () (N))) ()) ()) (V (U) ())) ())",
                builder.ToString());
            Node<string, int>.InsertAtRoot(ref root, "O", 10);
            builder.Clear();
            root.ToString(builder);
            Assert.AreEqual("(O (E () (I () (N))) (Y (T (S (R) ()) (V (U) ())) ()))",
                builder.ToString());
            Node<string, int>.InsertAtRoot(ref root, "F", 10);


            builder.Clear();
            //root.printConnections(builder);
            string connections = builder.ToString();

            builder.Clear();
            root.ToString(builder);
            Assert.AreEqual("(F (E) (O (I () (N)) (Y (T (S (R) ()) (V (U) ())) ())))",
                builder.ToString());


            Node<string, int>.InsertAtRoot(ref root, "L", 10);
            builder.Clear();
            root.ToString(builder);
            Assert.AreEqual("(L (F (E) (I)) (O (N) (Y (T (S (R) ()) (V (U) ())) ())))",
               builder.ToString());
            //root.printConnections(builder);
            connections = builder.ToString();
            builder.Clear();
        }
    }
}
