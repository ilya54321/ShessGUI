using Microsoft.VisualBasic;
using static ShessGUI.Board;

namespace ShessGUI
{
  public partial class Form1 : Form
  {
    Form2 launcher;
    Board board;
    List<int[]> possiblePositions;
    List<Figures> possibleFigures;
    int? playerPosI, playerPosJ;
    int moveNumber, move50Rule;
    bool playerMove, transformation;
    char playerColor, computerColor;
    string? lastMove = null;
    ChoosingPanel panel;
    public Form1(string FEN, Form2 launcher)
    {
      board = new Board(0, 0, FEN);
      this.launcher = launcher;
      InitializeComponent();
      this.DoubleBuffered = true;
      transformation = false;
      playerMove = board.isPlayerFirstMove;
      possibleFigures = board.possibleFigures;
      moveNumber = board.moveNumber; move50Rule = board.move50Rule;
      playerColor = board.isRotated ? 'b' : 'w';
      computerColor = board.isRotated ? 'w' : 'b';
      panel = possibleFigures.Count switch
      {
        1 => new Panel1(this.Width, this.Height),
        2 => new Panel2(this.Width, this.Height),
        3 => new Panel3(this.Width, this.Height),
        _ => new Panel4(this.Width, this.Height)
      };
      timer1.Start();
    }
    private void EndGame(char result)
    {
      //this.Close();
      DialogResult dialogResult;
      if (result == 'd') dialogResult = MessageBox.Show("Ничья", "Игра Закончена!");
      else if (result == 'w') dialogResult = MessageBox.Show("Победили белые", "Игра Закончена!");
      else dialogResult = MessageBox.Show("Победили чёрные", "Игра Закончена!");
      if(dialogResult == DialogResult.Cancel || 
        dialogResult == DialogResult.OK)
      {
        this.Close();
        launcher.Close();
      }
    }
    private void EndGameTester()
    {
      if (move50Rule == 50) {
        EndGame('d'); return;
      }
      char color = playerMove ? playerColor : computerColor;
      char winColor = playerMove ? computerColor : playerColor;
      for (int i = 0; i < 6; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          Figure? figure = board[i, j];
          if(figure is not null && figure.color == color)
          {
            if(figure.GetPossibleMoves(board, i, j).Length != 0) return;
          }
          if(i == 5 && j == 4)
          {
            int ki, kj;
            if (playerMove) 
              board.GetPlayerKingIJ(out ki, out kj);
            else board.GetComputerKingIJ(out ki, out kj);
            if (board.IsShahToThisKing(ki, kj)) EndGame(winColor);
            else EndGame('d');
          }
        }
      }
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.DrawImage(board.ObjImg, 0, 0);
      
      for(int i = 0; i < 6; i++)
      {
        for(int j = 0; j < 5; j++)
        {
          Figure? figure = board[i, j];
          if (figure is not null)g.DrawImage(figure.ObjImg, board.firstPosX + board.figureSize.Width * j,
            board.firstPosY + board.figureSize.Height * i);
          
        }
      }
      if (possiblePositions is not null)
      {
        foreach (int[] pos in possiblePositions)
        {
          g.DrawImage(new Bitmap(Sprites.Mark, board.figureSize), board.firstPosX + board.figureSize.Width * pos[1],
            board.firstPosY + board.figureSize.Height * pos[0]);
        }
      }
      if(playerPosI is not null && playerPosJ is not null)
      {
        g.DrawImage(new Bitmap(Sprites.choice, board.figureSize), board.firstPosX + board.figureSize.Width * (int)playerPosJ,
            board.firstPosY + board.figureSize.Height * (int)playerPosI);
      }
      if (transformation)
      {
        g.DrawImage(Sprites.gray, 0, 0);
        g.DrawImage(panel.ObjImg, panel.DrawLocation.X, panel.DrawLocation.Y);
        for (int i = 0; i < possibleFigures.Count; i++)
        {
          Figure? figure = Board.GetFigureFromEnumerator(possibleFigures[i], playerMove ? playerColor : computerColor);
          if(figure is not null)g.DrawImage(figure.ObjImg,panel.FiguresCoordinates[i].X, 
            panel.FiguresCoordinates[i].Y);
          Point CursorPos = this.PointToClient(Cursor.Position);
          if (CursorPos.X >= panel.FiguresCoordinates[i].X &&
            CursorPos.X < panel.FiguresCoordinates[i].X + board.figureSize.Width &&
            CursorPos.Y >= panel.FiguresCoordinates[i].Y &&
            CursorPos.Y < panel.FiguresCoordinates[i].Y + board.figureSize.Height)
            g.DrawImage(new Bitmap(Sprites.PlayerChoice, new Size(120, 120)), panel.FiguresCoordinates[i].X,
              panel.FiguresCoordinates[i].Y);
        }
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Invalidate();
    }
    private void GetIJ(out int i, out int j)
    {
      Point CursorPos = this.PointToClient(Cursor.Position);
      i = (CursorPos.Y - 60) / 120; 
      j = (CursorPos.X - 60) / 120;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      launcher.Close();
    }

