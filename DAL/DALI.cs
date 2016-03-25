using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sharedClasses;

namespace DAL
{
    public interface DALI
    {
        string getpassword(string username);
        void setpassword(User u1, String Password);
    }
}
