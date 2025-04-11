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
        }
        public void Display() => Console.WriteLine(cellsManager.ToString());
    }
}
