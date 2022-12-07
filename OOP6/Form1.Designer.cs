
namespace OOP6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btncircle = new System.Windows.Forms.ToolStripButton();
            this.btnrect = new System.Windows.Forms.ToolStripButton();
            this.btntri = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_choosecol = new System.Windows.Forms.ToolStripButton();
            this.btncolor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnstick = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGroup = new System.Windows.Forms.ToolStripButton();
            this.btnUngroup = new System.Windows.Forms.ToolStripButton();
            this.btnload = new System.Windows.Forms.ToolStripButton();
            this.btnsave = new System.Windows.Forms.ToolStripButton();
            this.tree = new System.Windows.Forms.TreeView();
            this.picbx = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbx)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Menu;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 475);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1060, 28);
            this.panel2.TabIndex = 1;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btncircle,
            this.btnrect,
            this.btntri,
            this.toolStripSeparator1,
            this.btn_choosecol,
            this.btncolor,
            this.toolStripSeparator2,
            this.btnstick,
            this.toolStripSeparator3,
            this.btnGroup,
            this.btnUngroup,
            this.btnload,
            this.btnsave});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(1);
            this.menu.ShowItemToolTips = false;
            this.menu.Size = new System.Drawing.Size(1060, 29);
            this.menu.TabIndex = 3;
            // 
            // btncircle
            // 
            this.btncircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btncircle.Image = global::OOP6.Properties.Resources.new_moon2;
            this.btncircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncircle.Name = "btncircle";
            this.btncircle.Size = new System.Drawing.Size(29, 24);
            this.btncircle.Text = "toolStripButton1";
            this.btncircle.Click += new System.EventHandler(this.btncircle_Click);
            // 
            // btnrect
            // 
            this.btnrect.AutoToolTip = false;
            this.btnrect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnrect.Image = global::OOP6.Properties.Resources.rectangle3;
            this.btnrect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnrect.Name = "btnrect";
            this.btnrect.Size = new System.Drawing.Size(29, 24);
            this.btnrect.Text = "toolStripButton2";
            this.btnrect.Click += new System.EventHandler(this.btnrect_Click);
            // 
            // btntri
            // 
            this.btntri.AutoToolTip = false;
            this.btntri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btntri.Image = global::OOP6.Properties.Resources.plain_triangle2;
            this.btntri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btntri.Name = "btntri";
            this.btntri.Size = new System.Drawing.Size(29, 24);
            this.btntri.Text = "toolStripButton3";
            this.btntri.Click += new System.EventHandler(this.btntri_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btn_choosecol
            // 
            this.btn_choosecol.AutoToolTip = false;
            this.btn_choosecol.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_choosecol.Image = global::OOP6.Properties.Resources.color_palette__1_;
            this.btn_choosecol.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_choosecol.Name = "btn_choosecol";
            this.btn_choosecol.Size = new System.Drawing.Size(29, 24);
            this.btn_choosecol.Text = "toolStripButton4";
            this.btn_choosecol.Click += new System.EventHandler(this.btn_choosecol_Click);
            // 
            // btncolor
            // 
            this.btncolor.AutoToolTip = false;
            this.btncolor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.btncolor.Enabled = false;
            this.btncolor.Image = ((System.Drawing.Image)(resources.GetObject("btncolor.Image")));
            this.btncolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btncolor.Name = "btncolor";
            this.btncolor.Size = new System.Drawing.Size(29, 24);
            this.btncolor.Text = "toolStripButton5";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnstick
            // 
            this.btnstick.BackColor = System.Drawing.Color.Transparent;
            this.btnstick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnstick.Image = ((System.Drawing.Image)(resources.GetObject("btnstick.Image")));
            this.btnstick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnstick.Name = "btnstick";
            this.btnstick.Size = new System.Drawing.Size(91, 24);
            this.btnstick.Text = "Make Sticky";
            this.btnstick.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnstick.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnstick.Click += new System.EventHandler(this.btnstick_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnGroup
            // 
            this.btnGroup.AutoToolTip = false;
            this.btnGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnGroup.Image")));
            this.btnGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(54, 24);
            this.btnGroup.Text = "Group";
            this.btnGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnUngroup
            // 
            this.btnUngroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUngroup.Image = ((System.Drawing.Image)(resources.GetObject("btnUngroup.Image")));
            this.btnUngroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUngroup.Name = "btnUngroup";
            this.btnUngroup.Size = new System.Drawing.Size(71, 24);
            this.btnUngroup.Text = "Ungroup";
            this.btnUngroup.Click += new System.EventHandler(this.btnUngroup_Click);
            // 
            // btnload
            // 
            this.btnload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnload.Image = global::OOP6.Properties.Resources.download;
            this.btnload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(29, 24);
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btnsave
            // 
            this.btnsave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnsave.Image = global::OOP6.Properties.Resources.diskette;
            this.btnsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(29, 24);
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // tree
            // 
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree.CheckBoxes = true;
            this.tree.Location = new System.Drawing.Point(890, 35);
            this.tree.Margin = new System.Windows.Forms.Padding(0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(172, 440);
            this.tree.TabIndex = 4;
            this.tree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterCheck);
            // 
            // picbx
            // 
            this.picbx.BackColor = System.Drawing.Color.White;
            this.picbx.Location = new System.Drawing.Point(0, 35);
            this.picbx.Margin = new System.Windows.Forms.Padding(1);
            this.picbx.Name = "picbx";
            this.picbx.Size = new System.Drawing.Size(887, 440);
            this.picbx.TabIndex = 2;
            this.picbx.TabStop = false;
            this.picbx.Paint += new System.Windows.Forms.PaintEventHandler(this.picbx_Paint);
            this.picbx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picbx_MouseClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 503);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.picbx);
            this.Controls.Add(this.tree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint App";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picbx;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btncircle;
        private System.Windows.Forms.ToolStripButton btnrect;
        private System.Windows.Forms.ToolStripButton btntri;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btn_choosecol;
        private System.Windows.Forms.ToolStripButton btncolor;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnstick;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnGroup;
        private System.Windows.Forms.ToolStripButton btnUngroup;
        private System.Windows.Forms.ToolStripButton btnsave;
        private System.Windows.Forms.ToolStripButton btnload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

