using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sharedClasses;
using sharedClasses.Exceptions;

namespace BL
{
    class PasswordManagement
    {
    
        private String password;
        private Login l;


        internal PasswordManagement(string password,Login l1)
        {
            l = l1;
            this.password = password;
        }

        internal bool verification(string pass)
        {
            return pass.Equals(password);
        }

        internal bool IncludingNum(String str)
        {
            if (str.Contains("0") || str.Contains("1") || str.Contains("2") ||
                        str.Contains("3") || str.Contains("4") || str.Contains("5") ||
                        str.Contains("6") || str.Contains("7") || str.Contains("8") ||
                        str.Contains("9")) return true;
            return false;
        }

        internal string SetRandomPass()
        {
            String Table = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            String newpass = "";
            Random rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                int x = rnd.Next(0, 62);
                Char rndchar = Table[x];
                newpass = newpass + rndchar;
            }
            if (IncludingNum(newpass))
            {
                int x = rnd.Next(0, 62);
                Char rndchar = Table[x];
                newpass = newpass + rndchar;
            }
            else {
                int x = rnd.Next(0, 10);
                Char rndchar = Table[x];
                newpass = newpass + rndchar;
            }
            return newpass;
        }

        internal void ChangePass(String newpass1, String newpass2)
        {
            if (newpass1.Equals(newpass2)) {
                    if (legalPass(newpass1))
                    {
                        l.ChangePass(newpass1);
                    }
                    else {
                        throw new IllegalPassword();
                    }
                }
            else
                throw new passnotmatching();
        }

        internal bool legalPass(String pass)
        {
            if (pass.Length != 8) return false;
            return IncludingNum(pass);
        }
    }


}