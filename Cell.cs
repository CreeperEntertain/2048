namespace _2048
{
    internal class Cell
    {
        private short amount;

        public Cell(short amount)
        {
            this.amount = amount;
        }

        public short GetAmount() => this.amount;
        public void SetAmount(short newAmount) => this.amount = newAmount;
    }
}