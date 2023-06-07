namespace App;
using UtilTask;
using ListeTache;
public class Program
{
    public static string projectPath = Directory.GetCurrentDirectory();
    public static void Main(string[] args) {
        State state = new State();
        UI.startDisplay();
        string inputUser;
        do
        {
            inputUser = UI.askUser();
            string[] arrInput = inputUser.Split(' ');
            UI.manageCommand(arrInput, state);
        } while (inputUser != "stop");
    }    
}

public class State {
    public ListeTask? currentLt;
}
