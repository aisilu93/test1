using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using task1;

namespace test1
{
    [TestClass]
    public class UnitTest1
    {
        MyList<int> _list;
        [TestInitialize]
        public void SetUp()
        {
            _list = new MyList<int>();
        }
        [TestCleanup]
        public void TearDown()
        {
            _list = null;
        }
        [TestMethod]
        public void TestToStr()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(4);
            Assert.AreEqual("1234", _list.ToString());
        }
        [TestMethod]
        public void TestAdd0()
        {
            Assert.AreEqual("", _list.ToString());
        }
        [TestMethod]
        public void TestAdd2()
        {
            _list.Add(1);
            _list.Add(2);
            Assert.AreEqual("12", _list.ToString());
        }
        [TestMethod]
        public void TestClearNotEmpty()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(1);
            _list.Add(2);
            _list.Add(1);
            _list.Add(2);
            _list.Clear();
            Assert.AreEqual("", _list.ToString());
        }
        [TestMethod]
        public void TestClearEmpty()
        {
            _list.Clear();
            Assert.AreEqual("", _list.ToString());
        }
        [TestMethod]
        public void TestIndexOf()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            _list.Add(5);
            _list.Add(5);
            Assert.AreEqual(2, _list.IndexOf(3));
        }
        [TestMethod]
        public void TestInsert()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            _list.Insert(2, 54);
            Assert.AreEqual("125431234", _list.ToString());
        }
        [TestMethod]
        public void TestInsert_to_back()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            _list.Insert(_list.Count, 54);
            Assert.AreEqual("123123454", _list.ToString());
        }
        [TestMethod]
        public void TestRemoveAt_first()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            _list.RemoveAt(0);
            Assert.AreEqual("231234", _list.ToString());
        }
        [TestMethod]
        public void TestRemoveAt_middle()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            _list.RemoveAt(1);
            Assert.AreEqual("131234", _list.ToString());
        }
        [TestMethod]
        public void TestRemoveAt_negative()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            Assert.AreEqual("1231234", _list.ToString());
        }
        [TestMethod]
        public void TestRemove()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            _list.Remove(3);
            Assert.AreEqual("121234", _list.ToString());
        }
        [TestMethod]
        public void TestRemove_not_exists()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            _list.Remove(30);
            Assert.AreEqual("1231234", _list.ToString());
        }
        [TestMethod]
        public void TestRemove_return_true()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            Assert.AreEqual(true,_list.Remove(3));
        }
        [TestMethod]
        public void TestRemove_return_false()
        {
            Assert.AreEqual(false, _list.Remove(3));
        }
        [TestMethod]
        public void TestRemove_return_Not_contains()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            Assert.AreEqual(false, _list.Remove(5));
        }
        [TestMethod]
        public void TestContains()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            Assert.AreEqual(true, _list.Contains(1));
        }
        [TestMethod]
        public void TestContains_not_contains()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            Assert.AreEqual(false, _list.Contains(321654));
        }
        [TestMethod]
        public void TestCopyTo()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            int[] arr=new int[_list.Count];
            _list.CopyTo(arr, 0);
            String actual="";
            foreach(int a in _list)
            {
                actual += a.ToString();
            }
            String expected = _list.ToString();
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCopyTo_negative_index()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            int[] arr = new int[_list.Count];
            _list.CopyTo(arr, -50);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCopyTo_arr_too_short()
        {
            _list.Add(1);
            _list.Add(2);
            _list.Add(3);
            _list.Add(1234);
            int[] arr = new int[2];
            _list.CopyTo(arr, 0);
        }
    }
}
