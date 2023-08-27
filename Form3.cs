using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Policy;
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
    string firstMove = "w";
    string transpos = "rnqb";
    char? figureNow;
    bool process = false;
    Form2 f;
    Board addBoard;
    System.Windows.Forms.Timer timer = new();
    public Form3(List<string> arrangeNames, List<string> initPoses, Form2 sender)
    {
      f = sender;
      timer.Interval = 15;
      timer.Tick += Upd;
      this.arrangeNames = arrangeNames;
      this.initPoses = initPoses;
      InitializeComponent();
      addBoard = new(0, 0, "rnbqk/ppppp/5/5/PPPPP/RNBQK w rnqb 0 0", false, f.theme);
      if (sender.theme == "theme:2") pictureBox1.Image = Other.NewTemeShessBoard1;
      pictureBox2.BringToFront();
      pictureBox3.BringToFront();
      pictureBox4.BringToFront();
      pictureBox5.BringToFront();
      pictureBox6.BringToFront();
      pictureBox7.BringToFront();
      pictureBox8.BringToFront();
      pictureBox9.BringToFront();
      pictureBox10.BringToFront();
      pictureBox11.BringToFront();
      pictureBox12.BringToFront();
      pictureBox13.BringToFront();
      pictureBox14.BringToFront();
      if (f.language == "language:Русский")
      {
        this.Text = "Добавление...";
        label1.Text = "Имя:";
        label2.Text = "Доска(FEN):";
        label3.Text = "Возможные фигуры для трансформации пешки:";
        label4.Text = "Сейчас ход:";
        label5.Text = "Номер хода со взятия фигуры:";
        label6.Text = "Первые ходят:";
        button1.Text = "Принять";
        ArrangeName.Text = "НоваяРасстановка";
        checkedListBox1.Items[0] = "Ладья";
        checkedListBox1.Items[1] = "Конь";
        checkedListBox1.Items[2] = "Ферзь";
        checkedListBox1.Items[3] = "Слон";
        radioButton2.Text = "Белые";
        radioButton1.Text = "Чёрные";
      }
      for (int i = 0; i < 4; i++)
      {
        this.checkedListBox1.SetItemChecked(i, true);
      }
      timer.Start();
    }
    private string GetInitPos()
    {
      string initPos = "";
      initPos = FEN + " " + firstMove + " " + transpos + " " + move50Rule + " " + moveNumber;
      return initPos;
    }
    private bool KingsIsOk()
    {
      int wk = 0, bk = 0;
      for(int i = 0; i < 6; i++)
      {
        for(int j = 0; j < 5; j++)
        {
          if (addBoard[i, j] is not null && addBoard[i, j].type == Board.Figures.King)
          {
            if (addBoard[i, j].color == 'w') wk++;
            else bk++;
          }
        }
      }
      if (wk == 1 && bk == 1) return true;
      else return false;
    }
    private bool ShahIsOk()
    {
      addBoard.GetBlackKingIJ(out int bi, out int bj);
      addBoard.GetWhiteKingIJ(out int wi, out int wj);
      if (!addBoard.IsShahToThisKing(bi, bj) && !addBoard.IsShahToThisKing(wi, wj)) return true;
      else return false;
    }
    private bool PawnIsOk()
    {
      bool good = true;
      for(int i = 0; i < 5; i++)
      {
        Figure? figure1, figure2;
        figure1 = addBoard[0, i];
        figure2 = addBoard[5, i];
        if (figure1 is not null && figure1.type == Board.Figures.Pawn && figure1.color == 'w') 
        {
          good = false;
          break;
        }
        if (figure2 is not null && figure2.type == Board.Figures.Pawn && figure2.color == 'b')
        {
          good = false;
          break;
        }
      }
      return good;
    }
    private void GetIJ(out int i, out int j)
    {
      Point CursorPos = pictureBox1.PointToClient(Cursor.Position);
      i = (CursorPos.Y - 30) / 60;
      j = (CursorPos.X - 30) / 60;
    }
    void Upd(object sender, EventArgs e)
    {
      if(process && figureNow is not null) 
      {
        BoardInit.Text = addBoard.GetFen();
        GetIJ(out int i, out int j);
        if(Board.InRange(i, j))
        {
          addBoard[i, j] = addBoard.FromFenToFigure((char)figureNow);
        }
      }
      Invalidate();
      pictureBox1.Refresh();
    }
    private void button1_Click(object sender, EventArgs e)
    {
      if(KingsIsOk())
      {
        if(PawnIsOk())
        {
          if(ShahIsOk())
          {
            arrangeNames.Add(name);
            initPoses.Add(GetInitPos());
            f.UpdateArrangements();
            f.blocked = false;
            this.Close();
          }
          else
          {
            if (f.language == "language:Русский")
            {
              MessageBox.Show("Королю не может быть объявлен шах в начале партии!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
              MessageBox.Show("No attack to king in the start!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
        else
        {
          if (f.language == "language:Русский")
          {
            MessageBox.Show("Пешки не могут стоять на крайних горизонталях!", "Ошибка",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else
          {
            MessageBox.Show("Pawns cannot stand on the extreme horizontals!", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
      else
      {
        if(f.language == "language:Русский")
        {
          MessageBox.Show("На шахматной доске должен быть 1 белый и 1 чёрный король!", "Ошибка",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
          MessageBox.Show("There must be 1 white and 1 black king on the chessboard!", "Error", 
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void ArrangeName_TextChanged(object sender, EventArgs e)
    {
      name = this.ArrangeName.Text;
    }

    private void BoardInit_TextChanged(object sender, EventArgs e)
    {
      FEN = this.BoardInit.Text;
      addBoard.BoardInit(0, 0, 1, GetInitPos());
    }

    private void MoveNumber_TextChanged(object sender, EventArgs e)
    {
      moveNumber = this.MoveNumber.Text;
    }

    private void Move50Rule_TextChanged(object sender, EventArgs e)
    {
      move50Rule = this.Move50Rule.Text;
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

    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
      if (radioButton2.Checked) firstMove = "w";
      else firstMove = "b";
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      process = true;
    }


    private void Form3_Paint_1(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      int startPointX = 30, startPointY = 30;
      Graphics g = e.Graphics;
      for (int i = 0; i < 6; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          Figure? figure = addBoard[i, j];
          if (figure is not null) g.DrawImage(new Bitmap(figure.ObjImg, new Size(60, 60)), 
            new Point(startPointX + 60 * j, startPointY + 60 * i));
        }
      }
    }
    public void RefreshNowChecked()
    {
      if(figureNow is not null)
      {
        switch (figureNow)
        {
          case 'p':
            pictureBox2.Refresh();
            break;
          case 'b':
            pictureBox3.Refresh();
            break;
          case 'n':
            pictureBox4.Refresh();
            break;
          case 'r':
            pictureBox5.Refresh();
            break;
          case 'q':
            pictureBox6.Refresh();
            break;
          case 'k':
            pictureBox7.Refresh();
            break;
          case 'd':
            pictureBox8.Refresh();
            break;
          case 'P':
            pictureBox9.Refresh();
            break;
          case 'B':
            pictureBox10.Refresh();
            break;
          case 'N':
            pictureBox11.Refresh();
            break;
          case 'R':
            pictureBox12.Refresh();
            break;
          case 'Q':
            pictureBox13.Refresh();
            break;
          case 'K':
            pictureBox14.Refresh();
            break;
        }
      }
      
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox2.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'p';
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox3.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'b';
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox4.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'n';
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox5.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'r';
    }

    private void pictureBox6_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox6.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'q';
    }

    private void pictureBox7_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox7.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'k';
    }

    private void pictureBox9_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox9.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'P';
    }

    private void pictureBox10_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox10.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'B';
    }

    private void pictureBox11_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox11.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'N';
    }

    private void pictureBox12_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox12.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'R';
    }

    private void pictureBox13_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox13.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'Q';
    }

    private void pictureBox14_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox14.CreateGraphics();
      g.DrawImage(new Bitmap(Sprites.choice, new Size(60, 60)), new Point(0, 0));
      figureNow = 'K';

    }

    private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
    {
      process = false;
    }

    private void pictureBox8_Click(object sender, EventArgs e)
    {
      RefreshNowChecked();
      Graphics g = pictureBox8.CreateGraphics();
      g.DrawImage(new Bitmap(Other.choicedouble, new Size(120, 60)), new Point(0, 0));
      figureNow = 'd';
    }
  }
}
