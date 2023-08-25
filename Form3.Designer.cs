namespace ShessGUI
{
  partial class Form3
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
      this.label1 = new System.Windows.Forms.Label();
      this.ArrangeName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.BoardInit = new System.Windows.Forms.TextBox();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.MoveNumber = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.Move50Rule = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.pictureBox4 = new System.Windows.Forms.PictureBox();
      this.pictureBox5 = new System.Windows.Forms.PictureBox();
      this.pictureBox6 = new System.Windows.Forms.PictureBox();
      this.pictureBox7 = new System.Windows.Forms.PictureBox();
      this.pictureBox8 = new System.Windows.Forms.PictureBox();
      this.pictureBox9 = new System.Windows.Forms.PictureBox();
      this.pictureBox10 = new System.Windows.Forms.PictureBox();
      this.pictureBox11 = new System.Windows.Forms.PictureBox();
      this.pictureBox12 = new System.Windows.Forms.PictureBox();
      this.pictureBox13 = new System.Windows.Forms.PictureBox();
      this.pictureBox14 = new System.Windows.Forms.PictureBox();
      this.radioButton1 = new System.Windows.Forms.RadioButton();
      this.radioButton2 = new System.Windows.Forms.RadioButton();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(559, 23);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name:";
      // 
      // ArrangeName
      // 
      this.ArrangeName.Location = new System.Drawing.Point(617, 20);
      this.ArrangeName.MaxLength = 40;
      this.ArrangeName.Name = "ArrangeName";
      this.ArrangeName.Size = new System.Drawing.Size(319, 27);
      this.ArrangeName.TabIndex = 1;
      this.ArrangeName.Text = "NewArrangement";
      this.ArrangeName.TextChanged += new System.EventHandler(this.ArrangeName_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(559, 63);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Board(FEN):";
      // 
      // BoardInit
      // 
      this.BoardInit.Location = new System.Drawing.Point(649, 60);
      this.BoardInit.MaxLength = 40;
      this.BoardInit.Name = "BoardInit";
      this.BoardInit.Size = new System.Drawing.Size(287, 27);
      this.BoardInit.TabIndex = 3;
      this.BoardInit.Text = "rnbqk/ppppp/5/5/PPPPP/RNBQK";
      this.BoardInit.TextChanged += new System.EventHandler(this.BoardInit_TextChanged);
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.CheckOnClick = true;
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Items.AddRange(new object[] {
            "Rook",
            "Knight",
            "Queen",
            "Bishop"});
      this.checkedListBox1.Location = new System.Drawing.Point(559, 153);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(150, 92);
      this.checkedListBox1.TabIndex = 6;
      this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(559, 123);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(239, 20);
      this.label3.TabIndex = 7;
      this.label3.Text = "Possible figures for transformation:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(559, 263);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(107, 20);
      this.label4.TabIndex = 8;
      this.label4.Text = "Move Number:";
      // 
      // MoveNumber
      // 
      this.MoveNumber.Location = new System.Drawing.Point(672, 260);
      this.MoveNumber.MaxLength = 4;
      this.MoveNumber.Name = "MoveNumber";
      this.MoveNumber.Size = new System.Drawing.Size(66, 27);
      this.MoveNumber.TabIndex = 9;
      this.MoveNumber.Text = "0";
      this.MoveNumber.TextChanged += new System.EventHandler(this.MoveNumber_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(559, 303);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(222, 20);
      this.label5.TabIndex = 10;
      this.label5.Text = "Move Number from the capture:";
      // 
      // Move50Rule
      // 
      this.Move50Rule.Location = new System.Drawing.Point(787, 300);
      this.Move50Rule.MaxLength = 2;
      this.Move50Rule.Name = "Move50Rule";
      this.Move50Rule.Size = new System.Drawing.Size(66, 27);
      this.Move50Rule.TabIndex = 11;
      this.Move50Rule.Text = "0";
      this.Move50Rule.TextChanged += new System.EventHandler(this.Move50Rule_TextChanged);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(845, 413);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(91, 30);
      this.button1.TabIndex = 12;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::ShessGUI.Sprites.NewShessBoard1;
      this.pictureBox1.Location = new System.Drawing.Point(155, 23);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(360, 420);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 13;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
      this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp_1);
      // 
      // pictureBox2
      // 
      this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox2.Image = global::ShessGUI.Sprites.BlackPawn;
      this.pictureBox2.Location = new System.Drawing.Point(89, 23);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(60, 60);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox2.TabIndex = 14;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
      // 
      // pictureBox3
      // 
      this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox3.Image = global::ShessGUI.Sprites.BlackElephant;
      this.pictureBox3.Location = new System.Drawing.Point(89, 83);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(60, 60);
      this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox3.TabIndex = 15;
      this.pictureBox3.TabStop = false;
      this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
      // 
      // pictureBox4
      // 
      this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox4.Image = global::ShessGUI.Sprites.BlackHorse;
      this.pictureBox4.Location = new System.Drawing.Point(89, 143);
      this.pictureBox4.Name = "pictureBox4";
      this.pictureBox4.Size = new System.Drawing.Size(60, 60);
      this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox4.TabIndex = 16;
      this.pictureBox4.TabStop = false;
      this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
      // 
      // pictureBox5
      // 
      this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox5.Image = global::ShessGUI.Sprites.BlackRook;
      this.pictureBox5.Location = new System.Drawing.Point(89, 203);
      this.pictureBox5.Name = "pictureBox5";
      this.pictureBox5.Size = new System.Drawing.Size(60, 60);
      this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox5.TabIndex = 17;
      this.pictureBox5.TabStop = false;
      this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
      // 
      // pictureBox6
      // 
      this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox6.Image = global::ShessGUI.Sprites.BlackQueen;
      this.pictureBox6.Location = new System.Drawing.Point(89, 263);
      this.pictureBox6.Name = "pictureBox6";
      this.pictureBox6.Size = new System.Drawing.Size(60, 60);
      this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox6.TabIndex = 18;
      this.pictureBox6.TabStop = false;
      this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
      // 
      // pictureBox7
      // 
      this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox7.Image = global::ShessGUI.Sprites.BlackKing;
      this.pictureBox7.Location = new System.Drawing.Point(89, 323);
      this.pictureBox7.Name = "pictureBox7";
      this.pictureBox7.Size = new System.Drawing.Size(60, 60);
      this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox7.TabIndex = 19;
      this.pictureBox7.TabStop = false;
      this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
      // 
      // pictureBox8
      // 
      this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox8.Image = global::ShessGUI.Other.deleteicon;
      this.pictureBox8.Location = new System.Drawing.Point(29, 383);
      this.pictureBox8.Name = "pictureBox8";
      this.pictureBox8.Size = new System.Drawing.Size(120, 60);
      this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox8.TabIndex = 20;
      this.pictureBox8.TabStop = false;
      this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
      // 
      // pictureBox9
      // 
      this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox9.Image = global::ShessGUI.Sprites.WhitePawn;
      this.pictureBox9.Location = new System.Drawing.Point(29, 23);
      this.pictureBox9.Name = "pictureBox9";
      this.pictureBox9.Size = new System.Drawing.Size(60, 60);
      this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox9.TabIndex = 21;
      this.pictureBox9.TabStop = false;
      this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
      // 
      // pictureBox10
      // 
      this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox10.Image = global::ShessGUI.Sprites.WhiteElephant;
      this.pictureBox10.Location = new System.Drawing.Point(29, 83);
      this.pictureBox10.Name = "pictureBox10";
      this.pictureBox10.Size = new System.Drawing.Size(60, 60);
      this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox10.TabIndex = 22;
      this.pictureBox10.TabStop = false;
      this.pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
      // 
      // pictureBox11
      // 
      this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox11.Image = global::ShessGUI.Sprites.WhiteHorse;
      this.pictureBox11.Location = new System.Drawing.Point(29, 143);
      this.pictureBox11.Name = "pictureBox11";
      this.pictureBox11.Size = new System.Drawing.Size(60, 60);
      this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox11.TabIndex = 23;
      this.pictureBox11.TabStop = false;
      this.pictureBox11.Click += new System.EventHandler(this.pictureBox11_Click);
      // 
      // pictureBox12
      // 
      this.pictureBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox12.Image = global::ShessGUI.Sprites.WhiteRook;
      this.pictureBox12.Location = new System.Drawing.Point(29, 203);
      this.pictureBox12.Name = "pictureBox12";
      this.pictureBox12.Size = new System.Drawing.Size(60, 60);
      this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox12.TabIndex = 24;
      this.pictureBox12.TabStop = false;
      this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
      // 
      // pictureBox13
      // 
      this.pictureBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox13.Image = global::ShessGUI.Sprites.WhiteQueen;
      this.pictureBox13.Location = new System.Drawing.Point(29, 263);
      this.pictureBox13.Name = "pictureBox13";
      this.pictureBox13.Size = new System.Drawing.Size(60, 60);
      this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox13.TabIndex = 25;
      this.pictureBox13.TabStop = false;
      this.pictureBox13.Click += new System.EventHandler(this.pictureBox13_Click);
      // 
      // pictureBox14
      // 
      this.pictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox14.Image = global::ShessGUI.Sprites.WhiteKing;
      this.pictureBox14.Location = new System.Drawing.Point(29, 323);
      this.pictureBox14.Name = "pictureBox14";
      this.pictureBox14.Size = new System.Drawing.Size(60, 60);
      this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox14.TabIndex = 26;
      this.pictureBox14.TabStop = false;
      this.pictureBox14.Click += new System.EventHandler(this.pictureBox14_Click);
      // 
      // radioButton1
      // 
      this.radioButton1.AutoSize = true;
      this.radioButton1.Location = new System.Drawing.Point(672, 370);
      this.radioButton1.Name = "radioButton1";
      this.radioButton1.Size = new System.Drawing.Size(65, 24);
      this.radioButton1.TabIndex = 27;
      this.radioButton1.Text = "Black";
      this.radioButton1.UseVisualStyleBackColor = true;
      this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
      // 
      // radioButton2
      // 
      this.radioButton2.AutoSize = true;
      this.radioButton2.Checked = true;
      this.radioButton2.Location = new System.Drawing.Point(559, 370);
      this.radioButton2.Name = "radioButton2";
      this.radioButton2.Size = new System.Drawing.Size(69, 24);
      this.radioButton2.TabIndex = 28;
      this.radioButton2.TabStop = true;
      this.radioButton2.Text = "White";
      this.radioButton2.UseVisualStyleBackColor = true;
      this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(559, 347);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(80, 20);
      this.label6.TabIndex = 29;
      this.label6.Text = "First move:";
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
      this.groupBox1.Location = new System.Drawing.Point(27, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(130, 433);
      this.groupBox1.TabIndex = 30;
      this.groupBox1.TabStop = false;
      // 
      // Form3
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(977, 474);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.radioButton2);
      this.Controls.Add(this.radioButton1);
      this.Controls.Add(this.pictureBox14);
      this.Controls.Add(this.pictureBox13);
      this.Controls.Add(this.pictureBox12);
      this.Controls.Add(this.pictureBox11);
      this.Controls.Add(this.pictureBox10);
      this.Controls.Add(this.pictureBox9);
      this.Controls.Add(this.pictureBox8);
      this.Controls.Add(this.pictureBox7);
      this.Controls.Add(this.pictureBox6);
      this.Controls.Add(this.pictureBox5);
      this.Controls.Add(this.pictureBox4);
      this.Controls.Add(this.pictureBox3);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.Move50Rule);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.MoveNumber);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.checkedListBox1);
      this.Controls.Add(this.BoardInit);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ArrangeName);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "Form3";
      this.Text = "Addition";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint_1);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label label1;
    private TextBox ArrangeName;
    private Label label2;
    private TextBox BoardInit;
    private CheckBox checkBox1;
    private CheckedListBox checkedListBox1;
    private Label label3;
    private Label label4;
    private TextBox MoveNumber;
    private Label label5;
    private TextBox Move50Rule;
    private Button button1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private PictureBox pictureBox13;
        private PictureBox pictureBox14;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label6;
    private GroupBox groupBox1;
  }
}