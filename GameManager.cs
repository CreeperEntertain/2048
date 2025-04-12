namespace _2048
{
    internal class GameManager
    {
        private CellsManager cellsManager;

        public GameManager(CellsManager cellsManager)
        {
            this.cellsManager = cellsManager;
        }

        public void StartGame()
        {
            cellsManager.ResetBoard();
            cellsManager.AddRandomAmount();
            cellsManager.Output();

            bool hasLost = false;
            byte stuckMoves = 0;
            bool tempStuck = false;
            while (!hasLost)
            {
                tempStuck = false;
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        tempStuck = !cellsManager.Move(CellsManager.Directions.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        tempStuck = !cellsManager.Move(CellsManager.Directions.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        tempStuck = !cellsManager.Move(CellsManager.Directions.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        tempStuck = !cellsManager.Move(CellsManager.Directions.Right);
                        break;
                }
                cellsManager.Contains2048();
                if (tempStuck)
                    if (stuckMoves < 4)
                    {
                        Console.WriteLine($"You're stuck. Moves left: {4 - stuckMoves}");
                        stuckMoves++;
                    }
                    else hasLost = true;
            }
            if (hasLost)
            {
                Console.WriteLine("You lost!");
                Thread.Sleep(2000);
                Console.WriteLine("Press any key to quit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.ReadKey();
        }
        public void Display() => Console.WriteLine(cellsManager.ToString());
    }
}