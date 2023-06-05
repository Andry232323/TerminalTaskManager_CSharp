namespace tests;
using Xunit;
public class UnitTest1
{ 
    [Fact]
    public void creatIdtest()
    {
        int l = 25;
        string[] t = new string[l];
        for(int i = 0; i < l; i++) {
            t[i] = UtilTask.Utils.creatId();
        }
        for (int i = 1; i < t.Length; i++)
        {
            for (int j = i - 1; j >= 0; j--)
            {                
                Assert.True(t[j] != t[i]);
            }
        }
    }

}