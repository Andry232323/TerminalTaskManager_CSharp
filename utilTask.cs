namespace UtilTask
{
    
    public class Dt {
        private int _d;
        private int _m;
        private int _y;

        public int d => _d;
        public int m => _m;
        public int y => _y;
        public Dt(int d, int m, int y) {
            this._d = d;
            this._m = m;
            this._y = y;
        }
        public string toSrt() {
            return _d + "\\" + _m + "\\" + _y; 
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