using Coursework1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework1.Service
{
     internal interface ICsvHelper
    {
        List<User> GetUsers();
    }
}
