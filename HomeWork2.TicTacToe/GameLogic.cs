namespace HomeWork2.TicTacToe
{
  public static class GameLogic
  {
    static public bool MakeMove(int move, char currentPlayer)
    {
      char[,] board = Board.board;
      int row = (move - 1) / 3;
      int col = (move - 1) % 3;

      if (board[row, col] != 'X' && board[row, col] != 'O')
      {
        board[row, col] = currentPlayer;
        return true;
      }
      return false;
    }

    public static bool CheckWin(char currentPlayer)
    {
      char[,] board = Board.board;

      for (int i = 0; i < 3; i++)
      {
        if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
          return true;
      }

      for (int i = 0; i < 3; i++)
      {
        if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
          return true;
      }

      if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        return true;

      if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        return true;

      return false;
    }
  }
}
