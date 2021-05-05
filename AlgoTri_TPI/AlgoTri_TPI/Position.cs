using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTri_TPI
{
    public class Position
    {
        private List<int> _position;
        public List<int> position { get => _position; set => _position = value; }
        public Position(List<int> p)
        {
            position = p;
        }

    }
}
