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
      foreach (string s in File.ReadLines("Arrangements/ArrangeNames.txt"))
      {
        arrangeNames.Add(s);
      }
      foreach (string s in File.ReadLines("Arrangements/InitPoses.txt"))
      {
        initPoses.Add(s);
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
      if(!blocked)
      {
        Form3 addition = new(arrangeNames, initPoses, this);
        addition.Show();
        blocked = true;
      }
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      if(!blocked)
      {
        initPoses.RemoveAt(selectedIndex);
        arrangeNames.RemoveAt(selectedIndex);
        UpdateArrangements();
        selectedIndex = 0;
      }
    }

    private void buttonInfo_Click(object sender, EventArgs e)
    {
      if(!blocked)
      {
        DialogResult dialogResult;
        dialogResult = MessageBox.Show(initPoses[selectedIndex], arrangeNames[selectedIndex]);
      }
    }

    private void buttonPlay_Click(object sender, EventArgs e)
    {
      if(!blocked)
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
  }
}
