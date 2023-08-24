using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShessGUI
{
  public partial class Form2 : Form
  {
    List<string> initPoses;
    List<string> arrangeNames;
    int selectedIndex = 0;
    public bool blocked = false;
    public int whiteDifficult = 0, blackDifficult = 0;
    public bool launch = false;
    public string path;
    public string language;
    public string theme;
    public Form2()
    {
      InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      arrangeNames = new();
      initPoses = new();
      if(!File.Exists("Arrangements/ArrangeNames.txt"))
      {
        Directory.CreateDirectory("Arrangements");
        using (FileStream fs = File.Create("Arrangements/ArrangeNames.txt"))
        {
          byte[] info = new UTF8Encoding(true).GetBytes("");
          fs.Write(info, 0, info.Length);
        }
        using (FileStream fs = File.Create("Arrangements/InitPoses.txt"))
        {
          byte[] info = new UTF8Encoding(true).GetBytes("");
          fs.Write(info, 0, info.Length);
        }
      }
      if(!File.Exists("Settings.txt"))
      {
        using (FileStream fs = File.Create("Settings.txt"))
        {
          byte[] info = new UTF8Encoding(true).GetBytes("theme:1\n\nlanguage:English");
          fs.Write(info, 0, info.Length);
        }
      }
      List<string> settings = new List<string>();
      foreach (string s in File.ReadLines("Settings.txt"))
      {
        settings.Add(s);
      }
      theme = settings[0];
      path = settings[1];
      language = settings[2];
      foreach (string s in File.ReadLines("Arrangements/ArrangeNames.txt"))
      {
        arrangeNames.Add(s);
      }
      foreach (string s in File.ReadLines("Arrangements/InitPoses.txt"))
      {
        initPoses.Add(s);
      }
      if (language == "language:Русский")
      {
        button1.Text = "Настройки";
        buttonPlay.Text = "Играть";
        buttonInfo.Text = "Информация";
        this.Text = "Выберите расстановку";
      }
      UpdateArrangements();
    }
    public void UpdateArrangements()
    {
      listBox1.DataSource = null;
      listBox1.DataSource = arrangeNames;
      //Обновление файлов
      File.WriteAllText("Arrangements/ArrangeNames.txt", "");
      File.WriteAllText("Arrangements/InitPoses.txt", "");
      using (StreamWriter sw = File.AppendText("Arrangements/ArrangeNames.txt"))
      {
        foreach(string s in arrangeNames) sw.WriteLine(s);
      }
      using (StreamWriter sw = File.AppendText("Arrangements/InitPoses.txt"))
      {
        foreach (string s in initPoses) sw.WriteLine(s);
      }
    }
    private void buttonAdd_Click(object sender, EventArgs e)
    {
      Form3 addition = new(arrangeNames, initPoses, this);
      addition.ShowDialog();
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      initPoses.RemoveAt(selectedIndex);
      arrangeNames.RemoveAt(selectedIndex);
      UpdateArrangements();
      selectedIndex = 0;
    }

    private void buttonInfo_Click(object sender, EventArgs e)
    {
      DialogResult dialogResult;
      dialogResult = MessageBox.Show(initPoses[selectedIndex], arrangeNames[selectedIndex]);
    }

    private void buttonPlay_Click(object sender, EventArgs e)
    {
      Form4 dialog = new(this);
      dialog.ShowDialog();
      if(launch)
      {
        Form1 game = new(initPoses[selectedIndex], this);
        game.Show();
        this.Hide();
      }
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      selectedIndex = listBox1.SelectedIndex;
    }
    private void button1_Click(object sender, EventArgs e)
    {
      Form5 frm = new(this);
      frm.ShowDialog();
    }

    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      Environment.Exit(0);
    }
  }
}
