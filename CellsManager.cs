namespace _2048
{
    internal class CellsManager
    {
        private Cell[,] cells;
        private short[,] amounts;
        private Stringworks stringworks;
        private byte boardX;
        private byte boardY;

        private Random random = new Random();

        public CellsManager(byte boardX, byte boardY)
        {
            this.boardX = boardX;
            this.boardY = boardY;
            this.cells = new Cell[this.boardX, this.boardY];
            this.amounts = new short[this.boardX, this.boardY];
            this.stringworks = new Stringworks();

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
            for (byte column = 0; column < boardY; column++)
            {
                output += "\n ";
                for (byte row = 0; row < boardX; row++) output += $"{stringworks.SetStringLength(cells[column, row].GetAmount().ToString() ?? "", 4)} ";
                output += $"\n{horizontalLine}";
            }
            return output;
        }
        public void Output() => Console.WriteLine(ToString());
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
        private void UpdateAmounts()
        {
            for (byte x = 0; x < boardX; x++)
                for (byte y = 0; y < boardY; y++)
                    amounts[x, y] = GetCellAmount(x, y);
        }
    }
}