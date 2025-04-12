namespace _2048
{
    internal class Program
    {
        #pragma warning disable CS8618
        private static GameManager gameManager;
        #pragma warning restore CS8618

        public Program() { }

        static void Main(string[] args)
        {
            byte boardSize = 4;

            Program program = new Program();
            Console.WriteLine("This is a rudimentary implementation of the game 2048 as a console application.");
            Console.WriteLine("Goal of the game is to merge numbers to arrive at 2048.");
            Console.WriteLine("When numbers are merged, their amounts get added together.");
            Console.WriteLine();
            Console.WriteLine("To move and merge all numbers press the arrow keys.");
            Console.WriteLine();
            Thread.Sleep(2000);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            gameManager = new GameManager(new CellsManager(boardSize, boardSize));
            program.Start();
        }

        private void Start() => gameManager.StartGame();
    }
}
