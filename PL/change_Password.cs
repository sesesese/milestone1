using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using sharedClasses;
using sharedClasses.Exceptions;

namespace PL
{
    class change_Password

    {
        private BL_interface BL;
        internal change_Password(BL_interface BL)
        {
            this.BL = BL;
            bool stay = true;

            while (stay)
            {
                Console.Clear();
                Console.WriteLine("please enter your current Password.");
                Console.WriteLine("To go back to the menu press 0 and press enter");
                Console.WriteLine();
                string Password = Console.ReadLine();
                if (Password.Equals("0"))
                    break;
                if (BL.verification(Password)) {
                    Console.WriteLine("password must contain 8 digits and at least one digit must be number");
                    Console.WriteLine("please enter your new Password or press 1 to genrate a random Password");
                    string Password1 = Console.ReadLine();
                    if (Password1.Equals("1"))
                    {
                        Password1 = BL.SetRandomPass();
                        Console.WriteLine(Password1);
                    }
                    else if (Password1.Equals("0"))
                    {
                        break;
                    }
                    if (BL.legalPass(Password1))
                    {
                        Console.WriteLine("please enter your new Password again");
                        string Password2 = Console.ReadLine();
                        try
                        {
                            BL.ChangePass(Password1, Password2);
                            Console.Clear();
                            Console.WriteLine("your password has changed successfully");
                            Console.ReadLine();
                            break;
                        }
                        catch (passnotmatching)
                        {
                            Console.WriteLine("the new passwords you type is not matching");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("you type illegal new password");
                        Console.WriteLine("the password must contain 8 digits and at least one digit must be number");
                        Console.ReadLine();
                    }
             
                }
                else
                {
                    Console.WriteLine("You typed wrong password");
                    Console.ReadLine();
                }

                    


            }

        }
    }
}
