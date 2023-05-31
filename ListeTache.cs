using UtilTask;
public class ListeTask {
    string name;
    Dt dtCreat;
    Dt dtLastModif;
    string[] tasks = {};

    public ListeTask(string name, Dt dtCreat, Dt dtLastModif) {
        this.name = name;
        this.dtCreat = dtCreat;
        this.dtLastModif = dtLastModif;
    }
}

class Task {
    private bool done = false;
    private string name;
    private string descr;

    public Task(string name, string descr) {
        this.name = name;
        this.descr = descr;
    }

    public void check() {
        done = true;
    }
}