namespace MAC_Example
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnFechar = new Guna.UI2.WinForms.Guna2Button();
            this.btnRelatórios = new Guna.UI2.WinForms.Guna2Button();
            this.btnClientes = new Guna.UI2.WinForms.Guna2Button();
            this.btnVendas = new Guna.UI2.WinForms.Guna2Button();
            this.btnEstoque = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.ImgSlide = new System.Windows.Forms.PictureBox();
            this.panelContener = new System.Windows.Forms.Panel();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2CustomGradientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 570);
            this.panel1.TabIndex = 0;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 18;
            this.guna2CustomGradientPanel1.Controls.Add(this.btnFechar);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnRelatórios);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnClientes);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnVendas);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnEstoque);
            this.guna2CustomGradientPanel1.Controls.Add(this.pictureBox2);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnHome);
            this.guna2CustomGradientPanel1.Controls.Add(this.ImgSlide);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(13, 8);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.Parent = this.guna2CustomGradientPanel1;
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(86, 551);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnFechar.BorderRadius = 24;
            this.btnFechar.BorderThickness = 1;
            this.btnFechar.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnFechar.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnFechar.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.CheckedState.Image")));
            this.btnFechar.CheckedState.Parent = this.btnFechar;
            this.btnFechar.CustomImages.Parent = this.btnFechar;
            this.btnFechar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.HoverState.Parent = this.btnFechar;
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.Location = new System.Drawing.Point(14, 498);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.ShadowDecoration.Parent = this.btnFechar;
            this.btnFechar.Size = new System.Drawing.Size(60, 50);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.UseTransparentBackground = true;
            this.btnFechar.Click += new System.EventHandler(this.guna2Button6_Click);
            // 
            // btnRelatórios
            // 
            this.btnRelatórios.BackColor = System.Drawing.Color.Transparent;
            this.btnRelatórios.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnRelatórios.BorderRadius = 24;
            this.btnRelatórios.BorderThickness = 1;
            this.btnRelatórios.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRelatórios.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnRelatórios.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnRelatórios.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatórios.CheckedState.Image")));
            this.btnRelatórios.CheckedState.Parent = this.btnRelatórios;
            this.btnRelatórios.CustomImages.Parent = this.btnRelatórios;
            this.btnRelatórios.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnRelatórios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRelatórios.ForeColor = System.Drawing.Color.White;
            this.btnRelatórios.HoverState.Parent = this.btnRelatórios;
            this.btnRelatórios.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatórios.Image")));
            this.btnRelatórios.Location = new System.Drawing.Point(21, 409);
            this.btnRelatórios.Name = "btnRelatórios";
            this.btnRelatórios.ShadowDecoration.Parent = this.btnRelatórios;
            this.btnRelatórios.Size = new System.Drawing.Size(60, 50);
            this.btnRelatórios.TabIndex = 4;
            this.btnRelatórios.UseTransparentBackground = true;
            this.btnRelatórios.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnRelatórios.Click += new System.EventHandler(this.btnRelatórios_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.Transparent;
            this.btnClientes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnClientes.BorderRadius = 24;
            this.btnClientes.BorderThickness = 1;
            this.btnClientes.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnClientes.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnClientes.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnClientes.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.CheckedState.Image")));
            this.btnClientes.CheckedState.Parent = this.btnClientes;
            this.btnClientes.CustomImages.Parent = this.btnClientes;
            this.btnClientes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.HoverState.Parent = this.btnClientes;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.Location = new System.Drawing.Point(21, 330);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.ShadowDecoration.Parent = this.btnClientes;
            this.btnClientes.Size = new System.Drawing.Size(60, 50);
            this.btnClientes.TabIndex = 3;
            this.btnClientes.UseTransparentBackground = true;
            this.btnClientes.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnClientes.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.BackColor = System.Drawing.Color.Transparent;
            this.btnVendas.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnVendas.BorderRadius = 24;
            this.btnVendas.BorderThickness = 1;
            this.btnVendas.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnVendas.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnVendas.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnVendas.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnVendas.CheckedState.Image")));
            this.btnVendas.CheckedState.Parent = this.btnVendas;
            this.btnVendas.CustomImages.Parent = this.btnVendas;
            this.btnVendas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnVendas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVendas.ForeColor = System.Drawing.Color.White;
            this.btnVendas.HoverState.Parent = this.btnVendas;
            this.btnVendas.Image = ((System.Drawing.Image)(resources.GetObject("btnVendas.Image")));
            this.btnVendas.Location = new System.Drawing.Point(21, 251);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.ShadowDecoration.Parent = this.btnVendas;
            this.btnVendas.Size = new System.Drawing.Size(60, 50);
            this.btnVendas.TabIndex = 2;
            this.btnVendas.UseTransparentBackground = true;
            this.btnVendas.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnVendas.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.Transparent;
            this.btnEstoque.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnEstoque.BorderRadius = 24;
            this.btnEstoque.BorderThickness = 1;
            this.btnEstoque.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnEstoque.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnEstoque.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnEstoque.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnEstoque.CheckedState.Image")));
            this.btnEstoque.CheckedState.Parent = this.btnEstoque;
            this.btnEstoque.CustomImages.Parent = this.btnEstoque;
            this.btnEstoque.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnEstoque.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEstoque.ForeColor = System.Drawing.Color.White;
            this.btnEstoque.HoverState.Parent = this.btnEstoque;
            this.btnEstoque.Image = ((System.Drawing.Image)(resources.GetObject("btnEstoque.Image")));
            this.btnEstoque.Location = new System.Drawing.Point(21, 172);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.ShadowDecoration.Parent = this.btnEstoque;
            this.btnEstoque.Size = new System.Drawing.Size(60, 50);
            this.btnEstoque.TabIndex = 1;
            this.btnEstoque.UseTransparentBackground = true;
            this.btnEstoque.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnEstoque.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(23, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnHome.BorderRadius = 24;
            this.btnHome.BorderThickness = 1;
            this.btnHome.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnHome.Checked = true;
            this.btnHome.CheckedState.BorderColor = System.Drawing.Color.White;
            this.btnHome.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnHome.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.CheckedState.Image")));
            this.btnHome.CheckedState.Parent = this.btnHome;
            this.btnHome.CustomImages.Parent = this.btnHome;
            this.btnHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(86)))), ((int)(((byte)(1)))));
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.HoverState.Parent = this.btnHome;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(21, 93);
            this.btnHome.Name = "btnHome";
            this.btnHome.ShadowDecoration.Parent = this.btnHome;
            this.btnHome.Size = new System.Drawing.Size(60, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.UseTransparentBackground = true;
            this.btnHome.CheckedChanged += new System.EventHandler(this.guna2Button1_CheckedChanged);
            this.btnHome.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ImgSlide
            // 
            this.ImgSlide.BackColor = System.Drawing.Color.Transparent;
            this.ImgSlide.Image = ((System.Drawing.Image)(resources.GetObject("ImgSlide.Image")));
            this.ImgSlide.Location = new System.Drawing.Point(38, 10);
            this.ImgSlide.Name = "ImgSlide";
            this.ImgSlide.Size = new System.Drawing.Size(72, 217);
            this.ImgSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgSlide.TabIndex = 0;
            this.ImgSlide.TabStop = false;
            // 
            // panelContener
            // 
            this.panelContener.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContener.Location = new System.Drawing.Point(100, 0);
            this.panelContener.Name = "panelContener";
            this.panelContener.Size = new System.Drawing.Size(796, 570);
            this.panelContener.TabIndex = 1;
            this.panelContener.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContener_Paint);
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 30;
            this.guna2Elipse1.TargetControl = this;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(896, 570);
            this.Controls.Add(this.panelContener);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgSlide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private System.Windows.Forms.PictureBox ImgSlide;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Button btnFechar;
        private Guna.UI2.WinForms.Guna2Button btnRelatórios;
        private Guna.UI2.WinForms.Guna2Button btnClientes;
        private Guna.UI2.WinForms.Guna2Button btnVendas;
        private Guna.UI2.WinForms.Guna2Button btnEstoque;
        public System.Windows.Forms.Panel panelContener;
    }
}