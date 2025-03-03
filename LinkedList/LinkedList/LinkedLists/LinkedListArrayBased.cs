namespace LinkedList
{
    public class LinkedListArrayBased
    {
        private readonly List<char> _data;

        public LinkedListArrayBased()
        {
            _data = new List<char>();
        }

        public LinkedListArrayBased(char data)
        {
            _data = [data];
        }
        public LinkedListArrayBased(List<char> initialData)
        {
            _data = new List<char>(initialData);
        }

        public void Add(char data)
        {
            _data.Add(data);
        }

        public string GetListString()
        {
            return string.Join(" -> ", _data) + " -> null";
        }

        public string GetListStringSimple()
        {
            return string.Join("", _data);
        }

        public int Length()
        {
            return _data.Count;
        }

        public void AddToPos(int pos, char data)
        {
            if (pos < 0 || pos > _data.Count)
                throw new IndexOutOfRangeException("Position is out of range");

            _data.Insert(pos, data);
        }

        public void DeleteElement(int pos)
        {
            if (pos < 0 || pos >= _data.Count)
                throw new IndexOutOfRangeException("Position is out of range");

            _data.RemoveAt(pos);
        }

        public char GetElement(int pos)
        {
            if (pos < 0 || pos >= _data.Count)
                throw new IndexOutOfRangeException("Position is out of range");

            return _data[pos];
        }

        public LinkedListArrayBased Copy()
        {
            return new LinkedListArrayBased(new List<char>(_data));
        }

        public LinkedListArrayBased Reverse()
        {
            _data.Reverse();
            return this;
        }

        public int Find(char data)
        {
            return _data.IndexOf(data);
        }

        public char FindLast()
        {
            return _data.Last();
        }
        public int FindFromEnd(char data)
        {
            return Length() - _data.LastIndexOf(data) - 1;
        }
    }
}