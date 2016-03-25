using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using sharedClasses;

namespace PL
{
    class menu_frame
    {
        private BL_interface BL;
        internal menu_frame(BL_interface bl1)
        {
            BL=bl1;
            bool stay = true;
            Console.Clear();
            while (stay)
            {
                Console.WriteLine("welcome "+ BL.getuser().getUserName());
                Console.WriteLine();
                Console.WriteLine("press:");
                Console.WriteLine("1 for change Password");
                Console.WriteLine("2 for disconnect");
                Console.WriteLine();
                string s = Console.ReadLine();
                if (s.Equals("1"))
                {
                    new change_Password(BL);
                    Console.Clear();
                    
                }
                else if (s.Equals("2")) {
                    stay = false;
                    BL.disconnect();
                    Console.Clear();
                }
                else { 
                     Console.WriteLine();
                     Console.WriteLine("you type invalid prameter");
                     Console.WriteLine();
                     }
            }
        }
    }
}
