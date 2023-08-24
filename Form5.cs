using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShessGUI
{
  public partial class Form5 : Form
  {
    Form2 launcher;
    public string path;
    public string language;
    public string theme;
    public Form5(Form2 launcher)
    {
      InitializeComponent();
      this.launcher = launcher;
      if (launcher.language == "language:Русский")
      {
        this.Text = "Настройки";
        label1.Text = "Тема шахматной доски:";
        label2.Text = "Выберите шахматный движок:";
        label3.Text = "Выберите язык лаунчера:";
      }
      openFileDialog1.InitialDirectory = "c:\\";
      button1.Text = "...";
      openFileDialog1.RestoreDirectory = true;
      List<string> settings = new List<string>();
      foreach(string s in File.ReadLines("Settings.txt"))
      {
        settings.Add(s);
      }
      theme = settings[0];
      path = settings[1];
      language = settings[2];
      textBox1.Text = path;
      if (language[9] == 'Р') listBox1.SelectedIndex = 1;
      else listBox1.SelectedIndex = 0;
      if (theme[6] == '1') radioButton1.Checked = true;
      else radioButton2.Checked = true;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        path = openFileDialog1.FileName;
        textBox1.Text = path;
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      path = textBox1.Text;
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      language = "language:" + listBox1.SelectedItem;
    }

    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButton1.Checked)
      {
        theme = "theme:1";
      }
      else theme = "theme:2";
      //MessageBox.Show(theme);
    }

    private void Form5_FormClosing(object sender, FormClosingEventArgs e)
    {
      File.WriteAllText("Settings.txt", $"{theme}\n{path}\n{language}");
      launcher.theme = this.theme;
      launcher.path = this.path;
      launcher.language = this.language;
    }
  }
}
