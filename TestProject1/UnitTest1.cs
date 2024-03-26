using Newtonsoft.Json.Linq;
using Plecak;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() //gdy zadaen nie spelnia
        {
            Mochila problem = new Mochila(1,1);
            List<int>values = new List<int>() { 1};
            List<int>weight = new List<int>() { 10};
            Assert.AreEqual("items: \r\ntotal value: 0\r\ntotal weight: 0",problem.Solve(1).ToString());
        }
        [TestMethod]
        public void TestMethod2()  // dla konkretnego przypadku
        {
            Mochila problem = new Mochila(10, 1);
            Assert.AreEqual("items: 0 7 6 2 4 9 \r\ntotal value: 36\r\ntotal weight: 30",problem.Solve(30).ToString());
        }
        [TestMethod]
        public void TestMethod3() // gdy conajmniej jeden spelnia
        {
            Mochila problem = new Mochila(5, 1);
            Assert.AreEqual("items: 3 \r\ntotal value: 8\r\ntotal weight: 2",problem.Solve(5).ToString());
        }
        [TestMethod] 
        public void TestMethod4() // gdy nie ma przedmiotow
        {
            Mochila mochila = new Mochila(0, 123);
            Result result = mochila.Solve(10);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.mochillas_items.Count,0);
            Assert.AreEqual(result.all_values,0);
            Assert.AreEqual(result.all_weights,0);
        }
        [TestMethod]
        public void TestMethod5() //dla capacity 0
        {
            Mochila mochila = new Mochila(5, 123);
            Result result = mochila.Solve(0);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.mochillas_items.Count, 0);
            Assert.AreEqual(result.all_values, 0);
            Assert.AreEqual(result.all_weights, 0);
        }
        [TestMethod]
        public void TestMethod6() //dla 5 elementow tworzy liste 5 elementowa
        {
            Mochila mochila = new Mochila(5, 1);
            Assert.AreEqual(mochila.values.Count, 5);
        }
        [TestMethod] //random daje wartosci mniejsze od 11
        public void TestMethod7() 
        {
            Mochila mochila = new Mochila(5, 1);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(mochila.values[i] < 11);
            }
        }
        [TestMethod]
        public void TestMethod8() //random daje wartosci wieksze od 0
        {
            Mochila mochila = new Mochila(5, 1);
            for (int i = 0; i < 5; i++)
            {
                Assert.IsTrue(mochila.values[i] > 0);
            }
        }

        [TestMethod]
        public void TestMethod9() // inna kolejnosc
        {
            Mochila mochila = new Mochila(5, 1);
            mochila.values.OrderBy(x => Random.Shared.Next()).ToList();
            Mochila problem = new Mochila(5, 1);
            Assert.AreEqual(mochila.Solve(10).ToString(), problem.Solve(10).ToString());
            
        }
    }
}