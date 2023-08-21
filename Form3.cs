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
  public partial class Form3 : Form
  {
    List<string> arrangeNames;
    List<string> initPoses;
    string name = "NewArrangement";
    string FEN = "rnbqk/ppppp/5/5/PPPPP/RNBQK";
    string moveNumber = "0";
    string move50Rule = "0";
    string play = "w";
    string firstMove = "w";
    string transpos = "rnqb";
    Form2 f;
    public Form3(List<string> arrangeNames, List<string> initPoses, Form2 sender)
    {
      f = sender;
      this.arrangeNames = arrangeNames;
      this.initPoses = initPoses;
      InitializeComponent();
      for (int i = 0; i < 4; i++)
      {
        this.checkedListBox1.SetItemChecked(i, true);
      }
    }
    private string GetInitPos()
    {
      string initPos = "";
      initPos = FEN + " " + firstMove + " " + transpos + " " + moveNumber + " " + move50Rule + " " + play;
      return initPos;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      arrangeNames.Add(name);
      initPoses.Add(GetInitPos());
      f.UpdateArrangements();
      f.blocked = false;
      this.Close();
    }

    private void ArrangeName_TextChanged(object sender, EventArgs e)
    {
      name = this.ArrangeName.Text;
    }

    private void BoardInit_TextChanged(object sender, EventArgs e)
    {
      FEN = this.BoardInit.Text;
    }

    private void MoveNumber_TextChanged(object sender, EventArgs e)
    {
      moveNumber = this.MoveNumber.Text;
    }

    private void Move50Rule_TextChanged(object sender, EventArgs e)
    {
      move50Rule = this.Move50Rule.Text;
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (play == "w") play = "b";
      else play = "w";
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      if (firstMove == "w") firstMove = "b";
      else firstMove = "w";
    }

    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      transpos = "";
      if (this.checkedListBox1.GetItemChecked(0)) transpos += "r";
      if (this.checkedListBox1.GetItemChecked(1)) transpos += "n";
      if (this.checkedListBox1.GetItemChecked(2)) transpos += "q";
      if (this.checkedListBox1.GetItemChecked(3)) transpos += "b";
    }

    private void Form3_FormClosing(object sender, FormClosingEventArgs e)
    {
      f.blocked = false;
    }
  }
}
