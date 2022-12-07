using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace OOP6
{
    abstract class Shapes : IObserverShapes
    {
        protected internal PointF center;
        public bool IsSelected = false;
        public bool IsSticky = false;
        protected bool Notifying = false;
        public bool IsMovable = true;
        protected int maxWidth = Form1.picbxSize.Width;
        protected int maxHeight = Form1.picbxSize.Height;
        protected Color c = Color.Black;
        public abstract bool Contains(PointF p);
        public void SetColor(Color col)
        {
            c = col;
        }
        public Color GetColor()
        {
            return c;
        }
        public abstract void Draw(Graphics g);
        public abstract bool ShapeIsAllowed(PointF p);
        public abstract void Increase();
        public abstract bool Decrease();
        public virtual bool Move(int dx, int dy)
        {
            PointF oldCenter = center;
            center.X += dx;
            center.Y -= dy;
            if (HitWalls())
            {
                center = oldCenter;
                return false;
            }
            else
            {
                if (this.IsSticky)
                    NotifyMove(dx, dy);
                return true;
            }
            
        }
        public abstract bool HitWalls();
        public abstract void Save(StreamWriter stream);
        public abstract void Load(StreamReader stream);
        protected abstract Shapes Clone();
        public abstract RectangleF GetRectangle();
        private List<Observer> observers;
        private List<IObserverShapes> ShapeObservers;
        public Shapes()
        {
            observers = new List<Observer>();
            ShapeObservers = new List<IObserverShapes>();
        }
        public void AddObserver(Observer o)
        {
            observers.Add(o);
        }
        public void AddShapeObserver(IObserverShapes o)
        {
            ShapeObservers.Add(o);

        }
        public void RemoveShapeObserver(IObserverShapes o)
        {
            ShapeObservers.Remove(o);
        }
        public void NotifyAdd()
        {
            foreach (Observer o in observers)
                o.onSubjectAdd(this);
        }
        public void NotifyRemove()
        {
            foreach (Observer o in observers)
                o.onSubjectRemove(this);
        }

        public void NotifySelect()
        {
            foreach (Observer o in observers)
                o.onSubjectSelect(this);
        }
        public void NotifyMove(int dx, int dy)
        {
            foreach (IObserverShapes o in ShapeObservers)
            {
                o.onShapesMove(dx, dy);
            }
         
        }
        public void NotifyIntersect()
        {
            foreach (IObserverShapes o in ShapeObservers)
            {
                o.onShapesIntersect();
            }
        }
        public abstract bool IntersectVisit(Shapes other);
        public abstract bool Intersect(CCircle c);
        public abstract bool Intersect(CRectangle r);
        public abstract bool Intersect(CTriangle t);
  
        void IObserverShapes.onShapesMove(int dx, int dy)
        {
            Move(dx, dy);
        }
        void IObserverShapes.onShapesIntersect()
        {
            this.IsMovable = false;
        }

    }
    class CCircle : Shapes
    {
        private float radius = 35;
        private RectangleF rect;
        public CCircle()
        {
            center = new PointF(0, 0);
        }
        public CCircle(float _x, float _y)
        {
            center = new PointF(_x, _y);
            rect = new RectangleF(_x - radius, _y - radius, radius * 2, radius * 2); 
        }
        public CCircle(CCircle c)
        {
            center = c.center;
            radius = c.radius;
            rect = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }
        public override bool Contains(PointF p)
        {
            return (center.X - p.X) * (center.X - p.X)
                + (center.Y - p.Y) * (center.Y - p.Y) <= radius * radius;
        }

        public override void Draw(Graphics g)
        {
            if (center.X != rect.X + radius || center.Y != rect.Y + radius)
            {
                rect.X = center.X - radius;
                rect.Y = center.Y - radius;
            }
            if (!HitWalls())
            {
                g.DrawEllipse(new Pen(c), rect);
                if (IsSelected)
                    g.FillEllipse(Brushes.Red, rect);
                if (IsSticky)
                    g.FillEllipse(Brushes.Gray, rect);
            }
        }
        public override bool ShapeIsAllowed(PointF newCircle)
        {
            return !Contains(newCircle);
        }
        public override void Increase()
        {
            radius += 5;
            if (HitWalls())
            {
                radius -= 5;
            }
            rect = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }
        public override bool Decrease()
        {
            if (radius - 5 > 0)
            {
                radius -= 5;
                rect = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
                return true;
            }
            else return false;
        }
        public override bool HitWalls()
        {
            if (center.X + radius >= maxWidth || center.X - radius <= 0 || center.Y + radius >= maxHeight
                || center.Y - radius <= 0)
                return true;
            else return false;

        }
        public override void Save(StreamWriter stream)
        {
            string[] args = new string[] { center.X.ToString(), center.Y.ToString(), radius.ToString(), IsSelected.ToString(), c.ToArgb().ToString() };

            stream.WriteLine("C");
            stream.WriteLine("{0} {1} {2} {3} {4}", args);

        }
        public override void Load(StreamReader stream)
        {
            var parts = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            center.X = float.Parse(parts[0]);
            center.Y = float.Parse(parts[1]);
            radius = float.Parse(parts[2]);
            IsSelected = bool.Parse(parts[3]);
            c = Color.FromArgb(Int32.Parse(parts[4]));
            rect = new RectangleF(center.X - radius, center.Y - radius, radius * 2, radius * 2);
        }
        protected override Shapes Clone()
        {
            CCircle c = new CCircle(this);
            return c;
        }
        public float GetRadius()
        {
            return radius;
        }
        public override RectangleF GetRectangle()
        {
            return rect;
        }
        public override bool Intersect(CCircle c)
        {
            if (Math.Sqrt(Math.Pow(center.X - c.center.X, 2) + Math.Pow(center.Y - c.center.Y, 2)) <= this.radius + c.radius)
                return true;
            else return false;
        }
        public override bool Intersect(CRectangle rect)
        {
            var distX = Math.Abs(this.center.X - rect.center.X);
            var distY = Math.Abs(this.center.Y - rect.center.Y);

            if (distX > (rect.Width / 2 + this.radius)) { return false; }
            if (distY > (rect.Height / 2 + this.radius)) { return false; }

            if (distX <= (rect.Width / 2)) { return true; }
            if (distY <= (rect.Height / 2)) { return true; }
            return false;

        }
        public override bool Intersect(CTriangle tr)
        {
            if (Math.Sqrt(Math.Pow(center.X - tr.center.X, 2) + Math.Pow(center.Y - tr.center.Y, 2)) <= this.radius + tr.GetSmallRadius())
                return true;
            else return false;
        }
        public override bool IntersectVisit(Shapes who)
        {
            return who.Intersect(this);
        }


    }
    class CRectangle : Shapes
    {
        RectangleF rect;
        float width = 70;
        float height = 40;
        public float Width
        {
            get
            {
                return width;
            }
        }
        public float Height
        {
            get
            {
                return height;
            }
        }
        CRectangle()
        {
            center = new PointF(0, 0);
            rect = new RectangleF(0, 0, width, height);
        }
        public CRectangle(CRectangle r)
        {
            center = new PointF(r.center.X, r.center.Y);
            width = r.width;
            height = r.height;
            rect = new RectangleF(r.center.X - width / 2, r.center.Y - height / 2, width, height);

        }
        public CRectangle(float x, float y)
        {
            center = new PointF(x, y);
            rect = new RectangleF(x - width / 2, y - height / 2, width, height);

        }
        public override bool Contains(PointF p)
        {
            return (p.X > rect.Left && p.X < rect.Right && p.Y < rect.Bottom && p.Y > rect.Top);
        }
        public override void Draw(Graphics g)
        {
            if (!HitWalls())
            {
                if (center.X != rect.X + width / 2 || center.Y != rect.Y + height / 2)
                {
                    rect.X = center.X - width / 2;
                    rect.Y = center.Y - height / 2;
                }
                g.DrawRectangle(new Pen(c), rect.X, rect.Y, rect.Width, rect.Height);
                if (IsSelected)
                    g.FillRectangle(Brushes.Red, rect.X, rect.Y, rect.Width, rect.Height);
                if (IsSticky)
                    g.FillRectangle(Brushes.Gray, rect.X, rect.Y, rect.Width, rect.Height);
            }
          
        }
        public override bool ShapeIsAllowed(PointF newRect)
        {
            return !Contains(newRect);
        }
        public override void Increase()
        {
            float oldHeight = height;
            float oldWidth = width;
            height += 5;
            width += 5;
            if (HitWalls())
            {
                height = oldHeight;
                width = oldWidth;
            }
            rect = new RectangleF(center.X - width / 2, center.Y - height / 2, width, height);
        }
        public override bool Decrease()
        {
            if (height - 5 <= 0 || width - 5 <= 0) return false;
            height -= 5;
            width -= 5;
            rect = new RectangleF(center.X - width / 2, center.Y - height / 2, width, height);
            return true;
        }
        public override bool HitWalls()
        {
            if (center.X + width / 2 >= maxWidth || center.X - width / 2 <= 0 || center.Y + height / 2 >= maxHeight || center.Y - height / 2 <= 0)
                return true;
            else return false;
        }
        public override void Save(StreamWriter stream)
        {
            string[] args = new string[] { center.X.ToString(), center.Y.ToString(), width.ToString(), height.ToString(), IsSelected.ToString(), c.ToArgb().ToString() };

            stream.WriteLine("R");
            stream.WriteLine("{0} {1} {2} {3} {4} {5}", args);
        }
        public override void Load(StreamReader stream)
        {
            var parts = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            center.X = float.Parse(parts[0]);
            center.Y = float.Parse(parts[1]);
            rect.Width = float.Parse(parts[2]);
            rect.Height = float.Parse(parts[3]);
            IsSelected = bool.Parse(parts[4]);
            c = Color.FromArgb(Int32.Parse(parts[5]));

        }
        protected override Shapes Clone()
        {
            CRectangle r = new CRectangle(this);
            return r;
        }
        public override RectangleF GetRectangle()
        {
            return rect;
        }
        public override bool IntersectVisit(Shapes who)
        {
            return who.Intersect(this);
        }
        public override bool Intersect(CCircle c)
        {
            return c.Intersect(this);
        }
        public override bool Intersect(CRectangle r)
        {
            RectangleF r1 = GetRectangle();
            RectangleF r2 = r.GetRectangle();
            return r1.IntersectsWith(r2);
        }
        public override bool Intersect(CTriangle t)
        {
            var distX = Math.Abs(this.center.X - t.center.X );
            var distY = Math.Abs(this.center.Y - t.center.Y);

            if (distX > (this.width / 2 + t.GetSmallRadius())) { return false; }
            if (distY > (this.height / 2 + t.GetSmallRadius())) { return false; }

            if (distX <= (width / 2)) { return true; }
            if (distY <= (height / 2)) { return true; }
            return false;
        }

    }
    class CTriangle : Shapes
    {
        private float a = 60;
        private float radius;
        private float r;
        PointF p1;
        PointF p2;
        PointF p3;
        PointF[] points;
        public CTriangle(float x, float y)
        {
            center = new PointF(x, y);
            CountRadius();
            p1 = new PointF(center.X - a / 2, center.Y + r);
            p2 = new PointF(center.X, center.Y - radius);
            p3 = new PointF(center.X + a / 2, center.Y + r);
            points = new PointF[] { p1, p2, p3 };
        }
        public CTriangle(CTriangle t)
        {
            center = t.center;
            a = t.a;
            radius = t.radius;
            r = t.r;
            p1 = new PointF(center.X - a / 2, center.Y + r);
            p2 = new PointF(center.X, center.Y - radius);
            p3 = new PointF(center.X + a / 2, center.Y + r);
            points = new PointF[] { p1, p2, p3 };

        }
        public override bool Contains(PointF p)
        {
            var a = (p1.X - p.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p1.Y - p.Y);
            var b = (p2.X - p.X) * (p3.Y - p2.Y) - (p3.X - p2.X) * (p2.Y - p.Y);
            var c = (p3.X - p.X) * (p1.Y - p3.Y) - (p1.X - p3.X) * (p3.Y - p.Y);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
                return true;
            else
                return false;
        }
        private void ChangePoints()
        {
            p1.X = center.X - a / 2;
            p1.Y = center.Y + r;
            p2.X = center.X;
            p2.Y = center.Y - radius;
            p3.X = center.X + a / 2;
            p3.Y = center.Y + r;
            points = new PointF[] { p1, p2, p3 };

        }
        public override void Draw(Graphics g)
        {
            if (center.X != p2.X || center.Y != p2.Y + radius || a != 60)
            {
                ChangePoints();
            }
            if (!HitWalls())
            {
                g.DrawPolygon(new Pen(c), points);
                if (IsSelected)
                    g.FillPolygon(Brushes.Red, points);
                if (IsSticky)
                    g.FillPolygon(Brushes.Gray, points);
            }
        
        }
        private void CountRadius()
        {
            radius = (float)(a / Math.Sqrt(3));
            r = (float)(a / (2 * Math.Sqrt(3)));
        }
        public override bool ShapeIsAllowed(PointF p)
        {
            return !Contains(p);
        }
        public override void Increase()
        {
            float oldA = a;
            a += 5;
            if (HitWalls())
            {
                a = oldA;
                CountRadius();
            }
            ChangePoints();
        }
        public override bool Decrease()
        {
            if (radius - 5 <= 0) return false;
            a -= 5;
            CountRadius();
            ChangePoints();
            return true;
        }
        public override bool HitWalls()
        {
            CountRadius();
            if (center.X + a / 2 >= maxWidth || center.X - a / 2 <= 0 || center.Y + r >= maxHeight || center.Y - radius <= 0)
                return true;
            else return false;
        }
        public override void Save(StreamWriter stream)
        {
            string[] args = new string[] { center.X.ToString(), center.Y.ToString(), a.ToString(), radius.ToString(), r.ToString(), IsSelected.ToString(), c.ToArgb().ToString() };

            stream.WriteLine("T");
            stream.WriteLine("{0} {1} {2} {3} {4} {5} {6}", args);
        }
        public override void Load(StreamReader stream)
        {
            var parts = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            center.X = float.Parse(parts[0]);
            center.Y = float.Parse(parts[1]);
            radius = float.Parse(parts[3]);
            r = float.Parse(parts[4]);
            IsSelected = bool.Parse(parts[5]);
            c = Color.FromArgb(Int32.Parse(parts[6]));
            a = float.Parse(parts[2]);

        }
        protected override Shapes Clone()
        {
            CTriangle t = new CTriangle(this);
            return this;
        }
        public override RectangleF GetRectangle()
        {
            RectangleF rect = new RectangleF(center.X - a / 2, center.Y - radius, a, (float)Math.Sqrt(a*a-a*a/4));
            return rect;
        }
        public PointF[] GetPoints()
        {
            return points;
        }
        public float GetSmallRadius()
        {
            return r;
        }
        public override bool IntersectVisit(Shapes who)
        {
            return who.Intersect(this);
        }
        public override bool Intersect(CCircle c)
        {
            return c.Intersect(this);
        }
        public override bool Intersect(CRectangle t)
        {
            return t.Intersect(this);
        }
        public override bool Intersect(CTriangle t)
        {
            if (Math.Sqrt(Math.Pow(center.X - t.center.X, 2) + Math.Pow(center.Y - t.center.Y, 2)) <= this.r + t.r)
                return true;
            else return false;
        }

    }

}
