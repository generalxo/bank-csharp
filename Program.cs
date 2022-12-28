namespace Banken01

/* NOTES
 * USER LOGIN INFO
 * USER ID: "ElonTusk" "OscarGrouch" "SpikeSpiegel" "LucynaKushinada" "PeterPanda"
 * USER Password:  "test0" --- "test1" --- "test2" --- "test3" --- "test4"
 * 
 * <-- TO DO -->
 * Create a Class with User ID, Name, Password
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
            Console.Clear();
            Login();
            Console.CursorVisible = false;
            //startMenu();
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
            string? input;
            int tries = 0;

            #region Users
            User[] users = new User[5];
            users[0] = new User("ElonTusk", "Elon Tusk", "test0");
            users[1] = new User("OscarGrouch", "Oscar Grouch", "test1");
            users[2] = new User("SpikeSpiegel", "Spike Spiegel", "test2");
            users[3] = new User("LucynaKushinada", "Lucyna Kushinada", "test3");
            users[4] = new User("PeterPanda", "Peter Panda", "test4");
            #endregion



            while (tries < 3)
            {
                Console.WriteLine("Please enter user id:");
                input = Console.ReadLine();

                for (int i = 0; i < users.Length; i++)
                {
                    if (input == users[i].GetId())
                    {
                        User currentUser = users[i];

                        Console.WriteLine("");
                        Console.WriteLine("Enter Password:");
                        input = Console.ReadLine();
                        if (input == currentUser.GetPassword())
                        {
                            Console.WriteLine("Bank Menu would start here");
                            Console.ReadKey();
                            tries = 3;
                        }
                        else
                        {
                            Console.WriteLine("Please enter correct user name & password");
                        }

                    }
                }
                tries++;
            }



        }

        /*static void Login()
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
        }*/

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

    class User
    {
        private readonly string? id;
        private string? name;
        private string? password;

        public User(string? id, string? name, string? password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }

        public void Info()
        {
            Console.WriteLine("id: {0}", id);
            Console.WriteLine("name: {0}", name);
            Console.WriteLine("password: {0}", password);
            Console.WriteLine("-----");
        }

        public string GetId()
        {
            if (id == null)
            {
                return "";
            }
            else
            {
                return id;
            }
        }
        public string GetName()
        {
            if (name == null)
            {
                return "";
            }
            else
            {
                return name;
            }
        }
        public string GetPassword()
        {
            if (password == null)
            {
                return "";
            }
            else
            {
                return password;
            }
        }

    }

    class Account
    {
        private readonly string? ownerId;
        private string? accountName;
        private double balnace = 0;

        public Account(string? ownerId, string? accountName, double balnace)
        {
            this.ownerId = ownerId;
            this.accountName = accountName;
            this.balnace = balnace;
        }

        public void Info()
        {
            Console.WriteLine("ownerId: {0}", ownerId);
            Console.WriteLine("accountName: {0}", accountName);
            Console.WriteLine("balnace: {0}", balnace);
            Console.WriteLine("-----");
        }

    }

}