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
        DateTime date = new DateTime(2023, 5, 31);
        string filePath = App.Program.projectPath+"\\ListTask\\Mes_taches.txt";
        ListeTache.ListeTask lt = ListeTache.ListeTask.creatListTaskEmpty("Mes_taches");
        ListeTache.Task t = new ListeTache.Task("ma tache","une description", date );
        lt.addTask(t);
        Assert.True(File.Exists(filePath));
        string lastLine = File.ReadLines(filePath).LastOrDefault()??"##########";
        Assert.True(lastLine != "##########");
        Assert.Equal(lastLine,"#~~~"+t.name+"~~~"+t.id+"~~~"+t.dCreat+"~~~"+t.dLastModif+"~~~"+t.descr);
       
    }
}