using UtilTask;
using ListeTache;
public class Program
{
    public static void Main(string[] args) {
        UI.startDisplay();
        string? inputUser;
        do
        {
            inputUser =  Console.ReadLine();
        } while (inputUser != "stop");
        ListeTask.creatListTaskEmpty("testList");
    }    
}
