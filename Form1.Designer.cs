namespace ValksMinecraftHelper;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        textBox1 = new TextBox();
        panel1 = new Panel();
        button6 = new Button();
        button5 = new Button();
        button4 = new Button();
        button3 = new Button();
        button2 = new Button();
        panel2 = new Panel();
        panel3 = new Panel();
        button1 = new Button();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        panel3.SuspendLayout();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.BackColor = Color.FromArgb(46, 51, 90);
        textBox1.BorderStyle = BorderStyle.None;
        textBox1.Dock = DockStyle.Fill;
        textBox1.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        textBox1.ForeColor = Color.White;
        textBox1.Location = new Point(30, 30);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.ReadOnly = true;
        textBox1.ScrollBars = ScrollBars.Vertical;
        textBox1.Size = new Size(840, 316);
        textBox1.TabIndex = 0;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // panel1
        // 
        panel1.BackColor = Color.FromArgb(46, 51, 80);
        panel1.Controls.Add(button6);
        panel1.Controls.Add(button5);
        panel1.Controls.Add(button4);
        panel1.Controls.Add(button3);
        panel1.Controls.Add(button2);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 423);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(15);
        panel1.Size = new Size(900, 77);
        panel1.TabIndex = 2;
        // 
        // button6
        // 
        button6.BackColor = Color.FromArgb(46, 51, 120);
        button6.FlatAppearance.BorderSize = 0;
        button6.FlatStyle = FlatStyle.Flat;
        button6.Font = new Font("Nirmala UI Semilight", 11F, FontStyle.Bold, GraphicsUnit.Point);
        button6.ForeColor = Color.White;
        button6.Location = new Point(153, 18);
        button6.Name = "button6";
        button6.Size = new Size(149, 47);
        button6.TabIndex = 6;
        button6.Text = "Set Minecraft Exe";
        button6.UseVisualStyleBackColor = false;
        button6.Click += btnSetMinecraftExe_Click;
        // 
        // button5
        // 
        button5.BackColor = Color.FromArgb(46, 51, 120);
        button5.FlatAppearance.BorderSize = 0;
        button5.FlatStyle = FlatStyle.Flat;
        button5.Font = new Font("Nirmala UI Semilight", 11F, FontStyle.Bold, GraphicsUnit.Point);
        button5.ForeColor = Color.White;
        button5.Location = new Point(18, 18);
        button5.Name = "button5";
        button5.Size = new Size(129, 47);
        button5.TabIndex = 5;
        button5.Text = "Run Minecraft";
        button5.UseVisualStyleBackColor = false;
        button5.Click += btnRunMinecraft_Click;
        // 
        // button4
        // 
        button4.BackColor = Color.FromArgb(46, 51, 120);
        button4.FlatAppearance.BorderSize = 0;
        button4.FlatStyle = FlatStyle.Flat;
        button4.Font = new Font("Nirmala UI Semilight", 11F, FontStyle.Bold, GraphicsUnit.Point);
        button4.ForeColor = Color.White;
        button4.Location = new Point(308, 18);
        button4.Name = "button4";
        button4.Size = new Size(176, 47);
        button4.TabIndex = 4;
        button4.Text = "Move Dependencies";
        button4.UseVisualStyleBackColor = false;
        button4.Click += btnMoveDependencies_Click;
        // 
        // button3
        // 
        button3.BackColor = Color.FromArgb(46, 51, 120);
        button3.FlatAppearance.BorderSize = 0;
        button3.FlatStyle = FlatStyle.Flat;
        button3.Font = new Font("Nirmala UI Semilight", 11F, FontStyle.Bold, GraphicsUnit.Point);
        button3.ForeColor = Color.White;
        button3.Location = new Point(671, 18);
        button3.Name = "button3";
        button3.Size = new Size(211, 47);
        button3.TabIndex = 3;
        button3.Text = "Set Dependencies Folder";
        button3.UseVisualStyleBackColor = false;
        button3.Click += btnSetDependenciesFolder_Click;
        // 
        // button2
        // 
        button2.BackColor = Color.FromArgb(46, 51, 120);
        button2.FlatAppearance.BorderSize = 0;
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Nirmala UI Semilight", 11F, FontStyle.Bold, GraphicsUnit.Point);
        button2.ForeColor = Color.White;
        button2.Location = new Point(490, 18);
        button2.Name = "button2";
        button2.Size = new Size(175, 47);
        button2.TabIndex = 2;
        button2.Text = "Set Minecraft Folder";
        button2.UseVisualStyleBackColor = false;
        button2.Click += btnSetMinecraftFolder_Click;
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(46, 51, 90);
        panel2.Controls.Add(textBox1);
        panel2.Location = new Point(0, 41);
        panel2.Name = "panel2";
        panel2.Padding = new Padding(30);
        panel2.Size = new Size(900, 376);
        panel2.TabIndex = 3;
        panel2.Paint += panel2_Paint;
        // 
        // panel3
        // 
        panel3.BackColor = Color.FromArgb(46, 51, 90);
        panel3.Controls.Add(button1);
        panel3.Dock = DockStyle.Top;
        panel3.Location = new Point(0, 0);
        panel3.Name = "panel3";
        panel3.Size = new Size(900, 35);
        panel3.TabIndex = 4;
        panel3.MouseDown += panel3_MouseDown;
        // 
        // button1
        // 
        button1.BackColor = Color.FromArgb(46, 51, 90);
        button1.Dock = DockStyle.Right;
        button1.FlatAppearance.BorderSize = 0;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Nirmala UI Semilight", 14F, FontStyle.Bold, GraphicsUnit.Point);
        button1.ForeColor = Color.LightGray;
        button1.Location = new Point(864, 0);
        button1.Name = "button1";
        button1.Size = new Size(36, 35);
        button1.TabIndex = 3;
        button1.Text = "x";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button_Exit;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(46, 51, 90);
        ClientSize = new Size(900, 500);
        Controls.Add(panel3);
        Controls.Add(panel2);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.None;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Minecraft Helper";
        panel1.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        panel3.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TextBox textBox1;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private Button button1;
    private Button button4;
    private Button button3;
    private Button button2;
    private Button button5;
    private Button button6;
}
