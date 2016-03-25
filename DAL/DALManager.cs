using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sharedClasses;

namespace DAL
{
    public class DALManager : DALI
    {
        public string getpassword(string username)
        {
            return sqlConnector.getpassword(username);
        }

        public void setpassword(User u1, String Password)
        {
            sqlConnector.setpassword(u1, Password);
        }

    }
}
