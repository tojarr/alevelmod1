using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1
{
    enum Log
    {
        admin
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create array user base
            string[][] arrBase = new string[0][];
            // Create array user history
            string[] history = new string[0];
            // Nambers account
            int countAcc = 100;
            // Main menu
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- MAIN MENU ---");
                Console.WriteLine();
                Console.WriteLine("Enter 1 for admin menu.");
                Console.WriteLine("Enter 2 for user menu.");
                Console.WriteLine("Enter 3 for quit.");
                Console.WriteLine();
                Console.Write("Enter:");
                string numlog = Console.ReadLine();
                string login = "";
                if (numlog == "1")
                {
                    Console.Write("Enter login:");
                    login = Console.ReadLine();
                    if (login != Convert.ToString(Log.admin))
                    {
                        IncNum();
                    }
                    else
                    {
                        Console.Clear();
                        AdminMet(login, ref arrBase, ref history, ref countAcc);
                    }
                }
                else if (numlog == "2")
                {
                    Console.Write("Enter login:");
                    login = Console.ReadLine();
                    bool logTrue = false;
                    for (int i = 0; i < arrBase.Length; i++)
                    {
                        if ("Name - " + login + "." == arrBase[i][0])
                        {
                            if (arrBase[i][1] == "Status - Blocked")
                            {
                                Console.WriteLine();
                                Console.WriteLine("USER BLOCKED!!!");
                                Console.WriteLine();
                                Console.Write("Press any key to quit main menu.");
                                Console.ReadKey();
                                logTrue = true;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                UserMet(login, ref arrBase, ref history, ref countAcc);
                                logTrue = true;
                                break;
                            }
                        }
                    }
                    if (logTrue != true)
                    {
                        IncNum();
                    }
                }
                else if (numlog == "3")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    IncNum();
                }
            }
        }
        // Methods
        // Admin menu
        static void AdminMet(string login, ref string[][] arrBase, ref string[] history, ref int countAcc)
        {
            while (true)
            {
                string text = "";
                //Menu admin
                Console.Clear();
                Console.WriteLine("--- ADMIN MENU ---");
                Console.WriteLine();
                Console.WriteLine("1 - List of users.");
                Console.WriteLine("2 - Block/Unblock user.");
                Console.WriteLine("3 - Add new user.");
                Console.WriteLine("4 - Delete user.");
                Console.WriteLine("5 - Creat new account.");
                Console.WriteLine("6 - Delete account.");
                Console.WriteLine("7 - History of user.");
                Console.WriteLine("8 - Quit to main menu.");
                Console.WriteLine();
                Console.Write("Enter:");
                string NumMenu = Console.ReadLine();
                // Goto list of users
                if (NumMenu == "1")
                {
                    PrintUsers(arrBase, text);
                }
                // Goto block/unblock user
                else if (NumMenu == "2")
                {
                    BlockUnblock(ref arrBase);
                }
                // Goto add new user
                else if (NumMenu == "3")
                {
                    AddUser(ref arrBase, ref history, ref countAcc);
                }
                // Goto delete user
                else if (NumMenu == "4")
                {
                    DelUser(ref arrBase, ref history);
                }
                // Goto create new account
                else if (NumMenu == "5")
                {
                    CreatNewAcc(ref arrBase, ref countAcc);
                }
                // Goto delete account
                else if (NumMenu == "6")
                {
                    DelAcc(ref arrBase);
                }
                // Goto history of user
                else if (NumMenu == "7")
                {
                    HistoryUser(history, ref arrBase);
                }
                // Goto Quit to main menu
                else if (NumMenu == "8")
                {
                    Console.Clear();
                    break;
                }
                //Goto Begin
                else
                {
                    IncNum();
                }
            }

        }
        // User menu
        static void UserMet(string login, ref string[][] arrBase, ref string[] history, ref int countAcc)
        {
            while (true)
            {
                // Search index user
                int indUser = SearchIndexLogin(arrBase, login);
                // Menu user
                Console.Clear();
                Console.WriteLine("--- USER MENU ---");
                Console.WriteLine();
                Console.WriteLine("1 - Put cash to account.");
                Console.WriteLine("2 - Take off cash from the account.");
                Console.WriteLine("3 - Transfer.");
                Console.WriteLine("4 - Quit to main menu.");
                Console.WriteLine();
                Console.Write("Enter:");
                string PutTake = Console.ReadLine();
                // Goto put cash
                if (PutTake == "1")
                {
                    PutCash(indUser, ref arrBase, ref history);
                }
                // Goto take off cash
                else if (PutTake == "2")
                {
                    TakeOffCash(indUser, ref arrBase, ref history);
                }
                // Goto transfer
                else if (PutTake == "3")
                {
                    Transfer(indUser, ref arrBase, ref history);
                }
                // Goto quit to main menu
                else if (PutTake == "4")
                {
                    Console.Clear();
                    break;
                }
                // Goto Begin
                else
                {
                    IncNum();
                }
            }
        }
        // Block/Unblock user
        static void BlockUnblock(ref string[][] arrBase)
        {
            Console.Clear();
            Console.WriteLine("--- BLOCK/UNBLOCK MENU ---");
            Console.WriteLine();
            Console.Write("Enter name user:");
            string logUser = Console.ReadLine();
            int indUser = SearchIndexLogin(arrBase, logUser);
            if (indUser < 0)
            {
                IncNum();
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    PrintUser(arrBase, indUser);
                    Console.WriteLine("1 - Blocked.");
                    Console.WriteLine("2 - Unblocked.");
                    Console.WriteLine("3 - Quit to admin menu.");
                    string status = Console.ReadLine();
                    if (status == "1")
                    {
                        arrBase[indUser][1] = "Status - Blocked";
                    }
                    else if (status == "2")
                    {
                        arrBase[indUser][1] = "Status - Unblocked";
                    }
                    else if (status == "3")
                    {
                        break;
                    }
                    else
                    {
                        IncNum();
                    }
                }
            }
        }
        // Add users
        static void AddUser(ref string[][] arrBase, ref string[] history, ref int countAcc)
        {
            string text1 = "--- ADD USER MENU ---", text2 = "";
            Console.Clear();
            Console.WriteLine(text1);
            Console.WriteLine();
            Console.Write("Enter name new user:");
            string logUser = Console.ReadLine();
            int indUser = SearchIndexLogin(arrBase, logUser);
            if (indUser != -1)
            {
                QuitAdminMenu(indUser, arrBase, text1, text2 = "Name is in use");
            }
            else
            {
                string[][] arrBase1 = new string[arrBase.Length + 1][];
                for (int i = 0; i < arrBase.Length; i++)
                {
                    arrBase1[i] = new string[arrBase[i].Length];
                    for (int j = 0; j < arrBase[i].Length; j++)
                    {
                        arrBase1[i][j] = arrBase[i][j];
                    }
                }
                arrBase1[arrBase1.Length - 1] = new string[4];
                arrBase1[arrBase1.Length - 1][0] = "Name - " + logUser + ".";
                arrBase1[arrBase1.Length - 1][1] = "Status - Unblocked";
                arrBase1[arrBase1.Length - 1][2] = ". Account - " + (Convert.ToString(countAcc)) + ". Cash - ";
                arrBase1[arrBase1.Length - 1][3] = "0";
                arrBase = arrBase1;
                string[] history1 = new string[history.Length + 1];
                for (int i = 0; i < history.Length; i++)
                {
                    history1[i] = history[i];
                }
                history1[history1.Length - 1] = "Name - " + logUser + ".\n\n";
                history = history1;
                PrintUsers(arrBase, text2);
                countAcc++;
            }
        }
        // Delete user
        static void DelUser(ref string[][] arrBase, ref string[] history)
        {
            string text1 = "--- DELETE USER MENU ---", text2 = "";
            Console.Clear();
            Console.WriteLine(text1);
            Console.WriteLine();
            Console.Write("Enter name user:");
            string logUser = Console.ReadLine();
            int indUser = SearchIndexLogin(arrBase, logUser);
            if (indUser < 0)
            {
                IncNum();
            }
            else
            {
                PrintUser(arrBase, indUser);
                Console.Write("Delete y/n:");
                string _input = Console.ReadLine();
                if (_input != "y")
                {
                    QuitAdminMenu(indUser, arrBase, text1, text2 = "User is not deleted");
                }
                else
                {
                    string[][] arrBase1 = new string[arrBase.Length - 1][];
                    for (int i = 0, k = 0; i < arrBase.Length; k++, i++)
                    {
                        if (indUser != i)
                        {
                            arrBase1[k] = new string[arrBase[i].Length];
                        }
                        else
                        {
                            k--;
                            continue;
                        }
                        for (int j = 0; j < arrBase[i].Length; j++)
                        {
                            arrBase1[k][j] = arrBase[i][j];
                        }
                    }
                    arrBase = arrBase1;
                    string[] history1 = new string[history.Length - 1];
                    for (int i = 0, k = 0; i < history.Length; k++, i++)
                    {
                        if (indUser == i)
                        {
                            k--;
                            continue;
                        }
                        else
                        {
                            history1[k] = history[i];
                        }
                    }
                    history = history1;
                    PrintUsers(arrBase, text2 = "User " + logUser + " is deleted");
                }
            }
        }
        // Creat new account
        static void CreatNewAcc(ref string[][] arrBase, ref int countAcc)
        {
            string text1 = "--- CREATe NEW ACCOUNT MENU ---", text2 = "Account is created.";
            Console.Clear();
            Console.WriteLine(text1);
            Console.WriteLine();
            Console.Write("Enter name user:");
            string logUser = Console.ReadLine();
            int indUser = SearchIndexLogin(arrBase, logUser);
            if (indUser < 0)
            {
                IncNum();
            }
            else
            {
                string[] arrBase1 = new string[arrBase[indUser].Length + 2];
                for (int i = 0; i < arrBase[indUser].Length; i++)
                {
                    arrBase1[i] = arrBase[indUser][i];
                }
                arrBase1[arrBase1.Length - 2] = ". Account - " + (Convert.ToString(countAcc)) + ". Cash - ";
                arrBase1[arrBase1.Length - 1] = "0";
                arrBase[indUser] = arrBase1;
                countAcc++;
            }
            QuitAdminMenu(indUser, arrBase, text1, text2);
        }
        //Delete account
        static void DelAcc(ref string[][] arrBase)
        {
            bool accTrue = false;
            string text1 = "--- DELETE ACCOUNT MENU ---", text2 = "Enter name user: ";
            Console.Clear();
            int indexAcc = 0;
            Console.WriteLine(text1);
            Console.WriteLine();
            Console.Write(text2);
            string logUser = Console.ReadLine();
            int indUser = SearchIndexLogin(arrBase, logUser);
            if (indUser < 0)
            {
                IncNum();
            }
            else
            {
                PrintUser(arrBase, indUser);
                Console.Write("Enter number account:");
                string accNum = Console.ReadLine();
                for (int i = 2; i < arrBase[indUser].Length; i += 2)
                {
                    if (". Account - " + accNum + ". Cash - " == arrBase[indUser][i])
                    {
                        indexAcc = i;
                        accTrue = true;
                        break;
                    }
                }
                if (accTrue == true)
                {
                    int accSum = int.Parse(arrBase[indUser][indexAcc + 1]);
                    if (accSum <= 10)
                    {
                        string[] arrBase1 = new string[arrBase[indUser].Length - 2];
                        for (int i = 0, k = 0; i < arrBase[indUser].Length; k++, i++)
                        {
                            if (i == indexAcc)
                            {
                                k--;
                                i++;
                                continue;
                            }
                            arrBase1[k] = arrBase[indUser][i];
                        }
                        arrBase[indUser] = arrBase1;
                        QuitAdminMenu(indUser, arrBase, text1, text2 = "Account is deleted.");
                    }
                    else
                    {
                        QuitAdminMenu(indUser, arrBase, text1, text2 = "Account sum is more then 10.");
                    }
                }
                else
                {
                    IncNum();
                }
            }
        }
        // History of user
        static void HistoryUser(string[] history, ref string[][] arrBase)
        {
            Console.Clear();
            Console.WriteLine("--- HISTORY USER MENU ---");
            Console.WriteLine("\n");
            Console.Write("Enter name user:");
            string logUser = Console.ReadLine();
            int indUser = SearchIndexLogin(arrBase, logUser);
            if (indUser < 0)
            {
                IncNum();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(history[indUser]);
                Console.WriteLine();
                Console.WriteLine("Press any key to quit the admin menu");
                Console.ReadKey();
            }
        }
        // Put cash to account
        static void PutCash(int indUser, ref string[][] arrBase, ref string[] history)
        {
            string s = "", text1 = "--- PUT CASH MENU ---";
            bool accTrue = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(text1);
                PrintUser(arrBase, indUser);
                Console.Write("Enter number account:");
                string accNum = Console.ReadLine();
                Console.Write("Enter sum:");
                s = Console.ReadLine();
                bool res = Int32.TryParse(s, out int addSum);
                if (res)
                {
                    for (int i = 2; i < arrBase[indUser].Length; i += 2)
                    {
                        if (". Account - " + accNum + ". Cash - " == arrBase[indUser][i])
                        {
                            int cashOld = int.Parse(arrBase[indUser][i + 1]);
                            cashOld += addSum;
                            string cashNew = Convert.ToString(cashOld);
                            arrBase[indUser][i + 1] = cashNew;
                            history[indUser] += "Data:" + DateTime.Now + ".Put cash to account(" + accNum + ") - " + s + ".\n";
                            accTrue = true;
                            break;
                        }
                    }
                    if (accTrue == true)
                    {
                        QuitUserMenu(indUser, arrBase, text1);
                        break;
                    }
                    else
                    {
                        IncNum();
                        break;
                    }
                }
                else
                {
                    IncNum();
                }
            }
        }
        // Take off cash
        static void TakeOffCash(int indUser, ref string[][] arrBase, ref string[] history)
        {
            string s = "", text1 = "-- - TAKE OFF CASH MENU-- - ";
            bool akkTrue = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(text1);
                PrintUser(arrBase, indUser);
                Console.Write("Enter number account:");
                string accNum = Console.ReadLine();
                Console.Write("Enter sum:");
                s = Console.ReadLine();
                bool res = Int32.TryParse(s, out int addSum);
                if (res)
                {
                    for (int i = 2; i < arrBase[indUser].Length; i += 2)
                    {
                        if (". Account - " + accNum + ". Cash - " == arrBase[indUser][i])
                        {
                            int cashOld = int.Parse(arrBase[indUser][i + 1]);
                            if ((cashOld -= addSum) >= 0)
                            {
                                string cashNew = Convert.ToString(cashOld);
                                arrBase[indUser][i + 1] = cashNew;
                                history[indUser] += "Data:" + DateTime.Now + ".Take off cash to account(" + accNum + ") - " + s + ".\n";
                                akkTrue = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Not enough money.");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                akkTrue = true;
                                break;
                            }
                        }
                    }
                    if (akkTrue == true)
                    {
                        QuitUserMenu(indUser, arrBase, text1);
                        break;
                    }
                    else
                    {
                        IncNum();
                        break;
                    }
                }
                else
                {
                    IncNum();
                }
            }
        }
        // Transfer money
        static void Transfer(int indUser, ref string[][] arrBase, ref string[] history)
        {
            string s = "", text = "--- TRANSFER MENU---";
            bool akkTrue = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(text);
                PrintUser(arrBase, indUser);
                Console.Write("Enter number account for take off money:");
                string akkTake = Console.ReadLine();
                Console.Write("Enter number account for put money:");
                string akkPut = Console.ReadLine();
                Console.Write("Enter sum:");
                s = Console.ReadLine();
                bool res = Int32.TryParse(s, out int addSum);
                if (res)
                {
                    for (int i = 2; i < arrBase[indUser].Length; i += 2)
                    {
                        if (". Account - " + akkTake + ". Cash - " == arrBase[indUser][i])
                        {
                            for (int j = 2; j < arrBase[indUser].Length; j += 2)
                            {
                                if (". Account - " + akkPut + ". Cash - " == arrBase[indUser][j])
                                {
                                    int cashOldTake = int.Parse(arrBase[indUser][i + 1]);
                                    int cashOldPut = int.Parse(arrBase[indUser][j + 1]);
                                    if ((cashOldTake -= addSum) > 0)
                                    {
                                        string cashNewTake = Convert.ToString(cashOldTake);
                                        arrBase[indUser][i + 1] = cashNewTake;
                                        cashOldPut += addSum;
                                        string cashNewPut = Convert.ToString(cashOldPut);
                                        arrBase[indUser][j + 1] = cashNewPut;
                                        history[indUser] += "Data:" + DateTime.Now + ".Transfer money from account(" + akkTake + ") " +
                                            "to account(" + akkPut + ") - " + s + ".\n";
                                        akkTrue = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not enough money.");
                                        Console.WriteLine("Press any key to continue.");
                                        Console.ReadKey();
                                        akkTrue = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (akkTrue == true)
                    {
                        QuitUserMenu(indUser, arrBase, text);
                        break;
                    }
                    else
                    {
                        IncNum();
                        break;
                    }
                }
                else
                {
                    IncNum();
                }
            }
        }
        // Quit to admin menu
        static void QuitAdminMenu(int indUser, string[][] arrBase, string text1, string text2)
        {
            Console.Clear();
            Console.WriteLine(text1);
            Console.WriteLine();
            PrintUser(arrBase, indUser);
            Console.WriteLine();
            Console.WriteLine(text2);
            Console.WriteLine();
            Console.WriteLine("Press any key to quit the admin menu.");
            Console.ReadKey();
        }
        // Quit to user menu
        static void QuitUserMenu(int indUser, string[][] arrBase, string text1)
        {
            Console.Clear();
            Console.WriteLine(text1);
            PrintUser(arrBase, indUser);
            Console.WriteLine("Press any key to quit the user menu.");
            Console.ReadKey();
        }
        // Print incorrect
        static void IncNum()
        {
            Console.Clear();
            Console.WriteLine("Incorrect input");
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
        // Search index logUser
        static int SearchIndexLogin(string[][] arrBase, string logUser)
        {
            int indUser = 0;
            bool _true = false;
            for (int i = 0; i < arrBase.Length; i++)
            {
                if ("Name - " + logUser + "." == arrBase[i][0])
                {
                    indUser = i;
                    _true = true;
                    break;
                }
            }
            if (_true == true)
            {
                return indUser;
            }
            else
            {
                return indUser = -1;
            }
        }
        // Print user
        static void PrintUser(string[][] arrBase, int indUser)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < arrBase[indUser].Length; i++)
            {
                Console.Write(arrBase[indUser][i]);
            }
            Console.WriteLine("\n");
        }
        // Print array users
        static void PrintUsers(string[][] arrBase, string text)
        {
            Console.Clear();
            Console.WriteLine("--- LIST OF USERS ---");
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine();
            for (int i = 0; i < arrBase.Length; i++)
            {
                Console.Write("{0}", (i + 1) + ".");
                for (int j = 0; j < arrBase[i].Length; j++)
                {
                    Console.Write(arrBase[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit the admin menu");
            Console.ReadKey();

        }
    }
}
