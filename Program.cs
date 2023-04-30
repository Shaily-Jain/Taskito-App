using System;
using System.Collections;

namespace ATM_Transaction_App
{
    internal class Program
    {
        Hashtable userdata = new Hashtable();
        Hashtable accdetails = new Hashtable();
        
        string firstname, lastname, fathername, mothername, DOB, phoneno, newpass, confirmpass, age, accno, pin_no;
        double initialbal = 0;
        public int flag = 0;
        public void validatefield(string data)
        {
            // Validate required field
            Console.WriteLine("Required field can't be null, please enter some data!!\n");
            if (data == firstname)
            {
                while (firstname.Length == 0)
                {
                    Console.Write("First Name = ");
                    firstname = Console.ReadLine();
                }
            }
            if (data == lastname)
            {
                while (lastname.Length == 0)
                {
                    Console.Write("Last Name = ");
                    lastname = Console.ReadLine();
                }
            }
            if (data == fathername)
            {
                while (fathername.Length == 0)
                {
                    Console.Write("Father Name = ");
                    fathername = Console.ReadLine();
                }
            }
            if (data == mothername)
            {
                while (mothername.Length == 0)
                {
                    Console.Write("Mother Name = ");
                    mothername = Console.ReadLine();
                }
            }
            if (data == DOB)
            {
                while (DOB.Length == 0)
                {
                    Console.Write("DOB = ");
                    DOB = Console.ReadLine();
                }
            }
            if (data == phoneno)
            {
                while (phoneno.Length == 0)
                {
                    Console.Write("Phone Number = ");
                    phoneno = Console.ReadLine();
                }
            }
            if (data == age)
            {
                while (age.Length == 0)
                {
                    Console.Write("Age = ");
                    age = Console.ReadLine();
                }
            }
            if (data == accno)
            {
                while (accno.Length == 0)
                {
                    Console.Write("Account Number = ");
                    accno = Console.ReadLine();
                }
            }
            if (data == pin_no)
            {
                while (pin_no.Length == 0)
                {
                    Console.Write("Pin Number = ");
                    pin_no = Console.ReadLine();
                }
            }
            if (data == newpass)
            {
                while (newpass.Length == 0)
                {
                    Console.Write("New Password = ");
                    newpass = Console.ReadLine();
                }
            }
            if (data == confirmpass)
            {
                while (confirmpass.Length == 0)
                {
                    Console.Write("Confirm Password = ");
                    confirmpass = Console.ReadLine();
                }
            }
        }
        public void create_acc()
        {
            Console.WriteLine("Welcome to 24hrs ATM. Please Enter all the details:");
            
            Console.Write("\nFirst Name = ");
            firstname = Console.ReadLine();
            if (firstname.Length == 0)      validatefield(firstname);

            Console.Write("Last Name = ");
            lastname = Console.ReadLine(); 
            if (lastname.Length == 0)       validatefield(lastname);

            Console.Write("Father Name = ");
            fathername = Console.ReadLine();
            if (fathername.Length == 0)     validatefield(fathername);

            Console.Write("Mother Name = ");
            mothername = Console.ReadLine();
            if (mothername.Length == 0)     validatefield(mothername);

            Console.Write("DOB = ");
            DOB = Console.ReadLine();
            if (DOB.Length == 0)            validatefield(DOB);

            Console.Write("Phone Number = ");
            phoneno = Console.ReadLine();
            if (phoneno.Length == 0)        validatefield(phoneno);

            Console.Write("Age = ");
            age = Console.ReadLine();
            if (age.Length == 0)       validatefield(age);

            Console.Write("Account Number = ");
            accno = Console.ReadLine();
            if (accno.Length == 0)      validatefield(accno);
            else if (userdata.ContainsKey(accno))
            {
                Console.WriteLine("Account no. already exists!!");
                
                while (userdata.ContainsKey(accno))
                {
                    Console.Write("Account Number = ");
                    accno = Console.ReadLine();
                }
            }

            Console.Write("Pin Number = ");
            pin_no = Console.ReadLine();
            if (pin_no.Length == 0)     validatefield(pin_no);

            Console.Write("New Password = ");
            newpass = Console.ReadLine();
            if (newpass.Length == 0)        validatefield(newpass);

            Console.Write("Confirm Password = ");
            confirmpass = Console.ReadLine();
            if (confirmpass.Length == 0)       validatefield(confirmpass);

            // compare password
            if(newpass != confirmpass)
            {
                while (newpass != confirmpass)
                {
                    Console.WriteLine("New and confirm password are not matching! please enter a same password");
                    Console.Write("New Password = ");
                    newpass = Console.ReadLine();
                    Console.Write("Confirm Password = ");
                    confirmpass = Console.ReadLine();
                }
            }
            
            // nested data 
            accdetails.Add("First name", firstname);
            accdetails.Add("Last name", lastname);
            accdetails.Add("Father name", fathername);
            accdetails.Add("Mother name", mothername);
            accdetails.Add("DOB", DOB);
            accdetails.Add("Phone no", phoneno);
            accdetails.Add("Age", age);
            accdetails.Add("Accountno", accno);
            accdetails.Add("Pin No", pin_no);
            accdetails.Add("Initial Balance", initialbal.ToString());
            accdetails.Add("New password", newpass);
            accdetails.Add("Confirm password", confirmpass);

            // user accont details
            userdata.Add(accno, accdetails);
            Console.WriteLine("New user account has been created successfully!!\n");
        }
        public void login_user()
        {
            Console.Write("\nEnter your Account no = ");
            string accno = Console.ReadLine(); 

            if (userdata.ContainsKey(accno)&& userdata[accno] != null)
            {
                Hashtable innerpin = userdata[accno] as Hashtable;
                Console.Write("Enter your Pin = ");
                string Pin_no = Console.ReadLine();

                if (innerpin.ContainsKey("Pin No") && innerpin["Pin No"] == pin_no)
                {
                    Console.WriteLine("User login successfully!!\n");
                    flag++;
                }
                else
                    Console.WriteLine("Invalid pin,please enter correct pin or click forget pin!!\n");
            }
            else
                Console.WriteLine("\nInvalid account no,please enter a valid account no or create an account!!\n");
        }
        public void deposit_bal()
        {
            if(flag == 0)
            {
                Console.WriteLine("Login into ATM first!!");
                login_user();
            }
            else
            {
                Console.Write("\nEnter the amount you want to deposit = ");
                int amt = int.Parse(Console.ReadLine());
                initialbal += amt;
                ((Hashtable)userdata[accno])["Initial Balance"] = initialbal.ToString();
                Console.WriteLine("Amount deposited successfully!!\n");

                
            }
        }
        public void withdraw_bal()
        {
            if (flag == 0)
            {
                Console.WriteLine("Login into ATM first!!");
                login_user();
            }
            else
            {
                Console.Write("\nEnter the amount you want to withdraw = ");
                int amt = int.Parse(Console.ReadLine());
                if (initialbal == 0)
                {
                    Console.WriteLine("Your account have no balance to withdraw.\n");
                }
                else if (initialbal - amt < 500)
                {
                    Console.WriteLine("Insufficient balance.\n");
                }
                else
                {
                    initialbal -= amt;
                    ((Hashtable)userdata[accno])["Initial Balance"] = initialbal.ToString();
                    Console.WriteLine("Amount withdraw successfully!!\n");
                }
            }
        }
        public void check_bal()
        {
            if (flag == 0)
            {
                Console.WriteLine("Login into ATM first!!");
                login_user();
            }
            else
                Console.WriteLine("\nYour account balance in Rs. = " + initialbal+"\n");
        }
        public void check_details()
        {
            if (flag == 0)
            {
                Console.WriteLine("Login into ATM first!!");
                login_user();
            }
            else
            {
                Console.Write("\n Please enter your account number:");
                string accno = Console.ReadLine();
                int i = 1;

                if (userdata.ContainsKey(accno) && userdata[accno] != null)
                {
                    Console.WriteLine("\nYour account details:");
                    foreach (DictionaryEntry data in userdata)
                    {
                        Console.WriteLine(i++ + " - " + "Your Account no = " + data.Key + "\n");
                        foreach (DictionaryEntry inner in (Hashtable)data.Value)
                            Console.WriteLine("  " + inner.Key + " - " + inner.Value);
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Invalid account number. Please enter a valid account no or contact your admin\n");
            }    
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            while (true)
            {
                Console.WriteLine("Welcome to ATM 24hrs Service");
                Console.Write(" 1. Add New User\n 2. Login User\n 3. Deposit Balance\n 4. Withdraw Balance\n 5. Check Balance\n 6. Check User Details\n 7. Exit\n Enter your choice:");
                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        obj.create_acc();
                        break;
                    case 2:
                        obj.login_user();
                        break;
                    case 3:
                        obj.deposit_bal();
                        break;
                    case 4:
                        obj.withdraw_bal();
                        break;
                    case 5:
                        obj.check_bal();
                        break;
                    case 6:
                        obj.check_details();
                        break;
                    case 7:
                        obj.flag = 0;
                        Console.WriteLine("Thanks for choosing ATM service, Hope we will meet again!!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice!! Press 7 for exit:)");
                        break;
                }
            }
           
        }
    }
}

/* two ways to print nested hashtable -
* Hashtable userdetails = data.Value as Hashtable;
  (Hashtable)data.Value, 
  ((Hashtable)userdata[acc])["Balance"] = initialbal
 
*   update value of a nested hashtable key -
    Console.WriteLine("Enter account no");
    string accountno = Console.ReadLine();
    if (accno == accountno)
    {
        string val = "12345";
        ((Hashtable)userdata[accno])["Accountno"] = val;
        Console.WriteLine("Value updated successfully!!");
    }
*/