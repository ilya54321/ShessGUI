using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal class Knight : Figure
  {
    public Knight(char color)
    {
      type = Board.Figures.Knight;
      this.color = color;
      enemyColor = color == 'w' ? 'b' : 'w';
      ObjImg = color switch
      {
        'w' => new Bitmap(Sprites.WhiteHorse, size),
        'b' => new Bitmap(Sprites.BlackHorse, size),
        _ => new Bitmap(Sprites.WhiteKing, size)
      };
    }
    public override bool IsMovePossible(string move, Board board)
    {
      int fi, fj, ni, nj;
      Board.Decode(move, board.isRotated, out fi, out fj, out ni, out nj);
      Figure? figure = board[ni, nj];
      return ((Math.Abs(fi - ni) == 1 && Math.Abs(fj-nj) == 2) || (Math.Abs(fi - ni) == 2 && Math.Abs(fj - nj) == 1)) 
        && (figure is null || figure.color != color);
    }
    public override string[] GetPossibleMoves(Board board, int fi, int fj)
    {
      Board board2 = new(board);
      int ki, kj;
      if (this.color == 'w') board.GetWhiteKingIJ(out ki, out kj);
      else board.GetBlackKingIJ(out ki, out kj);
      List<string> moves = new();
      short[,] directions = new short[,] { { 2, 1 }, { 2, -1 }, { -2, 1 }, { -2, -1 }, { 1, -2 }, { -1, -2 }, { 1, 2 }, { -1, 2 } };
      for (int i = 0; i < 8; i++)
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
            if(!board2.IsShahToThisKing(ki, kj))moves.Add(move);
            board2.InstantMove(backmove);
            board2[ni, nj] = figure;
          }
        }
      }
      return moves.ToArray();
    }
  }
}
