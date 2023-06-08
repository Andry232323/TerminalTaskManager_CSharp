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

    public static ListeTask creatListTaskEmpty(string name) {
        string filePath = App.Program.projectPath+ "\\ListTask"  + "\\" + name + ".txt";
        ListeTask lt = new ListeTask(name, DateTime.Now);
        if(File.Exists(filePath)) {
            Console.WriteLine("La liste de tache " + name + " existe déjà");
        } else {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(lt.name+"~~~"+lt.id+"~~~"+lt.dtCreat+"~~~"+lt.dtLastModif);
            }
        }
        Console.WriteLine("Liste de tache créer");
        return lt;
    }
    
    public void addTask(Task t) {
        this.tasks.Add(t);
        using (StreamWriter sw = new StreamWriter(ListTaskDir + "\\" + this.name + ".txt" , true))
        {
            sw.WriteLine("#~~~" + t.name + "~~~" + t.id + "~~~" + t.dCreat + "~~~" + t.dLastModif + "~~~" + t.descr); 
        }
        this.dtLastModif = DateTime.Now;
        Console.WriteLine("La tache " + t.name + " a été ajouté à " + this.name);
    }

    //TODO : a tester
    public void removetask(string name) {
        string filePath = App.Program.projectPath + "\\ListTask\\" + this.name + ".txt";
        string[] contentFile = File.ReadAllLines(filePath);
        List<string> contentFileModifed = new List<string>();
        string[] meta = contentFile[0].Split("~~~");
        //Modification de la date de derniere modification
        meta[3] = DateTime.Now.ToString(); 
        contentFileModifed.Add(string.Join("~~~", meta));
        for (int i = 0; i < this.tasks.Count; i++)
        {
            if(this.tasks[i].name == name) {
                this.tasks.Remove(this.tasks[i]);
                this.dtLastModif = DateTime.Now;
            } else {
                contentFileModifed.Add(contentFile[i + 1]);
            }       
        }
        File.WriteAllLines(filePath, contentFileModifed);
    }

    public static ListeTask convertToListTask(string nomListe) {
        string path = App.Program.projectPath + "\\ListTask\\" + nomListe + ".txt";
        string[] lines = File.ReadAllLines(path);
        string[] metaList = lines[0].Split("~~~");
        ListeTask lt = new ListeTask(metaList[0], DateTime.Parse(metaList[2]));
        lt.dtLastModif = DateTime.Parse(metaList[3]);
        lt.id = metaList[1];
        for(int i = 1; i < lines.Length; i++) {
            string[] metaTask = lines[i].Split("~~~");
            Task t = new Task(metaTask[1], metaTask[5], DateTime.Parse(metaTask[3]));
            t.id = metaTask[2];
            t.dLastModif = DateTime.Parse(metaTask[4]);
            t.done = metaTask[0] != "#";
            lt.tasks.Add(t);
        }
        return lt;
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

}