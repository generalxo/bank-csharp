namespace Banken01

/* NOTES
 * USER LOGIN INFO
 * USER ID: "000001AA" "000002AA" "000003AA" "000004AA" "000005AA"
 * USER PIN:  "1234" --- "5678" --- "0123" --- "4567" --- "8910"
 * 
 * <-- TO DO -->
 * Create a List with !User ID & Password!
 * Create a Login Function
 * Create a menu system --> how do i create one menu system that is able to 
 * 
 *  -- Menu Options --
 *  "Log in", "Help", "Exit"
 *  "Account & Balance", "Transfer", "Withdraw",  "Exit"
 */

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            startMenu();

        }
        public static int menuIndex = 0;

        public static string drawMenu(string[] item)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the bank");
            Console.WriteLine("Select an option");
            Console.WriteLine("");

            for (int i = 0; i < item.Length; i++)
            {
                //Console.WriteLine(item[i]);
                if (i == menuIndex)
                {
                    Console.WriteLine("[" + item[i] + "]");
                }
                else
                {
                    Console.WriteLine(item[i]);
                }
            }

            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (menuIndex == item.Length - 1) { }
                else { menuIndex++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (menuIndex <= 0) { }
                else { menuIndex--; }
            }
            else if (ckey.Key == ConsoleKey.LeftArrow)
            {
                Console.Clear();
            }
            else if (ckey.Key == ConsoleKey.RightArrow)
            {
                return item[menuIndex];
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return item[menuIndex];
            }
            else
            {
                return "";
            }
            Console.Clear();
            return "";
        }

        static void startMenu()
        {
            string[] testMenu = new string[]
            {
                "Log in", "Help", "Exit"
            };

            while (true)
            {
                string selectedMenuItem = drawMenu(testMenu);

                if (selectedMenuItem == "Log in")
                {

                    //Console.WriteLine("Log in would start here");
                    Login();
                }
                else if (selectedMenuItem == "Help")
                {
                    help();
                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

        static void bankMenu()
        {
            string[] testMenu = new string[]
            {
                "Account & Balance", "Transfer", "Withdraw", "Exit"
            };

            while (true)
            {
                string selectedMenuItem = drawMenu(testMenu);

                if (selectedMenuItem == "Account & Balance")
                {
                    Console.WriteLine("Account & Balance would start here");
                    Console.ReadKey();
                }
                else if (selectedMenuItem == "Transfer")
                {
                    Console.WriteLine("Transfer would start here");
                    Console.ReadKey();
                }
                else if (selectedMenuItem == "Withdraw")
                {
                    Console.WriteLine("Withdraw would start here");
                    Console.ReadKey();
                }
                else if (selectedMenuItem == "Exit")
                {
                    menuIndex = 0;
                    return;
                }
            }
        }

        static void Login()
        {
            int pin = 1111;
            int tries = 0;

            Console.Clear();
            Console.CursorVisible = false;

            Console.WriteLine("Welcome to the Bank");
            Console.WriteLine("");

            Console.WriteLine("Enter Your Pin");
            Int32.TryParse(Console.ReadLine(), out int input);
            while (tries < 3 && input != pin)
            {

                if (tries > 1)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Enter Correct Pin Please!");
                    Int32.TryParse(Console.ReadLine(), out input);
                    tries++;
                }

            }
            bankMenu();
        }

        static void help()
        {
            Console.Clear();
            Console.WriteLine("You can navigate the menu by using up and down arrows");
            Console.WriteLine("To select an option press the enter key or the right arrow key!");
            Console.WriteLine("");
            Console.WriteLine("To return to the Start Menu press any key");
            Console.ReadKey();
            Console.Clear();
        }

    }
}