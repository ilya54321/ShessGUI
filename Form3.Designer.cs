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
      this.checkBox2 = new System.Windows.Forms.CheckBox();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.MoveNumber = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.Move50Rule = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(61, 39);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name:";
      // 
      // ArrangeName
      // 
      this.ArrangeName.Location = new System.Drawing.Point(123, 36);
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
      this.label2.Location = new System.Drawing.Point(61, 89);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Board(FEN):";
      // 
      // BoardInit
      // 
      this.BoardInit.Location = new System.Drawing.Point(155, 86);
      this.BoardInit.MaxLength = 40;
      this.BoardInit.Name = "BoardInit";
      this.BoardInit.Size = new System.Drawing.Size(287, 27);
      this.BoardInit.TabIndex = 3;
      this.BoardInit.Text = "rnbqk/ppppp/5/5/PPPPP/RNBQK";
      this.BoardInit.TextChanged += new System.EventHandler(this.BoardInit_TextChanged);
      // 
      // checkBox2
      // 
      this.checkBox2.AutoSize = true;
      this.checkBox2.Location = new System.Drawing.Point(61, 389);
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.Size = new System.Drawing.Size(142, 24);
      this.checkBox2.TabIndex = 5;
      this.checkBox2.Text = "Black moves first";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
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
      this.checkedListBox1.Location = new System.Drawing.Point(61, 182);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(150, 92);
      this.checkedListBox1.TabIndex = 6;
      this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(61, 143);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(239, 20);
      this.label3.TabIndex = 7;
      this.label3.Text = "Possible figures for transformation:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(61, 297);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(107, 20);
      this.label4.TabIndex = 8;
      this.label4.Text = "Move Number:";
      // 
      // MoveNumber
      // 
      this.MoveNumber.Location = new System.Drawing.Point(174, 294);
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
      this.label5.Location = new System.Drawing.Point(61, 341);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(222, 20);
      this.label5.TabIndex = 10;
      this.label5.Text = "Move Number from the capture:";
      // 
      // Move50Rule
      // 
      this.Move50Rule.Location = new System.Drawing.Point(289, 338);
      this.Move50Rule.MaxLength = 2;
      this.Move50Rule.Name = "Move50Rule";
      this.Move50Rule.Size = new System.Drawing.Size(66, 27);
      this.Move50Rule.TabIndex = 11;
      this.Move50Rule.Text = "0";
      this.Move50Rule.TextChanged += new System.EventHandler(this.Move50Rule_TextChanged);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(351, 413);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(91, 30);
      this.button1.TabIndex = 12;
      this.button1.Text = "Add";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Form3
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(501, 474);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.Move50Rule);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.MoveNumber);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.checkedListBox1);
      this.Controls.Add(this.checkBox2);
      this.Controls.Add(this.BoardInit);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ArrangeName);
      this.Controls.Add(this.label1);
      this.Name = "Form3";
      this.Text = "Addition";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label label1;
    private TextBox ArrangeName;
    private Label label2;
    private TextBox BoardInit;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckedListBox checkedListBox1;
    private Label label3;
    private Label label4;
    private TextBox MoveNumber;
    private Label label5;
    private TextBox Move50Rule;
    private Button button1;
  }
}