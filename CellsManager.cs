namespace _2048
{
    internal class CellsManager
    {
        private Cell[,] cells;
        private short[,] amounts;

        public CellsManager()
        {
            this.cells = new Cell[3, 3];
            this.amounts = new short[3, 3];

            for (byte x = 0; x < 3; x++)
                for (byte y = 0; y < 3; y++)
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
            for (byte x = 0; x < 3; x++)
                for (byte y = 0; y < 3; y++)
                    cells[y, x].SetAmount(0);
            UpdateAmounts();
        }
        public override string ToString()
        {
            return "";
        }

        private void UpdateAmounts()
        {
            for (byte x = 0; x < 3; x++)
                for (byte y = 0; y < 3; y++)
                    amounts[x, y] = GetCellAmount(x, y);
        }
    }
}