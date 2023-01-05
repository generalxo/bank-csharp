namespace Banken01
#region Notes
//NOTES
// USER LOGIN INFO
// USER ID: "ElonTusk" "OscarGrouch" "SpikeSpiegel" "LucynaKushinada" "PeterPanda"
// USER Password:  "test0" --- "test1" --- "test2" --- "test3" --- "test4"
#endregion Notes
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

            Console.WriteLine("");
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

                switch (selectedMenuItem)
                {
                    case "Log in":
                        Login();
                        break;

                    case "Help":
                        help();
                        break;

                    case "Exit":
                        Environment.Exit(0);
                        break;
                }

            }
        }

        public static void BankMenu(string id)
        {

            #region Account[][] Declaration
            Account[][] accounts = new Account[5][];
            accounts[0] = new Account[2];
            accounts[1] = new Account[3];
            accounts[2] = new Account[4];
            accounts[3] = new Account[5];
            accounts[4] = new Account[6];

            accounts[0][0] = new Account("ElonTusk", "Checking", 0);
            accounts[0][1] = new Account("ElonTusk", "Savings", 0);

            accounts[1][0] = new Account("OscarGrouch", "Checking", 0);
            accounts[1][1] = new Account("OscarGrouch", "Savings", 0);
            accounts[1][2] = new Account("OscarGrouch", "Retirement", 0);

            accounts[2][0] = new Account("SpikeSpiegel", "Checking", 0);
            accounts[2][1] = new Account("SpikeSpiegel", "Savings", 0);
            accounts[2][2] = new Account("SpikeSpiegel", "Retirement", 0);
            accounts[2][3] = new Account("SpikeSpiegel", "Hobby", 0);

            accounts[3][0] = new Account("LucynaKushinada", "Savings", 0);
            accounts[3][1] = new Account("LucynaKushinada", "Retirement", 0);
            accounts[3][2] = new Account("LucynaKushinada", "Checking", 0);
            accounts[3][3] = new Account("LucynaKushinada", "Hobby", 0);
            accounts[3][4] = new Account("LucynaKushinada", "Food", 0);

            accounts[4][0] = new Account("PeterPanda", "Checking", 500);
            accounts[4][1] = new Account("PeterPanda", "Savings", 500);
            accounts[4][2] = new Account("PeterPanda", "Retirement", 500);
            accounts[4][3] = new Account("PeterPanda", "Food", 500);
            accounts[4][4] = new Account("PeterPanda", "Hobby", 500);
            accounts[4][5] = new Account("PeterPanda", "Panda", 500);

            Account[] currentUser;

            #endregion Account[][] Declaration

            #region Old Loops
            //for (int i = 0; i < accounts.Length; i++)
            //{
            //    for (int j = 0; j < accounts[i].LongLength; j++)
            //    {
            //        accounts[i][j].Info();
            //    }
            //}
            //Console.ReadKey();

            //for (int h = 0; h < accounts.Length; h++)
            //{
            //    if (accounts[h][0].GetOwnerId() == id)
            //    {
            //        Console.WriteLine("<accounts.Length Loop>");
            //        Console.WriteLine("! Match Found !");

            //        Account[] currentUser = accounts[h];
            //        for (int g = 0; g < currentUser.Length; g++)
            //        {
            //            currentUser[g].Info();
            //        }

            //    }
            //}
            //Console.ReadKey();

            //for (int l = 0; l < accounts.Length; l++)
            //{
            //    if (accounts[l][0].GetOwnerId() == id)
            //    {
            //        Console.WriteLine("id: {0}", id);
            //    }
            //}
            //Console.ReadKey();

            //static void bankMenu()
            //{
            //    string[] testMenu = new string[]
            //    {
            //        "Account & Balance", "Transfer", "Withdraw", "Exit"
            //    };

            //    while (true)
            //    {
            //        string selectedMenuItem = drawMenu(testMenu);

            //        if (selectedMenuItem == "Account & Balance")
            //        {
            //            Console.WriteLine("Account & Balance would start here");
            //            Console.ReadKey();
            //        }
            //        else if (selectedMenuItem == "Transfer")
            //        {
            //            Console.WriteLine("Transfer would start here");
            //            Console.ReadKey();
            //        }
            //        else if (selectedMenuItem == "Withdraw")
            //        {
            //            Console.WriteLine("Withdraw would start here");
            //            Console.ReadKey();
            //        }
            //        else if (selectedMenuItem == "Exit")
            //        {
            //            menuIndex = 0;
            //            return;
            //        }
            //    }
            //}

            //static string Login()
            //{
            //    string? input;
            //    int tries = 0;

            //    #region Users
            //    User[] users = new User[5];
            //    users[0] = new User("ElonTusk", "Elon Tusk", "test0");
            //    users[1] = new User("OscarGrouch", "Oscar Grouch", "test1");
            //    users[2] = new User("SpikeSpiegel", "Spike Spiegel", "test2");
            //    users[3] = new User("LucynaKushinada", "Lucyna Kushinada", "test3");
            //    users[4] = new User("PeterPanda", "Peter Panda", "test4");
            //    #endregion

            //    while (tries < 3)
            //    {
            //        Console.WriteLine("-- Please Enter Your Name --");
            //        input = Console.ReadLine();

            //        for (int i = 0; i < users.Length; i++)
            //        {
            //            if (input == users[i].GetName())
            //            {
            //                User currentUser = users[i];

            //                Console.WriteLine("");
            //                Console.WriteLine("-- Enter Password --");
            //                input = Console.ReadLine();

            //                if (input == currentUser.GetPassword())
            //                {
            //                    return users[i].GetId();
            //                    //tries = 3;
            //                }

            //            }
            //        }
            //        Console.WriteLine("!! Please enter correct user name & password !!");
            //        tries++;
            //    }
            //    return "";
            //}
            #endregion Old

            string? input;

            string[] BankMenu = new string[]
            {
                "Account & Balance", "Transfer", "Withdraw", "Exit"
            };

            while (true)
            {
                string selectedMenuItem = drawMenu(BankMenu);

                switch (selectedMenuItem)
                {
                    case "Account & Balance":
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("- Accounts & Balance -");
                        Console.WriteLine("");

                        for (int i = 0; i < accounts.Length; i++)
                        {
                            if (accounts[i][0].GetOwnerId() == id)
                            {
                                currentUser = accounts[i];

                                for (int j = 0; j < accounts[i].LongLength; j++)
                                {
                                    currentUser[j].GetAccountBalance();
                                }
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Enter Any Key to Exit");
                        Console.ReadKey();
                        break;

                    case "Transfer":
                        Console.Clear();
                        Console.WriteLine(" - Transfer -");

                        for (int i = 0; i < accounts.Length; i++)
                        {
                            if (accounts[i][0].GetOwnerId() == id)
                            {
                                currentUser = accounts[i];
                                for (int j = 0; j < accounts[i].LongLength; j++)
                                {
                                    currentUser[j].DisplayAccountName();
                                }
                            }
                        }
                        Console.WriteLine("- Please Enter Account To Transfer from -");
                        input = Console.ReadLine();
                        Console.WriteLine(input);
                        Console.ReadKey();
                        break;

                    case "Withdraw":
                        Console.WriteLine("Withdraw would start here");
                        Console.ReadKey();
                        break;

                    case "Exit":
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
            users[4] = new User("PeterPanda", "aa", "aa");
            #endregion

            while (tries < 3)
            {
                Console.WriteLine("-- Please Enter Your Name --");
                input = Console.ReadLine();

                for (int i = 0; i < users.Length; i++)
                {
                    if (input == users[i].GetName())
                    {
                        User currentUser = users[i];

                        Console.WriteLine("");
                        Console.WriteLine("-- Enter Password --");
                        input = Console.ReadLine();

                        if (input == currentUser.GetPassword())
                        {
                            BankMenu(users[i].GetId());
                            tries = 3;
                        }

                    }
                }
                Console.WriteLine("!! Please enter correct user name & password !!");
                tries++;
            }
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

        public void GetAccountBalance()
        {
            Console.WriteLine(" " + accountName + ":  " + balnace + "$");
            Console.WriteLine("");
        }

        public void DisplayAccountName()
        {
            Console.WriteLine(" " + accountName);
            Console.WriteLine("");
        }

        public string GetAccountName()
        {
            if (accountName == null)
            {
                return "";
            }
            else
            {
                return accountName;
            }
        }

        public string GetOwnerId()
        {
            if (ownerId == null)
            {
                return "";
            }
            else
            {
                return ownerId;
            }
        }

    }

}