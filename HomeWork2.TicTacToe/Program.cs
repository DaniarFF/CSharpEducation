namespace HomeWork2.TicTacToe
{
  class Program
  {
    static char currentPlayer = 'X';

    static void Main(string[] args)
    {
      int moveCounter = 0;
      bool gameRunning = true;

      while (gameRunning)
      {
        Console.Clear();
        Board.DrawBoard();
        Console.WriteLine($"Первый игрок играет {currentPlayer}, отправь число от 1 до 9: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
        {
          if (GameLogic.MakeMove(move, currentPlayer))
          {
            moveCounter++;
            if (GameLogic.CheckWin(currentPlayer))
            {
              Console.Clear();
              Board.DrawBoard(); 
              Console.WriteLine($"Игрок {currentPlayer} побеждает!");
              gameRunning = false;
            }
            else if (moveCounter == 9)
            {
              Console.Clear();
              Board.DrawBoard();
              Console.WriteLine("Ха, ничья!");
              gameRunning = false;
            }
            else
            {
              currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
          }
          else
          {
            Console.WriteLine("На клетке уже сходили, выбери другую");
          }
        }
        else
        {
          Console.WriteLine("Выберите номер клетки от 0 до 9");
        }
      }
    }
  }
}

