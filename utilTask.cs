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
- stop : arreter le programme
- taskList -c nom_liste_de_tache : créer une liste de tache
- info : renvoie des information sur l'état et la liste de tâche actuelle

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
                            state.currentLt = ListeTache.ListeTask.creatListTaskEmpty(arr[2]);
                            Console.WriteLine("Liste de tache " + state.currentLt.name + " ouverte"); 
                            break;
                        default:
                            Console.WriteLine("Commande non reconnue " + arr[1]);
                            break;
                    }
                } else if(arr[0] == "info") {
                    string info = (state.currentLt == null) ? "aucune liste de tache ouverte" : "Liste de tache actuelle : " + state.currentLt.name;
                    Console.WriteLine(info);
                } else {
                    Console.WriteLine("Commande non reconnue : " + arr[0]);
                }
            }
            
        }
    }
}