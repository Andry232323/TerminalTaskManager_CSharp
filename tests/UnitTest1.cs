namespace tests;
using Xunit;
public class UnitTest1
{ 
    [Fact]
    public void creatIdtest()
    {
        int[] t = new int[5];
        for(int i = 0; i < 5; i++) {
            t[i] = UtilTask.Utils.creatId();
        }
    }

}