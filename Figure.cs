using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal abstract class Figure : MyObject
  {
    public char color, enemyColor;
    public Board.Figures type;
    protected Size size = new Size(120, 120);
    public virtual bool IsMovePossible(string move, Board board)
    {
      //Определяет может ли попасть фигура из одной точки в другую
      Board.Decode(move, board.isRotated,
        out int fi, out int fj, out int ni, out int nj);
      string[]? possibleMoves = GetPossibleMoves(board, fi, fj);
      if (possibleMoves is not null) 
      {
        foreach (string m in possibleMoves)
        {
          if(m.Equals(move)) return true;
        }
      }
      return false;
    }
    protected bool IsPathClear(Board board, int fi, int fj, int ni, int nj)
    {
      int k1 = ni > fi ? 1 : (ni < fi ? -1 : 0);
      int k2 = nj > fj ? 1 : (nj < fj ? -1 : 0);
      int i = fi + k1, j = fj + k2;
      bool clear = true;
      while(i != ni || j != nj)
      {
        if (board[i, j] is not null) clear = false;
        i += k1; j += k2;
      }
      return clear;
    }
    public abstract string[]? GetPossibleMoves(Board board, int i, int j);
    protected void GetOwner(out bool isOwnerPlayer, Board board)
    {
      isOwnerPlayer = color switch
      {
        'w' => true,
        'b' => false,
        _ => false
      };
      if (board.isRotated) isOwnerPlayer = isOwnerPlayer ? false : true;
    }
  }
}
