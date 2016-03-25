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
    public class BL_manager : BL_interface
    {
        private Login l1 ;
        private PasswordManagement pm;
        private DALI DAL;

        public BL_manager(DALI DAL)
        {
            this.DAL = DAL;
            l1 = new Login(DAL);
        }

        public User getuser()
        {
            if (l1.user == null)
                throw new nonExistentUser();
            return l1.user;
        }

        public bool legalPass(string Password1)
        {
            return pm.legalPass(Password1);
        }

        public bool connect(String username, string password)
        {
            bool ans= l1.connect(username, password);
            pm = l1.getPasswordManagement();
            return ans;
        }

        public string SetRandomPass()
        {
            return pm.SetRandomPass();
        }

        public void disconnect()
        {
            pm = null;
            l1.disconnect();
        }

        public void ChangePass(String newpass1, String newpass2)
        {
            pm.ChangePass(newpass1, newpass2);
        }

        public bool verification(string pass)
        {
            return pm.verification(pass);
        }

    }
}
