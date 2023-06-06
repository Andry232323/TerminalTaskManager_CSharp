namespace tests;
using Xunit;
using App;
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

    [Fact]
    public void TestCreatListTaskEmpty()
    {
        ListeTache.ListeTask.creatListTaskEmpty("test1");
        Assert.True(File.Exists(App.Program.projectPath+"\\ListTask\\test1.txt"));
        File.Delete(App.Program.projectPath+"\\ListTask\\test1.txt");
    }

    [Fact]
    public void TestAddTask()
    {
        DateTime now = DateTime.Now;
        ListeTache.Task t = new ListeTache.Task("maTache", "une description", now);
        ListeTache.ListeTask lt = new ListeTache.ListeTask("test", now);
        lt.addTask(t);
        List<ListeTache.Task> exp =  new List<ListeTache.Task>();
        exp.Add(t);
       Assert.True(lt.tasks.SequenceEqual(exp));
    }
}