namespace ListeTache;
using UtilTask;
public class ListeTask {
    string name {get; set;}
    DateTime dtCreat {get;}
    DateTime dtLastModif {get; set;}
    List<Task> tasks = new List<Task>();
    long id;

    public void addTask(Task t) {
        //TODO: verifier si t exist deja
        tasks.Add(t);
    }

    //TODO: a tester
    public ListeTask(string name, DateTime dtCreat) {
        this.name = name;
        this.id = Utils.creatId();
        this.dtCreat = dtCreat;
        this.dtLastModif = dtCreat;
    }
}

public class Task
{
    bool done { get; set; }
    string name { get; set; }
    long id {get; set;}
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

    //TODO: a tester
    public static bool taskExistId(int id, List<Task> tasks) {
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