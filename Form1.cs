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
    int cci=0, ccj=0;
    bool computerChoice = false;
    public char moveColor;
    bool playerMove, transformation, computerMoving = false;
    public int whiteDifficult=0, blackDifficult=0;
    char playerColor='d', computerColor='d';
    string? lastMove = null;
    ChoosingPanel panel;
    Dictionary<string, int> memory;
    public Form1(string FEN, Form2 launcher)
    {
      memory = new();
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
      streamWriter = engine.StandardInput;
      streamReader = engine.StandardOutput;
      streamReader.ReadLine();
      Console.WriteLine("ready");
      streamWriter.WriteLine($"position {FEN.Substring(0, FEN.Length)}");
      Console.WriteLine($"position {FEN.Substring(0, FEN.Length)}");
      streamReader.ReadLine();
      Console.WriteLine("okpos");
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
      if (dialogResult == DialogResult.Cancel ||
        dialogResult == DialogResult.OK)
      {
        SafeClose();
      }
    }
    public void SafeClose()
    {
      if (this.InvokeRequired)
      {
        Action safeClose = delegate { SafeClose(); };
        this.Invoke(safeClose);
      }
      else this.Close();
    }
    private void EndGameTester()
    {
      string fen = board.GetFen();
      int count;
      if (memory.TryGetValue(fen, out count) && count < 2) memory[fen]++;
      else if (!memory.TryGetValue(fen, out count)) memory[fen] = 1;
      else move50Rule = 100;
      if (move50Rule == 100) {
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
          if (figure is not null && figure.type != Board.Figures.King)g.DrawImage(figure.ObjImg, board.firstPosX + board.figureSize.Width * j,
            board.firstPosY + board.figureSize.Height * i);
          else if(figure is not null && figure.type == Board.Figures.King)
          {
            if(board.IsShahToThisKing(i, j))
            {
              g.DrawImage(new Bitmap(Other.ShahToKing, new Size(120, 120)), 
                board.firstPosX + board.figureSize.Width * j,
                board.firstPosY + board.figureSize.Height * i);
            }
            g.DrawImage(figure.ObjImg, board.firstPosX + board.figureSize.Width * j,
              board.firstPosY + board.figureSize.Height * i);
          }
          
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
      if(playerPosI is not null && playerPosJ is not null && computerChoice == false)
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
      if(computerChoice)
      {
        g.DrawImage(new Bitmap(Sprites.choice, new Size(120, 120)),
          board.firstPosX + board.figureSize.Width * ccj,
          board.firstPosY + board.figureSize.Height * cci);
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      Invalidate();
      if (!playerMove && !computerMoving)
      {
        Thread thr = new(ComputerMoveThread);
        thr.Start();
      }
    }
    void ComputerMoveThread()
    {
      ComputerMove(lastMove);
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
      launcher.Show();
    }

    private void PawnChecker()
    {
      for (int i = 0; i < 5; i++)
      {
        Figure? figure = board[0, i];
        if (figure is not null && figure.type == Figures.Pawn)
          if((board.isRotated && figure.color == 'b') || (figure.color == 'w' && !board.isRotated))
            transformation = true;
      }
      for (int i = 0; i < 5; i++)
      {
        Figure? figure = board[5, i];
        if (figure is not null && figure.type == Figures.Pawn)
          if ((board.isRotated && figure.color == 'w') || (figure.color == 'b' && !board.isRotated))
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
          computerChoice = false;
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
              Figure figure2 = board[(int)playerPosI, (int)playerPosJ];
              board.InstantMove(lastMove);
              Invalidate();
              chessSound.Play();
              moveNumber++;
              if (figure is null && figure2.type != Board.Figures.Pawn) move50Rule++;
              else move50Rule = 0;
              possiblePositions.Clear();
              PawnChecker();
              if (!transformation)
              {
                streamWriter.WriteLine($"apply {lastMove}");
                Console.WriteLine($"apply {lastMove}");
                string s = streamReader.ReadLine();
                Console.WriteLine(s);
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
              string s = streamReader.ReadLine();
              Console.WriteLine(s);
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
        Console.WriteLine($"search {1000 * whiteDifficult}");
        lastMove = streamReader.ReadLine();
        Console.WriteLine(lastMove);
        lastMove = lastMove.Substring(9, 5);
        if (lastMove[4] == ' ') lastMove = lastMove.Substring(0, 4);
        streamWriter.WriteLine($"apply {lastMove}");
        Console.WriteLine($"apply {lastMove}");
        string s = streamReader.ReadLine();
        Console.WriteLine(s);
        Board.Decode(lastMove, board.isRotated, out int fi, out int fj, out int ni, out int nj);
        Figure? figure = board[ni, nj];
        Figure? figure2 = board[fi, fj];
        cci = fi; ccj = fj;
        board.InstantMove(lastMove);
        if ((figure2 is not null && figure2.type != Board.Figures.Pawn) && figure is null) move50Rule++;
        else move50Rule = 0;
        moveNumber++;
        if (lastMove.Length == 5) board[ni, nj] = GetFigureFromEnumerator((Figures)lastMove[4], 'w');
        EndGameTester();
        moveColor = 'b';
      }
      else {
        streamWriter.WriteLine($"search {1000 * blackDifficult}");
        Console.WriteLine($"search {1000 * blackDifficult}");
        lastMove = streamReader.ReadLine();
        Console.WriteLine(lastMove);
        lastMove = lastMove.Substring(9, 5);
        if (lastMove[4] == ' ') lastMove = lastMove.Substring(0, 4);
        streamWriter.WriteLine($"apply {lastMove}");
        Console.WriteLine($"apply {lastMove}");
        string s = streamReader.ReadLine();
        Console.WriteLine(s);
        Board.Decode(lastMove, board.isRotated, out int fi, out int fj, out int ni, out int nj);
        Figure? figure = board[ni, nj];
        Figure? figure2 = board[fi, fj];
        cci = fi; ccj = fj;
        board.InstantMove(lastMove);
        if ((figure2 is not null && figure2.type != Board.Figures.Pawn) && figure is null) move50Rule++;
        else move50Rule = 0;
        moveNumber++;
        if (lastMove.Length == 5) board[ni, nj] = GetFigureFromEnumerator((Figures)lastMove[4], 'b');
        EndGameTester();
        moveColor = 'w';
      }
      chessSound.Play();
      if (playerColor == moveColor) playerMove = true;
      computerMoving = false;
      computerChoice = true;
    }
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
      if(playerMove) PlayerMove(lastMove);
    }
  }
}