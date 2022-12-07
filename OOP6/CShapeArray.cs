using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6
{
    class CShapeArray : MyStorage
    {
        public override Shapes CreateObject(string code)
        {
            Shapes shape = null;
            switch(code)
            {
                case "C":
                    shape = new CCircle(0, 0);
                    break;
                case "T":
                    shape = new CTriangle(0, 0);
                    break;
                case "R":
                    shape = new CRectangle(0, 0);
                    break;
                case "G":
                    shape = new CGroup(Count*10);
                    break;
            }
            return shape;
        }
    }
}
