namespace App;
using UtilTask;
using ListeTache;
public class Program
{
    public static string projectPath = Directory.GetCurrentDirectory();
    public static void Main(string[] args) {
        UI.startDisplay();
        string? inputUser;
        do
        {
            inputUser =  Console.ReadLine();
        } while (inputUser != "stop");
    }    
}
