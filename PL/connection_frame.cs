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
    class connection_frame
    {
        private BL_interface BL;
        internal connection_frame(BL_interface BL)
        {
            this.BL = BL;
            Console.Clear();
            while (true){
                Console.WriteLine("please enter your Username");
                string userName = Console.ReadLine();
                Console.WriteLine("please enter your Password");
                string Password = Console.ReadLine();
                
                try {
                    if (BL.connect(userName, Password))
                    {
                        new menu_frame(BL);
                    }
                    else {
                        Console.WriteLine();
                        Console.WriteLine("That Username/password is incorrect.");
                        Console.WriteLine();
                    }

                }
                catch (fourFailedLoginAttempts)
                {
                    Console.WriteLine();
                    Console.WriteLine("four unsuccessfuls login attempts.");
                    Console.WriteLine("Last chance remains");
                    Console.ReadLine();
                }
                catch (fiveFailedLoginAttempts)
                {
                    Console.WriteLine();
                    Console.WriteLine("Five unsuccessful login attempts");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
