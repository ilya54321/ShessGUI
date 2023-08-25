using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal class Board : MyObject
  {
    public List<Figures> possibleFigures;
    public int moveNumber, move50Rule; 
    public int firstPosX, firstPosY;
    public Size figureSize;
    public char firstMove;
    
    public static void Decode(string move, bool isRotated,
      out int firstI, out int firstJ, out int newI, out int newJ)
    {
      firstJ = isRotated ? 4 - (move[0] - 'a') : move[0] - 'a';
      newJ = isRotated ? 4 - (move[2] - 'a') : move[2] - 'a';
      firstI = isRotated ? move[1] - '1' : 5 - (move[1] - '1');
      newI = isRotated ? move[3] - '1' : 5 - (move[3] - '1');
    }
    public static bool InRange(int i, int j)
    {
      return j >= 0 && j < 5 && i >= 0 && i < 6;
    }
    public static string Recode(bool isRotated, int firstI, int firstJ,
      int newI, int newJ)
    {
      string move = "";
      move += (char)(isRotated ? 'e' - firstJ : firstJ + 'a');
      move += (char)(isRotated ? '1' + firstI : '6' - firstI);
      move += (char)(isRotated ? 'e' - newJ : newJ + 'a');
      move += (char)(isRotated ? '1' + newI : '6' - newI);
      return move;
    }
    public enum Figures 
    {
      King = 'k',
      Queen = 'q',
      Rook = 'r',
      Knight = 'n',
      Bishop = 'b',
      Pawn = 'p',
    }
    Figure?[,] _board;
    public bool isRotated;
    public Board(float x, float y, string initPos, bool isRotated, string theme)
    {
      _board = new Figure?[6, 5];
      this.x = x; this.y = y;
      possibleFigures = new();
      this.isRotated = isRotated;
      if (isRotated) BoardInit(5, 4, -1, initPos);
      else BoardInit(0, 0, 1, initPos);
      if(theme == "theme:1")
      {
        if (isRotated) ObjImg = new Bitmap(Sprites.NewShessBoard2,
          new Size(720, 840));
        else ObjImg = new Bitmap(Sprites.NewShessBoard1,
          new Size(720, 840));
      }
      else
      {
        if (isRotated) ObjImg = new Bitmap(Other.NewTemeShessBoard2,
          new Size(720, 840));
        else ObjImg = new Bitmap(Other.NewTemeShessBoard1,
          new Size(720, 840));
      }
      firstPosX = DrawLocation.X + 60; 
      firstPosY = DrawLocation.Y + 60;
      figureSize = new Size(120, 120);
    }
    public Board(Board board)
    {
      this.x = board.x; this.y = board.y;
      this.possibleFigures = board.possibleFigures;
      ObjImg = board.ObjImg;
      _board = new Figure?[6, 5];
      this.isRotated = board.isRotated;
      this.firstMove = board.firstMove;
      this.moveNumber = board.moveNumber;
      this.move50Rule = board.move50Rule;
      for(int i = 0; i < 6; i++)
      {
        for(int j = 0; j < 5; j++)
        {
          Figure? figure = board[i, j];
          if (figure is null) this[i, j] = null; 
          else this[i, j] = GetFigureFromEnumerator(figure.type, figure.color);
        }
      }
    }
    public Figure? this[int k, int k1]
    {
      get
      {
        return _board[k, k1];
      }
      set
      {
        _board[k, k1] = value;
      }
    }
    public Figure? FromFenToFigure(char symb)
    {
      return symb switch
      {
        'k' => new King('b'),
        'q' => new Queen('b'),
        'n' => new Knight('b'),
        'p' => new Pawn('b'),
        'b' => new Bishop('b'),
        'r' => new Rook('b'),
        'K' => new King('w'),
        'Q' => new Queen('w'),
        'N' => new Knight('w'),
        'P' => new Pawn('w'),
        'B' => new Bishop('w'),
        'R' => new Rook('w'),
        _ => null
      };
    }
    public static Figure? GetFigureFromEnumerator(Figures enumFigure, char color)
    {
      return enumFigure switch
      {
        Figures.King => new King(color),
        Figures.Queen => new Queen(color),
        Figures.Knight => new Knight(color),
        Figures.Bishop => new Bishop(color),
        Figures.Pawn => new Pawn(color),
        Figures.Rook => new Rook(color),
        _ => null
      };
    }
    public void BoardInit(int starti, int startj, int k, string initPos)
    {
      int GetNumber(ref int p, string initPos)
      {
        string number = "";
        while (p!=initPos.Length && initPos[p] != ' ')
        {
          number += initPos[p];
          p++;
        }
        p++;
        return Int32.Parse(number);
      }
      int i = starti; int j = startj;
      int p = 0;
      for(; p < initPos.Length; p++)
      {
        char symb = initPos[p];
        if (symb == ' ') break;
        if (symb == '/')
        {
          i+=k; j = startj;
        }
        else
        {
          Figure? figure = null;
          if (symb >= '1' && symb <= '5') 
            j = j + k * (symb - '1');
          else
          {
            figure = FromFenToFigure(symb);
            _board[i, j] = figure;
          }
          j+=k;
        }
      }
      p++;
      firstMove = initPos[p];
      p+=2;
      while (initPos[p] != ' ')
      {
        possibleFigures.Add((Figures)initPos[p]);
        p++;
      } p++;
      moveNumber = GetNumber(ref p, initPos);
      move50Rule = GetNumber(ref p, initPos);
    }
    public void GetWhiteKingIJ(out int ki, out int kj)
    {
      ki = 0; kj = 0;
      for (int i = 0; i < 6; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          Figure? figure = this[i, j];
          if (figure is not null && figure.color == 'w' &&
            figure.type == Figures.King) { ki = i; kj = j; break; }
        }
      }
    }
    public void GetBlackKingIJ(out int ki, out int kj)
    {
      ki = 0; kj = 0;
      for (int i = 0; i < 6; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          Figure? figure = this[i, j];
          if (figure is not null && figure.color == 'b' &&
            figure.type == Figures.King) { ki = i; kj = j; break; }
        }
      }
    }
    public void InstantMove(string move)
    {
      //Готовый ход
      //e5e6q
      try
      {
        int fi, fj, ni, nj;
        Decode(move, this.isRotated, out fi, out fj, out ni, out nj);
        this[ni, nj] = this[fi, fj]; this[fi, fj] = null; 
      }
      catch
      {
        MessageBox.Show("Неверный формат хода!", "Ошибка", MessageBoxButtons.OK, 
          MessageBoxIcon.Error);
      }
    }
    public bool IsShahToThisKing(int ki, int kj)
    {
      Figure? king = this[ki, kj];
      if (king is null) return false;
      for(int i = 0; i < 6; i++)
      {
        for(int j = 0; j < 5; j++)
        {
          Figure? figure = this[i, j];
          if (figure is not null && figure.type != Figures.King && 
            figure.IsMovePossible(Recode(isRotated, i, j, ki, kj), this) && 
            figure.color != king.color)
          {
            return true;
          }
        }
      }
      return false;
    }
    public string GetFen()
    {
      int cnt;
      string result = "";
      for(int i = 0; i < 6; i++)
      {
        if (i > 0) result += "/";
        cnt = 0;
        for(int j = 0; j < 5; j++)
        {
          Figure? figure = this[i, j];
          if(figure is null)
          {
            cnt++;
          }
          else
          {
            if(cnt != 0)result += $"{cnt}";
            string type = $"{(char)figure.type}";
            if (figure.color == 'w') type = type.ToUpper();
            result += type;
            cnt = 0;
          }
        }
        if (cnt != 0) result += $"{cnt}";
      }
      return result;
    }
    public bool KingNearby(int fi, int fj)
    {
      short[,] directions = new short[,] { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
      for(int i = 0; i < 8; i++)
      {
        int ni = fi + directions[i, 0];
        int nj = fj + directions[i, 1];
        if(InRange(ni, nj))
        {
          Figure? figure = this[ni, nj];
          if (figure is not null && figure.type == Figures.King) return true;
        }
      }
      return false;
    }
  }
}
