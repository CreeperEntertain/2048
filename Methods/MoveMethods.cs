using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _2048.Methods
{
    class MoveMethods
    {
        public MoveMethods() { }

        public bool MoveUp(byte boardX, byte boardY, Cell[,] cells, Func<bool> AddRandomAmount, Action Output)
        {
            Dictionary<string, List<Tuple<byte, byte, short>>> lines = new Dictionary<string, List<Tuple<byte, byte, short>>>();
            for (byte x = 0; x < boardX; x++)
            {
                var lineKey = $"line{x}";
                var list = new List<Tuple<byte, byte, short>>();
                for (byte y = 0; y < boardY; y++)
                    list.Add(Tuple.Create(x, y, cells[x, y].GetAmount()));
                lines[lineKey] = list;
            }

            for (byte x = 0; x < boardX; x++)
            {
                bool repeat;
                do
                {
                    repeat = false;

                    for (byte y = 1; y < boardY; y++)
                    {
                        byte localX = x;
                        byte localY = y;
                        short amount = cells[localX, localY].GetAmount();

                        if (amount == 0)
                            continue;

                        if (cells[localX, localY - 1].GetAmount() == 0)
                        {
                            cells[localX, localY - 1].SetAmount(amount);
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                        else if (cells[localX, localY - 1].GetAmount() == amount)
                        {
                            cells[localX, localY - 1].SetAmount((short)(amount * 2));
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                    }
                } while (repeat);
            }

            bool addedAmount = AddRandomAmount();
            Output();

            return addedAmount;
        }

        public bool MoveDown(byte boardX, byte boardY, Cell[,] cells, Func<bool> AddRandomAmount, Action Output)
        {
            Dictionary<string, List<Tuple<byte, byte, short>>> lines = new Dictionary<string, List<Tuple<byte, byte, short>>>();
            for (byte x = 0; x < boardX; x++)
            {
                var lineKey = $"line{x}";
                var list = new List<Tuple<byte, byte, short>>();
                for (int y = boardY - 1; y >= 0; y--)
                    list.Add(Tuple.Create(x, (byte)y, cells[x, y].GetAmount()));
                lines[lineKey] = list;
            }

            for (byte x = 0; x < boardX; x++)
            {
                bool repeat;
                do
                {
                    repeat = false;

                    for (int y = boardY - 2; y >= 0; y--)
                    {
                        byte localX = x;
                        byte localY = (byte)y;
                        short amount = cells[localX, localY].GetAmount();

                        if (amount == 0)
                            continue;

                        if (cells[localX, localY + 1].GetAmount() == 0)
                        {
                            cells[localX, localY + 1].SetAmount(amount);
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                        else if (cells[localX, localY + 1].GetAmount() == amount)
                        {
                            cells[localX, localY + 1].SetAmount((short)(amount * 2));
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                    }
                } while (repeat);
            }

            bool addedAmount = AddRandomAmount();
            Output();

            return addedAmount;
        }

        public bool MoveLeft(short boardX, short boardY, Cell[,] cells, Func<bool> AddRandomAmount, Action Output)
        {
            Dictionary<string, List<Tuple<byte, byte, short>>> lines = new Dictionary<string, List<Tuple<byte, byte, short>>>();
            for (byte y = 0; y < boardY; y++)
            {
                var lineKey = $"line{y}";
                var list = new List<Tuple<byte, byte, short>>();
                for (byte x = 0; x < boardX; x++)
                    list.Add(Tuple.Create(x, y, cells[x, y].GetAmount()));
                lines[lineKey] = list;
            }

            for (byte y = 0; y < boardY; y++)
            {
                bool repeat;
                do
                {
                    repeat = false;

                    for (byte x = 1; x < boardX; x++)
                    {
                        byte localX = x;
                        byte localY = y;
                        short amount = cells[localX, localY].GetAmount();

                        if (amount == 0)
                            continue;

                        if (cells[localX - 1, localY].GetAmount() == 0)
                        {
                            cells[localX - 1, localY].SetAmount(amount);
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                        else if (cells[localX - 1, localY].GetAmount() == amount)
                        {
                            cells[localX - 1, localY].SetAmount((short)(amount * 2));
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                    }
                } while (repeat);
            }

            bool addedAmount = AddRandomAmount();
            Output();

            return addedAmount;
        }
        public bool MoveRight(short boardX, short boardY, Cell[,] cells, Func<bool> AddRandomAmount, Action Output)
        {
            Dictionary<string, List<Tuple<byte, byte, short>>> lines = new Dictionary<string, List<Tuple<byte, byte, short>>>();
            for (byte y = 0; y < boardY; y++)
            {
                var lineKey = $"line{y}";
                var list = new List<Tuple<byte, byte, short>>();
                for (int x = boardX - 1; x >= 0; x--)
                    list.Add(Tuple.Create((byte)x, y, cells[x, y].GetAmount()));
                lines[lineKey] = list;
            }

            for (byte y = 0; y < boardY; y++)
            {
                bool repeat;
                do
                {
                    repeat = false;

                    for (int x = boardX - 2; x >= 0; x--)
                    {
                        byte localX = (byte)x;
                        byte localY = y;
                        short amount = cells[localX, localY].GetAmount();

                        if (amount == 0)
                            continue;

                        if (cells[localX + 1, localY].GetAmount() == 0)
                        {
                            cells[localX + 1, localY].SetAmount(amount);
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                        else if (cells[localX + 1, localY].GetAmount() == amount)
                        {
                            cells[localX + 1, localY].SetAmount((short)(amount * 2));
                            cells[localX, localY].SetAmount(0);
                            repeat = true;
                        }
                    }
                } while (repeat);
            }

            bool addedAmount = AddRandomAmount();
            Output();

            return addedAmount;
        }
    }
}
