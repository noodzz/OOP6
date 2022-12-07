using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOP6
{
    public partial class Form1 : Form, Observer
    {
        CShapeArray shape;
        public static Size picbxSize;
        private int cnt;
        private string filename;

        protected void PicSize()
        {
            picbxSize = picbx.Size;
        }
        public Form1()
        {
            InitializeComponent();
            shape = new CShapeArray();
            PicSize();
            picbx.MouseWheel += Picbx_MouseWheel;
            cnt = 0;
         
        }

        private void Picbx_MouseWheel(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < shape.Count; i++)
                if (shape[i].IsSelected)
                {
                    if (e.Delta > 0) shape[i].Increase();
                    else shape[i].Decrease();

                }
            picbx.Invalidate();
        }

        bool drawRectangle = false;
        bool drawCircle = false;
        bool drawTriangle = false;
        
        private void btnrect_Click(object sender, EventArgs e)
        {
            drawRectangle = true;
            drawCircle = false;
            drawTriangle = false;
        }

        private void btncircle_Click(object sender, EventArgs e)
        {
            drawCircle = true;
            drawRectangle = false;
            drawTriangle = false;
        }

        private void SelectShape(PointF selected_point)
        {
            for (int i = 0; i < shape.Count; i++)
            {
                shape[i].IsSelected = shape[i].Contains(selected_point);
                shape[i].NotifySelect();
                
            }
        }
        private bool AllowShape(PointF p)
        {
            bool flag = true;
            for (int i = 0; i < shape.Count; i++)
            {
                flag = shape[i].ShapeIsAllowed(p);
                if (flag == false) break;
            }
            return flag;
        }

        private void picbx_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!AllowShape(e.Location))
                {
                    if (ModifierKeys == Keys.Control)
                    {
                        for (int i = 0; i < shape.Count; i++)
                        {
                            if (shape[i].Contains(e.Location))
                            {
                                shape[i].IsSelected = true;
                                shape[i].NotifySelect();
                            }

                        }
                    }
                    else SelectShape(e.Location);
                }
                else
                {
                    if (drawRectangle)
                    {
                        CRectangle rect = new CRectangle(e.X, e.Y);
                        if (rect.HitWalls() == false)
                        {
                            rect.AddObserver(this);
                            shape.Add(rect);
                            rect.SetColor(btncolor.BackColor);
                        }
                    }
                    else if (drawCircle)
                    {
                        CCircle c = new CCircle(e.X, e.Y);
                        if (c.HitWalls() == false)
                        {
                            c.AddObserver(this);
                            shape.Add(c);
                            c.SetColor(btncolor.BackColor);
                        }
                    }
                    else if (drawTriangle)
                    {
                        CTriangle t = new CTriangle(e.X, e.Y);
                        if (t.HitWalls() == false)
                        {
                            t.AddObserver(this);
                            shape.Add(t);
                            t.SetColor(btncolor.BackColor);
                        }
                    }
                    SelectShape(e.Location);
                }
            }
            TouchSticky();
            picbx.Invalidate();
        }

        private void picbx_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < shape.Count; i++)
                shape[i].Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {
                for (int i = shape.Count - 1; i >= 0; i--)
                    if (shape[i].IsSelected)
                    {
                        shape.RemoveAt(i);
                    }
            }
            else if (e.KeyCode == Keys.Add)
            {
                for (int i = shape.Count - 1; i >= 0; i--)
                    if (shape[i].IsSelected)
                        shape[i].Increase();
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                for (int i = shape.Count - 1; i >= 0; i--)
                    if (shape[i].IsSelected)
                        shape[i].Decrease();
            }
            else if (e.KeyCode == Keys.W)
            {
                for (int i = shape.Count - 1; i >= 0; i--)
                    if (shape[i].IsSelected && shape[i].IsMovable)
                    {
                        shape[i].Move(0, 1);
                       
                    }
            }
            else if (e.KeyCode == Keys.S)
            {
                for (int i = shape.Count - 1; i >= 0; i--)
                    if (shape[i].IsSelected && shape[i].IsMovable)
                    {
                        shape[i].Move(0, -1);
                       
                    }
                
            }
            else if (e.KeyCode == Keys.A)
            {
                for (int i = shape.Count - 1; i >= 0; i--)
                { 
                    if (shape[i].IsSelected && shape[i].IsMovable)
                    {
                        shape[i].Move(-1, 0);
                    }
                    
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                for (int i = shape.Count - 1; i >= 0; i--)
                {
                    if (shape[i].IsSelected && shape[i].IsMovable)
                    {
                        shape[i].Move(1, 0);
                    }
                    
                }
            }
            TouchSticky();
            picbx.Invalidate();
        }

        private void btn_choosecol_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            for (int i = 0; i < shape.Count; i++)
                if (shape[i].IsSelected)
                {
                    shape[i].SetColor(colorDialog1.Color);
                    btncolor.BackColor = shape[i].GetColor();
                    shape[i].IsSelected = false;
                }
            picbx.Invalidate();
        }

        private void btntri_Click(object sender, EventArgs e)
        {
            drawTriangle = true;
            drawCircle = false;
            drawRectangle = false;
        }

        void Observer.onSubjectAdd(Shapes who)
        {
            TreeNode node = new TreeNode(who.GetType().Name + cnt);
            node.Name = who.GetType().Name + who.GetHashCode();
            if (who is CGroup)
                processNode(node, who);
            tree.Nodes.Add(node);
            cnt++;
        }

        void Observer.onSubjectRemove(Shapes who)
        {
            cnt--;
            TreeNode[] nodes = tree.Nodes.Find(who.GetType().Name + who.GetHashCode(), true);
            if (nodes.Length > 0)
                tree.Nodes.Remove(nodes[0]);
        }

        void Observer.onSubjectSelect(Shapes who)
        {
            TreeNode[] t = tree.Nodes.Find(who.GetType().Name + who.GetHashCode(), true);
            if (who.IsSelected)
            {
                t[0].Checked = true;
            }
            else t[0].Checked = false;

        }
        private void processNode(TreeNode tn, Shapes o)
        {
            if (o is CGroup)
            {
                for (int i = 0; i < (o as CGroup).GetCount(); i++)
                {
                    Shapes oi = (o as CGroup)[i];
                    TreeNode t = new TreeNode(oi.GetType().Name);
                    tn.Nodes.Add(t);
                    processNode(t, oi);
                }
            }
        }

        private void tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode t = e.Node;
            for (int i = 0; i < shape.Count; i++)
            {
                if (e.Node.Checked)
                {
                    shape[t.Index].IsSelected = true;
                }
                else shape[t.Index].IsSelected = false;
            }
            picbx.Invalidate();
        }

        private void btnstick_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < shape.Count; i++)
            {
                if (shape[i].IsSelected)
                    shape[i].IsSticky = true;
            }
            TouchSticky();
            tree.Invalidate();

        }
        private void TouchSticky()
        {
            
            for (int i = 0; i < shape.Count; i++)
            {
                if (shape[i].IsSticky)
                {
                    for (int j = 0; j < shape.Count; j++)
                    {
                        if (j != i && shape[j].IntersectVisit(shape[i]))
                        {
                            
                                shape[i].AddShapeObserver(shape[j]);
                        }
                    }
                    shape[i].NotifyIntersect();

                } 
            }
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            CGroup group = new CGroup(shape.Count);
            for (int i = shape.Count - 1; i >= 0; i--)
            {
                if (shape[i].IsSelected)
                {
                    group.addShape(shape[i]);
                    shape.RemoveAt(i);
                }

            }
            group.AddObserver(this);
            shape.Add(group);
            group.IsSelected = true;
            group.NotifySelect();

            
        }

        private void btnUngroup_Click(object sender, EventArgs e)
        {
            for (int i = shape.Count - 1; i >= 0; i--)
            {
                if (shape[i].IsSelected && shape[i] is CGroup)
                {
                    CGroup g = shape[i] as CGroup;
                    for (int j = 0; j < g.GetCount(); j++)
                    {
                        shape.Add(g[j]);
                        g[j].NotifySelect();
                    }
                    shape.RemoveAt(i);
                }
            }
            picbx.Invalidate();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            filename = saveFileDialog1.FileName;
            using (StreamWriter stream = new StreamWriter(filename))
            {
                shape.SaveCount(stream);
                for (int i = shape.Count - 1; i >= 0; i--)
                {
                    shape[i].Save(stream);
                    shape.RemoveAt(i);
                }
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            filename = openFileDialog1.FileName;
            using (StreamReader stream = new StreamReader(filename))
            {
                shape.LoadObjects(stream);
            }
            for (int i = 0; i < shape.Count; i++)
            {
                shape[i].AddObserver(this);
                shape[i].NotifyAdd();
                shape[i].NotifySelect();
            }
        }
    }
}
