namespace _2048
{
    internal class Program
    {
        private GameManager gameManager;

        public Program()
        {
            gameManager = new GameManager(new CellsManager(4, 4));
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start() => gameManager.StartGame();
    }
}
