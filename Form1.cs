using Microsoft.VisualBasic;
using static ShessGUI.Board;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;

namespace ShessGUI
{
  public partial class Form1 : Form
  {
    Form2 launcher;
    SoundPlayer chessSound;
    Process engine;
    StreamWriter streamWriter;
    StreamReader streamReader;
    Board board;
    List<int[]> possiblePositions;
    List<Figures> possibleFigures;
    int? playerPosI, playerPosJ;
    int moveNumber, move50Rule;
    public char moveColor;
    bool playerMove, transformation, computerMoving = false;
    public int whiteDifficult=0, blackDifficult=0;
    char playerColor='d', computerColor='d';
    string? lastMove = null;
    ChoosingPanel panel;
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
    public Form1(string FEN, Form2 launcher)
    {
      this.whiteDifficult = launcher.whiteDifficult;
      this.blackDifficult = launcher.blackDifficult;
      chessSound = new();
      chessSound.Stream = Other.FigureSound;
      engine = new Process();
      engine.StartInfo.FileName = launcher.path;
      engine.StartInfo.UseShellExecute = false;
      engine.StartInfo.RedirectStandardOutput = true;
      engine.StartInfo.RedirectStandardInput = true;
      engine.StartInfo.CreateNoWindow = true;
      engine.Start();
      if(whiteDifficult!=0||blackDifficult!=0)AllocConsole();
      streamWriter = engine.StandardInput;
      streamReader = engine.StandardOutput;
      streamReader.ReadLine();
      streamWriter.WriteLine($"position {FEN.Substring(0, FEN.Length)}");
      Console.WriteLine($"position {FEN.Substring(0, FEN.Length)}");
      bool isBoardRotated;
      int p1 = 0;
      while (FEN[p1] != ' ') p1++;
      p1++;
      moveColor = FEN[p1];
      if ((whiteDifficult != 0 && blackDifficult != 0) ||
        (whiteDifficult == 0 && blackDifficult == 0))
      {
        isBoardRotated = false;
        if (whiteDifficult != 0) playerMove = false;
        else playerMove = true;
      }
      else
      {
        if (whiteDifficult == 0) playerColor = 'w';
        else playerColor = 'b';
        computerColor = playerColor == 'w' ? 'b' : 'w';
        if (playerColor == 'b') isBoardRotated = true;
        else isBoardRotated = false;
        int p = 0;
        while (FEN[p] != ' ') p++;
        p++;
        if (FEN[p] == playerColor) playerMove = true;
        else playerMove = false;
      }
      board = new Board(0, 0, FEN, isBoardRotated, launcher.theme);
      this.launcher = launcher;
      InitializeComponent();
      this.DoubleBuffered = true;
      transformation = false;
      possibleFigures = board.possibleFigures;
      moveNumber = board.moveNumber; move50Rule = board.move50Rule;
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
      if (launcher.language == "language:Русский")
      {
        if (result == 'd') dialogResult = MessageBox.Show("Ничья", "Игра окончена!");
        else if (result == 'w') dialogResult = MessageBox.Show("Белые победили", "Игра окончена!");
        else dialogResult = MessageBox.Show("Чёрные победили", "Игра окончена!");
      }
      else
      {
        if (result == 'd') dialogResult = MessageBox.Show("Draw", "Game Finished!");
        else if (result == 'w') dialogResult = MessageBox.Show("White won", "Game Finished!");
        else dialogResult = MessageBox.Show("Black won", "Game Finished!");
      }
      if(dialogResult == DialogResult.Cancel || 
        dialogResult == DialogResult.OK) this.Close();
    }
    private void EndGameTester()
    {
      if (move50Rule == 50) {
        EndGame('d'); return;
      }
      for (int i = 0; i < 6; i++)
      {
        for (int j = 0; j < 5; j++)
        {
          Figure? figure = board[i, j];
          if(figure is not null && figure.color != moveColor)
          {
            if(figure.GetPossibleMoves(board, i, j).Length != 0) return;
          }
          if(i == 5 && j == 4)
          {
            int ki, kj;
            if (moveColor == 'w') 
              board.GetBlackKingIJ(out ki, out kj);
            else board.GetWhiteKingIJ(out ki, out kj);
            if (board.IsShahToThisKing(ki, kj)) EndGame(moveColor);
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
          Figure? figure = Board.GetFigureFromEnumerator(possibleFigures[i], moveColor);
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
      if (!playerMove && !computerMoving) ComputerMove(lastMove);
    }
    private void GetIJ(out int i, out int j)
    {
      Point CursorPos = this.PointToClient(Cursor.Position);
      i = (CursorPos.Y - 60) / 120; 
      j = (CursorPos.X - 60) / 120;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      streamWriter.WriteLine("quit");
      engine.CloseMainWindow();
      streamReader.Close();
      streamWriter.Close();
      engine.Close();
      launcher.Close();
    }

    private void PawnChecker()
    {
      for (int i = 0; i < 5; i++)
      {
        Figure? figure = board[0, i];
        if (figure is not null && figure.type == Figures.Pawn)
          transformation = true;
      }
      for (int i = 0; i < 5; i++)
      {
        Figure? figure = board[5, i];
        if (figure is not null && figure.type == Figures.Pawn)
          transformation = true;
      }
    }
    private void PlayerMove(string? move)
    {
      if (!transformation)
      {
        GetIJ(out int i, out int j);
        Figure? figure = Board.InRange(i, j) ? board[i, j] : null;
        if (figure is not null && figure.color == moveColor)
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
              Invalidate();
              chessSound.Play();
              moveNumber++;
              if (figure is null) move50Rule++;
              else move50Rule = 0;
              possiblePositions.Clear();
              PawnChecker();
              if (!transformation)
              {
                streamWriter.WriteLine($"apply {lastMove}");
                Console.WriteLine($"apply {lastMove}");
                EndGameTester();
                moveColor = moveColor == 'w' ? 'b' : 'w';
                if (computerColor == moveColor) playerMove = false;
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
              board[ni, nj] = Board.GetFigureFromEnumerator(possibleFigures[q], moveColor);
              Invalidate();
              transformation = false;
              lastMove += (char)possibleFigures[q];
              streamWriter.WriteLine($"apply {lastMove}");
              Console.WriteLine($"apply {lastMove}");
              EndGameTester();
              moveColor = moveColor == 'w' ? 'b' : 'w';
              if (computerColor == moveColor) playerMove = false;
              break;
            }
            q++;
          }
        }
      }
    }
    private void ComputerMove(string? move)
    {
      computerMoving = true;
      if (moveColor == 'w') {
        streamWriter.WriteLine($"search {1000 * whiteDifficult}");
        lastMove = streamReader.ReadLine();
        streamWriter.WriteLine($"apply {lastMove}");
        Console.WriteLine($"apply {lastMove}");
        Board.Decode(lastMove, board.isRotated, out int fi, out int fj, out int ni, out int nj);
        Figure? figure = board[ni, nj];
        board.InstantMove(lastMove);
        if (figure is null) move50Rule++;
        else move50Rule = 0;
        moveNumber++;
        if (lastMove.Length == 5) board[ni, nj] = GetFigureFromEnumerator((Figures)lastMove[4], 'w');
        EndGameTester();
        moveColor = 'b';
      }
      else {
        streamWriter.WriteLine($"search {1000 * blackDifficult}");
        lastMove = streamReader.ReadLine();
        streamWriter.WriteLine($"apply {lastMove}");
        Console.WriteLine($"apply {lastMove}");
        Board.Decode(lastMove, board.isRotated, out int fi, out int fj, out int ni, out int nj);
        Figure? figure = board[ni, nj];
        board.InstantMove(lastMove);
        if (figure is null) move50Rule++;
        else move50Rule = 0;
        moveNumber++;
        if (lastMove.Length == 5) board[ni, nj] = GetFigureFromEnumerator((Figures)lastMove[4], 'b');
        EndGameTester();
        moveColor = 'w';
      }
      chessSound.Play();
      if (playerColor == moveColor) playerMove = true;
      computerMoving = false;
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      if(playerMove) PlayerMove(lastMove);
    }
  }
}