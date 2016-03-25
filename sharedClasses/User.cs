using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sharedClasses
{
    public class User
    {
        private String UserName;
  

        public User(String Username)
        {
            this.UserName = Username;
       
        }

        public User(User u1)
        {
            this.UserName = u1.UserName;
       
        }



        public String getUserName()
        {
            return UserName;
        }

    }
}
