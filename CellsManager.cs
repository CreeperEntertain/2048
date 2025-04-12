using _2048.Methods;

namespace _2048
{
    internal class CellsManager
    {
        private Stringworks stringworks;
        private MoveMethods moveMethods;

        private Cell[,] cells;
        private short[,] amounts;
        private byte boardX;
        private byte boardY;

        private Random random = new Random();
        public enum Directions { Up, Left, Down, Right }

        public CellsManager(byte boardX, byte boardY)
        {
            this.stringworks = new Stringworks();
            this.moveMethods = new MoveMethods();

            this.boardX = boardX;
            this.boardY = boardY;
            this.cells = new Cell[this.boardX, this.boardY];
            this.amounts = new short[this.boardX, this.boardY];

            for (byte x = 0; x < this.boardX; x++)
                for (byte y = 0; y < this.boardY; y++)
                    cells[x, y] = new Cell(0);
        }

        public short GetCellAmount(byte x, byte y) => cells[x, y].GetAmount();
        public void SetCellAmount(byte x, byte y, short newAmount)
        {
            cells[x, y].SetAmount(newAmount);
            UpdateAmounts();
        }
        public void ResetBoard()
        {
            for (byte x = 0; x < boardX; x++)
                for (byte y = 0; y < boardY; y++)
                    cells[y, x].SetAmount(0);
            UpdateAmounts();
        }
        public override string ToString()
        {
            string horizontalLine = " ";
            for (byte x = 0; x < boardX; x++)
                horizontalLine += "     ";
            string output = horizontalLine;
            for (byte row = 0; row < boardX; row++)
            {
                output += "\n ";
                for (byte column = 0; column < boardY; column++)
                {
                    short amount = cells[column, row].GetAmount();
                    if (amount > 0)
                        output += $"{stringworks.SetStringLength(amount.ToString() ?? "", 4)} ";
                    else output += "     ";
                }
                output += $"\n{horizontalLine}";
            }
            return output;
        }
        public void Output()
        {
            Console.Clear();
            Console.WriteLine(ToString());
        }
        public bool AddRandomAmount()
        {
            List<Tuple<byte, byte, short>> emptyCells = new List<Tuple<byte, byte, short>>();
            for (byte x = 0; x < boardX; x++)
                for (byte y = 0; y < boardY; y++)
                    if (GetCellAmount(x, y) == 0)
                        emptyCells.Add(new Tuple<byte, byte, short>(x, y, GetCellAmount(x, y)));
            if (emptyCells.Count == 0)
                return false;
            int randomCell = random.Next(emptyCells.Count);
            Tuple<byte, byte, short> selectedCell = emptyCells[randomCell];

            int addedAmount = random.Next(10) == 0 ? 4 : 2;
            cells[selectedCell.Item1, selectedCell.Item2].SetAmount((short)addedAmount);
            UpdateAmounts();
            return true;
        }
        public void Contains2048()
        {
            foreach (Cell cell in cells)
                if (cell.GetAmount() >= 2048)
                {
                    Console.WriteLine("You won!");
                    Thread.Sleep(2000);
                    Console.WriteLine("Press any key to quit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
        }
        
        public bool Move(Directions direction)
            => new Func<bool>[]
            {
                () => moveMethods.MoveUp(boardX, boardY, cells, AddRandomAmount, Output),
                () => moveMethods.MoveLeft(boardX, boardY, cells, AddRandomAmount, Output),
                () => moveMethods.MoveDown(boardX, boardY, cells, AddRandomAmount, Output),
                () => moveMethods.MoveRight(boardX, boardY, cells, AddRandomAmount, Output)
            }[(int)direction]();

        private void UpdateAmounts()
        {
            for (byte x = 0; x < boardX; x++)
                for (byte y = 0; y < boardY; y++)
                    amounts[x, y] = GetCellAmount(x, y);
        }
    }
}