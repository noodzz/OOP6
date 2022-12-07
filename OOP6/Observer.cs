using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OOP6
{
    interface Observer 
    {
        void onSubjectAdd(Shapes who);
        void onSubjectRemove(Shapes who);
        void onSubjectSelect(Shapes who);
    }
}
