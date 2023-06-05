namespace ListeTache;
using UtilTask;

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
    string name {get; set;}
    DateTime dtCreat {get;}
    DateTime dtLastModif {get; set;}
    List<Task> tasks = new List<Task>();
    string id;

    public void addTask(Task t) {
        if(Task.taskExistName(t.name, this.tasks))
        tasks.Add(t);
    }

    private ListeTask(string name, DateTime dtCreat) {
        this.name = name;
        this.id = Utils.creatId();
        this.dtCreat = dtCreat;
        this.dtLastModif = dtCreat;
    }

    // TODO: a tester
    public static void creatListTaskEmpty(string name) {
        string path = name + ".txt";
        if(File.Exists(path)) {
            Console.WriteLine("La liste de tache " + name + "existe déjà");
        } else {
            using (StreamWriter sw = new StreamWriter(path))
            {
                ListeTask lt = new ListeTask(name, DateTime.Now.Date);
                sw.WriteLine(lt.name+"~~~"+lt.id+"~~~"+lt.dtCreat+"~~~"+lt.dtLastModif);
            }
        }
    }
}

public class Task
{
    bool done { get; set; }
    public string name { get; set; }
    string id {get; set;}
    string descr { get; set; }
    DateTime dCreat {get; set;}
    DateTime dLastModif { get; set; }

    private Task(string name, string descr, DateTime dCreat) {
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

    public Task creatTask(string name, string descr, DateTime dCreat) {
        Task t = new Task(name, descr, dCreat);
        t.id = Utils.creatId();
        t.dLastModif = dCreat;
        return t; 
    }

}