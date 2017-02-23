using System;
using System.Collections.Generic;

namespace Builder
{
    internal class Product
    {
        private readonly List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            foreach (var part in _parts)
            {
                Console.WriteLine(part);
            }
        }
    }
}