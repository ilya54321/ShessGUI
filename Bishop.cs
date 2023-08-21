using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace ShessGUI
{
  internal class Bishop : Figure
  {
    public Bishop(char color)
    {
      type = Board.Figures.Bishop;
      this.color = color;
      enemyColor = color == 'w' ? 'b' : 'w';
      ObjImg = color switch
      {
        'w' => new Bitmap(Sprites.WhiteElephant, size),
        'b' => new Bitmap(Sprites.BlackElephant, size),
        _ => new Bitmap(Sprites.WhiteElephant, size)
      };
    }
    public override bool IsMovePossible(string move, Board board)
    {
      int fi, fj, ni, nj;
      Board.Decode(move, board.isRotated, out fi, out fj, out ni, out nj);
      Figure? figure = board[ni, nj];
      return Math.Abs(ni- fi) == Math.Abs(nj- fj) && IsPathClear(board, fi, fj, ni, nj) && (figure is null || figure.color != color);
    }
    public override string[]? GetPossibleMoves(Board board, int fi, int fj)
    {
      GetOwner(out bool isOwnerPlayer, board);
      Board board2 = new(board);
      int ki, kj;
      if (isOwnerPlayer) board.GetPlayerKingIJ(out ki, out kj);
      else board.GetComputerKingIJ(out ki, out kj);
      List <string> moves = new ();
      short[,] directions = new short[,] { {1, 1 }, {1, -1 },{-1, 1 }, {-1, -1 } };
      for(int i = 0; i < 4; i++)
      {
        int ni = fi, nj = fj;
        while(true)
        {
          ni += directions[i, 0]; nj += directions[i, 1];
          if (Board.InRange(ni, nj))
          {
            string move = Board.Recode(board.isRotated, fi, fj, ni, nj);
            string backmove = Board.Recode(board.isRotated, ni, nj, fi, fj);
            Figure? figure = board[ni, nj];
            if (figure is null)
            {
              board2.InstantMove(move);
              if (!board2.IsShahToThisKing(ki, kj)) moves.Add(move);
              board2.InstantMove(backmove);
              board2[ni, nj] = figure;
            }
            else if (figure.color != this.color)
            {
              board2.InstantMove(move);
              if (!board2.IsShahToThisKing(ki, kj)) moves.Add(move);
              board2.InstantMove(backmove);
              board2[ni, nj] = figure;
              break;
            }
            else break;
          }
          else break;
        }
      }
      return moves.ToArray();
    }
  }
}
