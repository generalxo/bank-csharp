namespace Banken01
#region Notes
//NOTES
// USER LOGIN INFO
// USER ID:       "ElonTusk" "OscarGrouch" "SpikeSpiegel" "LucynaKushinada"   "aa"
// USER Password:  "test0" ---  "test1"  ---  "test2"   ---    "test3"   ---  "aa"
#endregion Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            StartMenu();
        }

        public static int menuIndex = 0;

        public static string DrawMenu(string[] item)
        {
            //Method takes in an array of strings and displays them. The int menuIndex indicates which item the user is selecting
            //Method allows user to navigare the array of strings and select a string and reurns it
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("Welcome to the bank");
            Console.WriteLine("Please select an option");
            Console.WriteLine("");

            for (int i = 0; i < item.Length; i++)
            {
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

        static void StartMenu()
        {

            #region Account[][] Declarations for all users 

            Account[][] accounts = new Account[5][];
            accounts[0] = new Account[2];
            accounts[1] = new Account[3];
            accounts[2] = new Account[4];
            accounts[3] = new Account[5];
            accounts[4] = new Account[6];

            accounts[0][0] = new Account("ElonTusk", "Checking", "test0", 500000000M);
            accounts[0][1] = new Account("ElonTusk", "Savings", "test0", 1000000000000M);

            accounts[1][0] = new Account("OscarGrouch", "Checking", "test1", 50.58M);
            accounts[1][1] = new Account("OscarGrouch", "Savings", "test1", 1M);
            accounts[1][2] = new Account("OscarGrouch", "Retirement", "test1", 0M);

            accounts[2][0] = new Account("SpikeSpiegel", "Checking", "test2", 3000102.71M);
            accounts[2][1] = new Account("SpikeSpiegel", "Savings", "test2", 0.78M);
            accounts[2][2] = new Account("SpikeSpiegel", "Retirement", "test2", 500M);
            accounts[2][3] = new Account("SpikeSpiegel", "Hobby", "test2", 50500M);

            accounts[3][0] = new Account("LucynaKushinada", "Checking", "test3", 22201M);
            accounts[3][1] = new Account("LucynaKushinada", "Savings", "test3", 5050010M);
            accounts[3][2] = new Account("LucynaKushinada", "Retirement", "test3", 70M);
            accounts[3][3] = new Account("LucynaKushinada", "Hobby", "test3", 10000M);
            accounts[3][4] = new Account("LucynaKushinada", "Food", "test3", 7000M);

            accounts[4][0] = new Account("aa", "Checking", "aa", 11000.98M);
            accounts[4][1] = new Account("aa", "Savings", "aa", 390000M);
            accounts[4][2] = new Account("aa", "Retirement", "aa", 47000M);
            accounts[4][3] = new Account("aa", "Food", "aa", 2000M);
            accounts[4][4] = new Account("aa", "Hobby", "aa", 5250.5M);
            accounts[4][5] = new Account("aa", "Panda", "aa", 77777M);
            #endregion

            string[] startMenu = new string[]
            {
                "Log in", "Help", "Exit"
            };

            while (true)
            {
                string selectedMenuItem = DrawMenu(startMenu);

                switch (selectedMenuItem)
                {
                    case "Log in":
                        Login(accounts);
                        break;

                    case "Help":
                        Help();
                        break;

                    case "Exit":
                        Environment.Exit(0);
                        break;
                }

            }
        }

        static void WithdrawMenu(Account[] currentUser)
        {
            string? input;
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("- Withdraw -");
                Console.WriteLine("");

                for (int i = 0; i < currentUser.Length; i++)
                {
                    Console.WriteLine($"{i}: {currentUser[i].GetAccountName()} {currentUser[i].GetBalance()}");
                }
                Console.WriteLine("- Enter account number to withdraw from -");
                Console.WriteLine("- Enter e to exit -");

                input = Console.ReadLine();

                if (input == null)
                {
                    break;
                }
                else if (input.ToLower() == "e")
                {
                    break;
                }
                else if (int.TryParse(input, out int accountNumber))
                {
                    Console.WriteLine("- Please enter amount to withdraw -");
                    Console.WriteLine("");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        if (amount < 0)
                        {
                            Console.WriteLine("- Please enter a valid amount -");
                            Console.WriteLine("- Press any key to continue -");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (currentUser[accountNumber].GetBalance() - amount < 0)
                        {
                            Console.WriteLine("- Amount exceeds balance -");
                            Console.WriteLine("- Press any key to continue -");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("- Please enter password to confirm transaction -");
                            input = Console.ReadLine();
                            if (input == currentUser[accountNumber].GetPassword())
                            {
                                currentUser[accountNumber].Withdraw(amount);
                                Console.WriteLine($"- {amount} was withdrawn from account {currentUser[accountNumber].GetAccountName()} -");
                                Console.WriteLine($"- Account {currentUser[accountNumber].GetAccountName()} new Balance is {currentUser[accountNumber].GetBalance()} -");
                                Console.WriteLine("- Press any key to continue -");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("- Incorrect password -");
                                Console.WriteLine("- Press any key to continue -");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("- Please enter a valid amount -");
                        Console.WriteLine("- Press any key to continue -");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("- Please enter a valid account -");
                    Console.WriteLine("- Press any key to continue -");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

        }

        static void TransferMenu(Account[] currentUser)
        {
            string? input;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("- Transfer -");
                Console.WriteLine("");

                //for loop displays all user accounts & balance
                for (int i = 0; i < currentUser.Length; i++)
                {
                    Console.WriteLine($"{i}: {currentUser[i].GetAccountName()} {currentUser[i].GetBalance()}");
                }

                Console.WriteLine("- Enter account number to transfer from -");
                Console.WriteLine("- Enter e to exit -");
                input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }
                else if (input.ToLower() == "e")
                {
                    break;
                }
                else if (int.TryParse(input, out int index))
                {
                    Console.WriteLine($"- Enter amount to transfer from {currentUser[index].GetAccountName()}");
                    if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                    {
                        if (amount < 0)
                        {
                            Console.WriteLine("- Amount is negative enter valid number -");
                            Console.ReadKey();
                        }
                        else if (currentUser[index].GetBalance() - amount < 0)
                        {
                            Console.WriteLine("- Transfer amount is larger than balance -");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("- Enter account number to transfer to -");
                            if (int.TryParse(Console.ReadLine(), out int account))
                            {
                                currentUser[index].Withdraw(amount);
                                currentUser[account].Transfer(amount);
                                //Console.WriteLine($"{currentUser[index].GetAccountName()} {currentUser[index].GetBalance()}");
                                //Console.WriteLine($"{currentUser[account].GetAccountName()} {currentUser[account].GetBalance()}");
                                Console.WriteLine($"- {amount} has been transfered from {currentUser[index].GetAccountName()} to {currentUser[account].GetAccountName()} -");
                                Console.WriteLine("- Press any key to continue -");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("- Enter valid account");
                                Console.WriteLine("- Press any key to continue -");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("- Enter valid amount -");
                        Console.WriteLine("- Press any key to continue -");
                        Console.ReadKey();
                    }
                }

                else
                {
                    Console.WriteLine("- Enter valid account number -");
                    Console.WriteLine("- Press any key to continue -");
                    Console.ReadKey();
                }

            }

        }

        public static void BankMenu(string id, Account[][] accounts)
        {

            #region Account[][] Declarations for all users 

            //Account[][] accounts = new Account[5][];
            //accounts[0] = new Account[2];
            //accounts[1] = new Account[3];
            //accounts[2] = new Account[4];
            //accounts[3] = new Account[5];
            //accounts[4] = new Account[6];

            //accounts[0][0] = new Account("ElonTusk", "Checking", "test0", 500000000M);
            //accounts[0][1] = new Account("ElonTusk", "Savings", "test0", 1000000000000M);

            //accounts[1][0] = new Account("OscarGrouch", "Checking", "test1", 50.58M);
            //accounts[1][1] = new Account("OscarGrouch", "Savings", "test1", 1M);
            //accounts[1][2] = new Account("OscarGrouch", "Retirement", "test1", 0M);

            //accounts[2][0] = new Account("SpikeSpiegel", "Checking", "test2", 3000102.71M);
            //accounts[2][1] = new Account("SpikeSpiegel", "Savings", "test2", 0.78M);
            //accounts[2][2] = new Account("SpikeSpiegel", "Retirement", "test2", 500M);
            //accounts[2][3] = new Account("SpikeSpiegel", "Hobby", "test2", 50500M);

            //accounts[3][0] = new Account("LucynaKushinada", "Checking", "test3", 22201M);
            //accounts[3][1] = new Account("LucynaKushinada", "Savings", "test3", 5050010M);
            //accounts[3][2] = new Account("LucynaKushinada", "Retirement", "test3", 70M);
            //accounts[3][3] = new Account("LucynaKushinada", "Hobby", "test3", 10000M);
            //accounts[3][4] = new Account("LucynaKushinada", "Food", "test3", 7000M);

            //accounts[4][0] = new Account("PeterPanda", "Checking", "test4", 11000.98M);
            //accounts[4][1] = new Account("PeterPanda", "Savings", "test4", 390000M);
            //accounts[4][2] = new Account("PeterPanda", "Retirement", "test4", 47000M);
            //accounts[4][3] = new Account("PeterPanda", "Food", "test4", 2000M);
            //accounts[4][4] = new Account("PeterPanda", "Hobby", "test4", 5250.5M);
            //accounts[4][5] = new Account("PeterPanda", "Panda", "test4", 77777M);

            Account[] currentUser;

            #endregion

            string[] BankMenu = new string[]
            {
                "Account & Balance", "Transfer", "Withdraw", "Exit"
            };

            while (true)
            {
                string selectedMenuItem = DrawMenu(BankMenu);


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

                                for (int j = 0; j < currentUser.Length; j++)
                                {
                                    Console.WriteLine($"{j + 1}: {currentUser[j].GetAccountName()} - {currentUser[j].GetBalance()}€");
                                }
                            }
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Enter Any Key to Exit");
                        Console.ReadKey();
                        break;

                    case "Transfer":
                        Console.Clear();
                        for (int h = 0; h < accounts.Length; h++)
                        {
                            if (accounts[h][0].GetOwnerId() == id)
                            {
                                TransferMenu(accounts[h]);
                            }
                        }
                        break;

                    case "Withdraw":
                        Console.Clear();
                        for (int k = 0; k < accounts.Length; k++)
                        {
                            if (accounts[k][0].GetOwnerId() == id)
                            {
                                WithdrawMenu(accounts[k]);
                            }
                        }
                        break;

                    case "Exit":
                        menuIndex = 0;
                        return;

                }

            }
        }

        static void Login(Account[][] accounts)
        {
            string? input;
            int tries = 0;
            bool forceExit = false;

            while (tries < 3)
            {
                Console.WriteLine("-- Please Enter Your Name --");
                input = Console.ReadLine();

                for (int i = 0; i < accounts.Length; i++)
                {
                    if (input == accounts[i][0].GetOwnerId())
                    {
                        Console.WriteLine("");
                        Console.WriteLine("-- Enter Password --");
                        input = Console.ReadLine();

                        if (input == accounts[i][0].GetPassword())
                        {
                            BankMenu(accounts[i][0].GetOwnerId(), accounts);
                            tries = 5;
                        }

                    }
                }
                Console.WriteLine("!! Please enter correct user name & password !!");
                tries++;
            }
            if (tries == 3)
            {
                Environment.Exit(0);
            }

        }

        static void Help()
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

    public class Account
    {
        private readonly string? ownerId;
        private readonly string? accountName;
        private readonly string? password;
        private decimal balnace = 0M;

        public Account(string? ownerId, string? accountName, string? password, decimal balnace)
        {
            this.ownerId = ownerId;
            this.accountName = accountName;
            this.balnace = balnace;
            this.password = password;
        }

        public void Info()
        {
            Console.WriteLine("ownerId: {0}", ownerId);
            Console.WriteLine("accountName: {0}", accountName);
            Console.WriteLine("balnace: {0}", balnace);
            Console.WriteLine("-----");
        }

        public decimal GetBalance()
        {
            return balnace;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine($"- ammount is negative {amount} -");
            }
            else if (amount >= balnace)
            {
                Console.WriteLine("- Transaction is larger than balance -");
            }
            else
            {
                balnace -= amount;
            }

        }

        public void Transfer(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine($"- ammount is negative {amount} -");
            }
            else
            {
                balnace += amount;
            }
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

}