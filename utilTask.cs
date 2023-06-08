using App;
using ListeTache;

namespace UtilTask
{
    public static class Utils {
        public static string creatId()
        {
            Guid uniqueId = Guid.NewGuid();
            return uniqueId.ToString();
        }
    }
    public static class UI {
        static string logo = @"
____  _____  _____  __ ___   __  __  _____  _____  _____  _____  _____  _____ 
/    \/  _  \/  ___>|  |  /  /  \/  \/  _  \/  _  \/  _  \/   __\/   __\/  _  \
\-  -/|  _  ||___  ||  _ <   |  \/  ||  _  ||  |  ||  _  ||  |_ ||   __||  _  <
 |__| \__|__/<_____/|__|__\  \__ \__/\__|__/\__|__/\__|__/\_____/\_____/\__|\_/
                                                                               
        ";

        static string instructions = @"
- select nom_de_la_liste_de_tache : ouvrir une liste de tache 
- stop : arreter le programme
- taskList -dt nom_de_la_tache : suprimer une tache de la liste actuelle
- taskList -d nom_de_la_liste : suprimer une liste
- taskList -c nom_liste_de_tache : créer une liste de tache
- taskList -a : afficher toutes les listes de taches 
- info : renvoie des information sur l'état et la liste de tâche actuelle
- display : affiche les tasks de la liste de tâche ouverte
- addTask nom_de_la_tache###description_de_la_tache : ajoute une tache a la liste des taches actuelle 

";
        public static void startDisplay() {
            Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine(instructions);
        }

        public static string askUser() {
            Console.Write("Entrez la commande => ");
            string input = Console.ReadLine()??"";
            return input;
        }

        public static void manageCommand(string[] arr, App.State state) {
            if(arr.Length < 1){
                Console.WriteLine("Commande inconnue");
                return;
            } else {
                if(arr[0] == "taskList") {
                    switch (arr[1])
                    {
                        case "-c":
                            state.currentLt = ListeTache.ListeTask.creatListTaskEmpty(convertRegularString(arr[2]));
                            Console.WriteLine("Liste de tache " + state.currentLt.name + " ouverte"); 
                            break;
                        case "-a":
                            Console.WriteLine(displayAll());
                            break;
                        case "-dt":
                            if(state.currentLt == null ) {
                                Console.WriteLine("Aucune liste de tache ouverte");
                            } else {
                                state.currentLt.removetask(arr[2]);
                            }
                            break;
                        case "-d":
                            deleteFile(arr[2]);
                            break;
                        default:
                            Console.WriteLine("Commande non reconnue " + arr[1]);
                            break;
                    }
                } else if(arr[0] == "info") {
                    string info = (state.currentLt == null) ? "aucune liste de tache ouverte" : "Liste de tache actuelle : " + state.currentLt.name;
                    Console.WriteLine(info);
                }else if(arr[0] == "display"){
                    displayCurrent(state);
                }else if(arr[0] == "select"){
                    select(arr[1], state);
                }else if(arr[0] == "addTask"){
                    if(state.currentLt == null) {
                        Console.WriteLine("aucune liste de tache ouverte");
                    } else{
                        string[] nameAndDescr = arr[1].Split("###");
                        ListeTache.Task t = new ListeTache.Task(convertRegularString(nameAndDescr[0]),convertRegularString(nameAndDescr[1]), DateTime.Now);
                        state.currentLt.addTask(t);
                    }
                } else {
                    Console.WriteLine("Commande non reconnue : " + arr[0]);
                }
            }
            
        }

        private static bool deleteFile(string name)
        {
            string filePath = App.Program.projectPath + "\\ListTask\\" + name + ".txt";
            if(!File.Exists(filePath)) {
                Console.WriteLine("Le fichier n'existe pas");
                return false;
            }
            try
            {
                File.Delete(filePath);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            Console.WriteLine("Fichier suprimé");
            return true;
        }

        private static string displayAll()
        {
            string dirPath = App.Program.projectPath + "\\ListTask\\";
            string[] ListTasks = Directory.GetFiles(dirPath, "*.txt", SearchOption.AllDirectories);
            string res = "";
            foreach (string List in ListTasks)
            {
                string fileName = Path.GetFileName(List);
                res += fileName.Substring(0, fileName.Length - 4) + "\n";
            }
            return res;
        }

        private static App.State select(string name, App.State state)
        {
            name = convertRegularString(name);
            string filePath = App.Program.projectPath + "\\ListTask\\" + name + ".txt";
            if (!File.Exists(filePath)){
                Console.WriteLine("Fichier non trouvé : " + name + ".txt");
                return state;
            }
            state.currentLt = ListeTask.convertToListTask(name);
            Console.WriteLine("Liste de tache selectionnée : " + name);
            return state;
        }

        private static string convertRegularString(string s) {
            string[] arr = s.Split("_");
            return string.Join(" ", arr);
        }

        private static void displayCurrent(State state)
        {
            if(state.currentLt == null) {
                Console.WriteLine("aucune tâche à afficher");
                return;
            }
            List<ListeTache.Task> tasks = state.currentLt.tasks;
            Console.WriteLine(@"
################## " + state.currentLt.name + @" ##################");
            Console.WriteLine(@$"Date de création de la liste : {state.currentLt.dtCreat}
Date de dernière modification de la liste : {state.currentLt.dtLastModif}
id de la liste : {state.currentLt.id}");
            foreach (ListeTache.Task t in tasks)
            {
                string check = t.done ? "[X]" : "[]";
                Console.WriteLine($@"
{check} {t.name}
        Créer le {t.dCreat} || Dernière modification {t.dLastModif}
        id : {t.id}
        Description : {t.descr}
                ");
            }
        }
    }
}