using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal class King : Figure
  {
    public King(char color)
    {
      type = Board.Figures.King;
      this.color = color;
      enemyColor = color == 'w' ? 'b' : 'w';
      ObjImg = color switch
      {
        'w' => new Bitmap(Sprites.WhiteKing, size),
        'b' => new Bitmap(Sprites.BlackKing, size),
        _ => new Bitmap(Sprites.WhiteKing, size)
      };
    }
    public override string[] GetPossibleMoves(Board board, int fi, int fj)
    {
      List<string> moves = new();
      Board board2 = new Board(board);
      short[,] directions = new short[,] { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
      for(int i = 0; i < 8; i++)
      {
        int ni = fi + directions[i, 0];
        int nj = fj + directions[i, 1];
        if (Board.InRange(ni, nj))
        {
          string move = Board.Recode(board.isRotated, fi, fj, ni, nj);
          string backmove = Board.Recode(board.isRotated, ni, nj, fi, fj);
          Figure? figure = board[ni, nj];
          if (figure is null || figure.color != this.color)
          { 
            board2.InstantMove(move);
            if(!board2.IsShahToThisKing(ni, nj) && !board2.KingNearby(ni, nj)) moves.Add(move);
            board2.InstantMove(backmove);
            board2[ni, nj] = figure;
          }
        }
      }
      return moves.ToArray();
    }
  }
}
