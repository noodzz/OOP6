using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace OOP6
{
    interface IObserverShapes
    {
        void onShapesMove(int dx, int dy);
        void onShapesIntersect();
    }
}