    private void PawnChecker()
    {
      for (int i = 0; i < 5; i++)
      {
        Figure? figure = board[0, i];
        if (figure is not null && figure.type == Figures.Pawn &&
          figure.color == playerColor)
          transformation = true;
      }
      for (int i = 0; i < 5; i++)
      {
        Figure? figure = board[5, i];
        if (figure is not null && figure.type == Figures.Pawn &&
          figure.color == computerColor)
        {
          /*
          Figures compChoice = (Figures)move[4];
          board[5, i] = Board.GetFigureFromEnumerator(compChoice, board.isRotated ? 'w' : 'b');
          */
          //Для компьютера
          transformation = true;
        }
      }
    }
    private void PlayerMove(string? move)
    {
      if (!transformation)
      {
        GetIJ(out int i, out int j);
        Figure? figure = Board.InRange(i, j) ? board[i, j] : null;
        if (figure is not null && figure.color == playerColor)
        {
          playerPosI = i; playerPosJ = j;
          possiblePositions = new List<int[]>(0);
          string[]? possibleMoves = figure.GetPossibleMoves(board, i, j);
          if (possibleMoves is not null)
          {
            foreach (string now in possibleMoves)
            {
              int fi, fj, ni, nj;
              Board.Decode(now, board.isRotated, out fi, out fj, out ni, out nj);
              possiblePositions.Add(new int[] { ni, nj });
            }
          }
        }
        else if (playerPosI is not null && playerPosJ is not null)
        {
          foreach (int[] now in possiblePositions)
          {
            if (now[0] == i && now[1] == j)
            {
              lastMove = Board.Recode(board.isRotated, (int)playerPosI, (int)playerPosJ, i, j);
              board.InstantMove(lastMove);
              moveNumber++;
              if (figure is null) move50Rule++;
              else move50Rule = 0;
              possiblePositions.Clear();
              PawnChecker();
              if (!transformation)
              {
                playerMove = false;
                EndGameTester();
              }
              break;
            }
          }
        }
      }
      else
      {
        int fi, fj, ni, nj;
        if(lastMove is not null)
        {
          Board.Decode(lastMove, board.isRotated, out fi, out fj, out ni, out nj);
          Point cursorPosition = this.PointToClient(Cursor.Position);
          int q = 0;
          foreach (Point p in panel.FiguresCoordinates)
          {
            if (cursorPosition.X >= p.X && cursorPosition.X < p.X + 120 &&
              cursorPosition.Y >= p.Y && cursorPosition.Y < p.Y + 120)
            {
              board[ni, nj] = Board.GetFigureFromEnumerator(possibleFigures[q], playerColor);
              playerMove = false;
              transformation = false;
              EndGameTester();
              break;
            }
            q++;
          }
        }
      }
    }
    private void ComputerMove(string? move)
    {
      if (!transformation)
      {
        GetIJ(out int i, out int j);
        Figure? figure = Board.InRange(i, j) ? board[i, j] : null;
        if (figure is not null && figure.color == computerColor)
        {
          playerPosI = i; playerPosJ = j;
          possiblePositions = new List<int[]>(0);
          string[]? possibleMoves = figure.GetPossibleMoves(board, i, j);
          if (possibleMoves is not null)
          {
            foreach (string now in possibleMoves)
            {
              int fi, fj, ni, nj;
              Board.Decode(now, board.isRotated, out fi, out fj, out ni, out nj);
              possiblePositions.Add(new int[] { ni, nj });
            }
          }
        }
        else if (playerPosI is not null && playerPosJ is not null)
        {
          foreach (int[] now in possiblePositions)
          {
            if (now[0] == i && now[1] == j)
            {
              lastMove = Board.Recode(board.isRotated, (int)playerPosI, (int)playerPosJ, i, j);
              board.InstantMove(lastMove);
              moveNumber++;
              if (figure is null) move50Rule++;
              else move50Rule = 0;
              possiblePositions.Clear();
              PawnChecker();
              if (!transformation)
              {
                playerMove = true;
                EndGameTester();
              }
              break;
            }
          }
        }
      }
      else
      {
        int fi, fj, ni, nj;
        if (lastMove is not null)
        {
          Board.Decode(lastMove, board.isRotated, out fi, out fj, out ni, out nj);
          Point cursorPosition = this.PointToClient(Cursor.Position);
          int q = 0;
          foreach (Point p in panel.FiguresCoordinates)
          {
            if (cursorPosition.X >= p.X && cursorPosition.X < p.X + 120 &&
              cursorPosition.Y >= p.Y && cursorPosition.Y < p.Y + 120)
            {
              board[ni, nj] = Board.GetFigureFromEnumerator(possibleFigures[q], computerColor);
              playerMove = true;
              transformation = false;
              EndGameTester();
              break;
            }
            q++;
          }
        }
      }
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      if(playerMove)
      {
        PlayerMove(lastMove);
      }
      else
      {
        ComputerMove(lastMove);
      }
    }
  }
}