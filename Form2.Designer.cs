namespace ShessGUI
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
      this.button_info = new System.Windows.Forms.Button();
      this.button_play = new System.Windows.Forms.Button();
      this.button_add = new System.Windows.Forms.Button();
      this.button_delete = new System.Windows.Forms.Button();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.buttonAdd = new System.Windows.Forms.Button();
      this.buttonDelete = new System.Windows.Forms.Button();
      this.buttonInfo = new System.Windows.Forms.Button();
      this.buttonPlay = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // button_info
      // 
      this.button_info.BackColor = System.Drawing.SystemColors.Control;
      this.button_info.Location = new System.Drawing.Point(473, 362);
      this.button_info.Name = "button_info";
      this.button_info.Size = new System.Drawing.Size(135, 40);
      this.button_info.TabIndex = 0;
      this.button_info.Text = "Information";
      this.button_info.UseVisualStyleBackColor = false;
      // 
      // button_play
      // 
      this.button_play.Location = new System.Drawing.Point(631, 362);
      this.button_play.Name = "button_play";
      this.button_play.Size = new System.Drawing.Size(135, 40);
      this.button_play.TabIndex = 1;
      this.button_play.Text = "Play";
      this.button_play.UseVisualStyleBackColor = true;
      // 
      // button_add
      // 
      this.button_add.Location = new System.Drawing.Point(0, 0);
      this.button_add.Name = "button_add";
      this.button_add.Size = new System.Drawing.Size(75, 23);
      this.button_add.TabIndex = 0;
      // 
      // button_delete
      // 
      this.button_delete.Location = new System.Drawing.Point(0, 0);
      this.button_delete.Name = "button_delete";
      this.button_delete.Size = new System.Drawing.Size(75, 23);
      this.button_delete.TabIndex = 0;
      // 
      // listBox1
      // 
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 20;
      this.listBox1.Location = new System.Drawing.Point(53, 39);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(641, 284);
      this.listBox1.TabIndex = 0;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // buttonAdd
      // 
      this.buttonAdd.BackgroundImage = global::ShessGUI.Sprites.Plus;
      this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonAdd.Location = new System.Drawing.Point(743, 39);
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.Size = new System.Drawing.Size(70, 70);
      this.buttonAdd.TabIndex = 1;
      this.buttonAdd.UseVisualStyleBackColor = true;
      this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
      // 
      // buttonDelete
      // 
      this.buttonDelete.BackgroundImage = global::ShessGUI.Sprites.Trash;
      this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.buttonDelete.Location = new System.Drawing.Point(743, 137);
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.Size = new System.Drawing.Size(70, 70);
      this.buttonDelete.TabIndex = 2;
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
      // 
      // buttonInfo
      // 
      this.buttonInfo.Location = new System.Drawing.Point(509, 381);
      this.buttonInfo.Name = "buttonInfo";
      this.buttonInfo.Size = new System.Drawing.Size(135, 45);
      this.buttonInfo.TabIndex = 3;
      this.buttonInfo.Text = "Information";
      this.buttonInfo.UseVisualStyleBackColor = true;
      this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
      // 
      // buttonPlay
      // 
      this.buttonPlay.Location = new System.Drawing.Point(678, 381);
      this.buttonPlay.Name = "buttonPlay";
      this.buttonPlay.Size = new System.Drawing.Size(135, 45);
      this.buttonPlay.TabIndex = 4;
      this.buttonPlay.Text = "Play";
      this.buttonPlay.UseVisualStyleBackColor = true;
      this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(53, 381);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(138, 45);
      this.button1.TabIndex = 5;
      this.button1.Text = "Settings";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Form2
      // 
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(876, 456);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.buttonPlay);
      this.Controls.Add(this.buttonInfo);
      this.Controls.Add(this.buttonDelete);
      this.Controls.Add(this.buttonAdd);
      this.Controls.Add(this.listBox1);
      this.Name = "Form2";
      this.Text = "Choose Arrangement";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private Button button_info;
    private Button button_play;
    private Button button_add;
    private Button button_delete;
    private ListBox listBox1;
    private Button buttonAdd;
    private Button buttonDelete;
    private Button buttonInfo;
    private Button buttonPlay;
        private Button button1;
    }
}