namespace ListeTache;
using UtilTask;
using App;
/*
Exemple de fichier texte pour enregistrer ListTask

name~~~id~~~dtCreat~~~dtlastModif
task1
task2
task3
*/


/*
Exemple de fichier ligne pour representer une Task

#~~~name~~~id~~~dtCreat~~~dtLastModif~~~descr
*/
public class ListeTask {
    public string ListTaskDir = Path.Combine(App.Program.projectPath, "ListTask");
    public string name;
    public DateTime dtCreat; 
    public DateTime dtLastModif; 
    public List<Task> tasks = new List<Task>();
    public string id;

    public ListeTask(string name, DateTime dtCreat) {
        this.name = name;
        this.id = Utils.creatId();
        this.dtCreat = dtCreat;
        this.dtLastModif = dtCreat;
    }

    public static void creatListTaskEmpty(string name) {
        string filePath = App.Program.projectPath+ "\\ListTask"  + "\\" + name + ".txt";
        if(File.Exists(filePath)) {
            Console.WriteLine("La liste de tache " + name + "existe déjà");
        } else {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                ListeTask lt = new ListeTask(name, DateTime.Now);
                sw.WriteLine(lt.name+"~~~"+lt.id+"~~~"+lt.dtCreat+"~~~"+lt.dtLastModif);
            }
        }
    }
    
    //TODO: a tester
    public void addTask(Task t) {
        tasks.Add(t);
        using (StreamWriter sw = new StreamWriter(ListTaskDir + "\\" + this.name + ".txt" , true))
        {
            sw.WriteLine("#~~~" + t.name + "~~~" + t.id + "~~~" + t.dCreat + "~~~" + t.dLastModif + "~~~" + t.descr); 
        }
        this.dtLastModif = DateTime.Now;
    }
}

public class Task
{
    public bool done;
    public string name;
    public string id;
    public string descr;
    public DateTime dCreat;
    public DateTime dLastModif;

    public Task(string name, string descr, DateTime dCreat) {
        this.name = name;
        this.descr = descr;
        this.done = false;
        this.dCreat = dCreat;
        this.id = Utils.creatId();
    }

    //TODO: a changer l'algo
    public static bool taskExistId(string id, List<Task> tasks) {
        foreach (Task t in tasks)
        {
            if(t.id == id)
                return true;
        }
        return false;
    }

    //TODO: a tester
    public static bool taskExistName(string name, List<Task> tasks) {
        foreach (Task t in tasks)
        {
            if(name.Equals(t.name)) {
                return true;
            }
        }
        return false;
    }
}