using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sharedClasses;
using sharedClasses.Exceptions;
using DAL;

namespace BL
{
    class Login
    {
        internal User user;
        private PasswordManagement pm;
        private int tries;
        DALI DAL = new DALManager();

        internal Login(DALI DAL)
        {
            this.DAL = DAL;
            user = null;
            pm = null;
            tries = 0;
        }
        internal bool connect(String Username, String Password)
        {
            Boolean ans = false;
             try
                {
                    String Passwordsql = DAL.getpassword(Username);

                if (Passwordsql.Equals(Password))
                {
                    this.user = new User(Username);
                    this.pm = new PasswordManagement(Password, this);
                    this.tries = 0;
                    ans = true;
                }
                else {
                    tries++;
                    checktries();
                }
            }
            catch (nonExistentUser)
                {
                    tries = tries + 1;
                    checktries();
            }
            
            return ans;
        }
        internal void checktries()
        {
            if (tries == 4)
                throw new fourFailedLoginAttempts();
            else if (tries==5)
                throw new fiveFailedLoginAttempts();
        }

        internal PasswordManagement getPasswordManagement()
        {
            return pm;
        }


        internal void ChangePass(String newpass)
        {
            DAL.setpassword(user, newpass);
        }

        internal void disconnect()
        {
        user=null;
        pm=null;
        }
        

    }

}
