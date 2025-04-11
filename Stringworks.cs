namespace _2048
{
    class Stringworks
    {
        public Stringworks() { }

        public string SetStringLength(string input, int length)
        {
            int stringLength = input.Length;

            if (stringLength > length)
                input = input.Substring(0, length);
            else if (stringLength < length)
                input = input.PadLeft(length);

            return input;
        }
    }
}
