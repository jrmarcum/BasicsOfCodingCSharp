using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class IntMinTests
{
    static int IntMin(int a, int b) => a < b ? a : b;

    [TestMethod]
    public void TestIntMinBasic()
    {
        int ans = IntMin(2, -2);
        Assert.AreEqual(-2, ans, $"IntMin(2, -2) = {ans}; want -2");
    }

    [TestMethod]
    [DataRow(0,  1,  0, DisplayName = "0,1")]
    [DataRow(1,  0,  0, DisplayName = "1,0")]
    [DataRow(2, -2, -2, DisplayName = "2,-2")]
    [DataRow(0, -1, -1, DisplayName = "0,-1")]
    [DataRow(-1, 0, -1, DisplayName = "-1,0")]
    public void TestIntMinTableDriven(int a, int b, int want)
    {
        Assert.AreEqual(want, IntMin(a, b), $"got {IntMin(a, b)}, want {want}");
    }
}
