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
  public partial class Form4 : Form
  {
    Form2 sende;
    public Form4(Form2 sender)
    {
      sende = sender;
      InitializeComponent();
      comboBox1.SelectedItem = comboBox1.Items[0];
      comboBox2.SelectedItem = comboBox2.Items[0];
      if(sende.language == "language:Русский")
      {
        comboBox1.Items[0] = "Игрок";
        comboBox2.Items[0] = "Игрок";
        comboBox1.Items[1] = "Компьютер(легко)";
        comboBox2.Items[1] = "Компьютер(легко)";
        comboBox1.Items[2] = "Компьютер(средне)";
        comboBox2.Items[2] = "Компьютер(средне)";
        comboBox1.Items[3] = "Компьютер(сложно)";
        comboBox2.Items[3] = "Компьютер(сложно)";
        label3.Text = "Против";
        label1.Text = "(За белых)";
        label2.Text = "(За Чёрных)";
      }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      sende.launch = true;
      this.Close();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      sende.whiteDifficult = comboBox1.SelectedIndex;
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      sende.blackDifficult = comboBox2.SelectedIndex;
    }
  }
}
