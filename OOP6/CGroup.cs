using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OOP6
{
    class CGroup : Shapes
    {
        private int _maxcount;
        private int _count;
        private Shapes[] _shapes;
        private RectangleF rect;
        public CGroup(int maxcount)
        {
            center.X = rect.X + rect.Width / 2;
            center.Y = rect.Y + rect.Height / 2;
            _maxcount = maxcount;
            _count = 0;
            _shapes = new Shapes[_maxcount];
            for (int i = 0; i < _maxcount; i++)
                _shapes[i] = null;

        }
        public bool addShape(Shapes shape)
        {
            if (_count >= _maxcount)
                return false;

            _count++;
            _shapes[_count - 1] = shape;
            return true;
        }
        public override bool Move(int dx, int dy)
        {
            PointF oldLoc = rect.Location;
            rect.X += dx;
            rect.Y -= dy;
            if (HitWalls())
            {
                rect.Location = oldLoc;
                return false;
            }
            else
            {
                NotifyMove(dx, dy);
                for (int i = 0; i < _count; i++)
                    _shapes[i].Move(dx, dy);
            }
            return true;
        }

        public override void Draw(Graphics g)
        {
            rect = GetRectangle();
            g.DrawRectangle(new Pen(c), rect.X, rect.Y, rect.Width, rect.Height);
            for (int i = 0; i < _count; i++)
            {
                _shapes[i].IsSelected = IsSelected;
                _shapes[i].IsSticky = IsSticky;
                _shapes[i].Draw(g);
            }
        }
        public override bool Contains(PointF p)
        {
            bool flag = false;
            for (int i = 0; i < _count; i++)
            {
                flag = _shapes[i].Contains(p);
                if (flag == true) return flag;

            }
            return flag;
        }
        public override void Increase()
        {
            var oldSize = rect.Size;
            rect.Inflate(5, 5);
            if (HitWalls())
            {
                rect.Size = oldSize;
            }
            else
            {
                for (int i = 0; i < _count; i++)
                    _shapes[i].Increase();
            }
        }
        public override bool Decrease()
        {
            bool flag = true;
            for (int i = 0; i < _count; i++)
            {
                if (_shapes[i].GetType().Name == "CGroup")
                    for (int j = 0; j < (_shapes[i] as CGroup)._count; j++)
                    {
                        flag = (_shapes[i] as CGroup)[j].Decrease();
                        if (!flag) return flag;
                    }
                else
                {
                    flag = _shapes[i].Decrease();
                    if (flag == false)
                    {
                        return flag;
                    }
                }
            }
            return flag;
        }
        public override bool ShapeIsAllowed(PointF p)
        {
            bool flag = true;
            for (int i = 0; i < _count; i++)
            {
                flag = _shapes[i].ShapeIsAllowed(p);
                if (flag == false)
                    return flag;
            }
            return flag;
        }
        public override bool HitWalls()
        {
            if ((rect.X + rect.Width >= maxWidth || rect.X <= 0 || rect.Y + rect.Height >= maxHeight
                || rect.Y <= 0))
                return true;
            else return false;
        }
        public override void Load(StreamReader stream)
        {
            CShapeArray arr = new CShapeArray();
            var c = Int32.Parse(stream.ReadLine());
            for (int i = 0; i < c; i++)
            {
                var code = stream.ReadLine();
                Shapes s = arr.CreateObject(code);
                s.Load(stream);
                addShape(s);
            }
        }
        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("G");
            stream.WriteLine(_count);
            for (int i = 0; i < _count; i++)
            {
                _shapes[i].Save(stream);
            }
        }
        protected override Shapes Clone()
        {
            CGroup g = new CGroup(_maxcount);
            for (int i = 0; i < _count; i++)
                g.addShape(this[i]);
            return g;
        }
        public override RectangleF GetRectangle()
        {
            RectangleF tmp = _shapes[0].GetRectangle();
            for (int i = 0; i < _count - 1; i++)
            {
                if (_shapes[i+1] != null)
                    tmp = RectangleF.Union(tmp, _shapes[i + 1].GetRectangle());  
                
            }
            center.X = rect.X + rect.Width / 2;
            center.Y = rect.Y + rect.Height / 2;
            return tmp;
        }
        public int GetCount()
        {
            return _count;
        }
        public Shapes this[int i]
        {
            get { return _shapes[i]; }
        }
        public override bool IntersectVisit(Shapes who)
        {
            bool flag = false;
            for (int i = 0; i < _count; i++)
            {
                flag = who.IntersectVisit(_shapes[i]);
                if (flag) return true;
            }
            return flag;
        }
        public override bool Intersect(CCircle c)
        {
            return IntersectVisit(c);
        }
        public override bool Intersect(CRectangle r)
        {
            return IntersectVisit(r);
        }
        public override bool Intersect(CTriangle t)
        {
            return IntersectVisit(t);
        }
    }
}
