using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShessGUI
{
  internal class Pawn : Figure
  {
    public Pawn(char color)
    {
      type = Board.Figures.Pawn;
      this.color = color;
      enemyColor = color == 'w' ? 'b' : 'w';
      ObjImg = color switch
      {
        'w' => new Bitmap(Sprites.WhitePawn, size),
        'b' => new Bitmap(Sprites.BlackPawn, size),
        _ => new Bitmap(Sprites.WhiteKing, size)
      };
    }
    public override bool IsMovePossible(string move, Board board)
    {
      int fi, fj, ni, nj;
      Board.Decode(move, board.isRotated, out fi, out fj, out ni, out nj);
      GetOwner(out bool isOwnerPlayer, board);
      int k = isOwnerPlayer ? -1 : 1;
      Figure? figure = board[ni, nj];
      return (figure is null && nj == fj && ni == fi + k) || 
        (figure is not null && figure.color != color && Math.Abs(fj-nj) == 1 && ni == fi + k);
    }
    public override string[] GetPossibleMoves(Board board, int fi, int fj)
    {
      GetOwner(out bool isOwnerPlayer, board);
      Board board2 = new(board);
      int ki, kj;
      if (isOwnerPlayer) board.GetPlayerKingIJ(out ki, out kj);
      else board.GetComputerKingIJ(out ki, out kj);
      int k = isOwnerPlayer ? -1 : 1;
      List<string> moves = new ();
      string move, backmove;
      Figure? figure1 = Board.InRange(fi + k, fj + 1) ? board[fi + k, fj + 1] : null, 
        figure2 = Board.InRange(fi + k, fj - 1) ? board[fi + k, fj - 1] : null;
      if (Board.InRange(fi + k, fj) && board[fi + k, fj] is null)
      {
        move = Board.Recode(board.isRotated, fi, fj, fi + k, fj);
        backmove = Board.Recode(board.isRotated, fi + k, fj, fi, fj);
        board2.InstantMove(move);
        if (!board2.IsShahToThisKing(ki, kj)) moves.Add(move);
        board2.InstantMove(backmove);
      }
        
      if (figure1 is not null
        && figure1.color != this.color)
      {
        move = Board.Recode(board.isRotated, fi, fj, fi + k, fj + 1);
        backmove = Board.Recode(board.isRotated, fi + k, fj + 1, fi, fj);
        board2.InstantMove(move);
        if (!board2.IsShahToThisKing(ki, kj)) moves.Add(move);
        board2.InstantMove(backmove);
        board[fi + k, fj + 1] = figure1;
      }
        
      if (figure2 is not null
        && figure2.color != this.color)
      {
        move = Board.Recode(board.isRotated, fi, fj, fi + k, fj - 1);
        backmove = Board.Recode(board.isRotated, fi + k, fj - 1, fi, fj);
        board2.InstantMove(move);
        if (!board2.IsShahToThisKing(ki, kj)) moves.Add(move);
        board2.InstantMove(backmove);
        board2[fi + k, fj - 1] = figure2;
      }
        
      return moves.ToArray();
    }
  }
}
