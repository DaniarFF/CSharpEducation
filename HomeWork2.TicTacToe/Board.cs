namespace HomeWork2.TicTacToe
{
  public static class Board
  {
    public static char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }};

    public static void DrawBoard()
    {
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          Console.Write(board[i, j]);
          if (j < 2) Console.Write("|");
        }
        Console.WriteLine();
        if (i < 2) Console.WriteLine("-----");
      }
    }
  }
}
