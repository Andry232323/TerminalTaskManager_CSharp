namespace UtilTask
{
    public static class Utils {
        //TODO: a tester
        public static int creatId()
        {
            string now = DateTime.Now.ToString("yyyyMMddHHmmss");
            Random rd = new Random();
            int rdNbr = rd.Next(1000);
            return int.Parse(now + rdNbr);
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
        - Première instructions 
        ";
        public static void startDisplay() {
            Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine(instructions);
        }
    }
}