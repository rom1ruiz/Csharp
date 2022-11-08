using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {

            return _open[i, j];
        }
        //Possible passage en public
        private bool IsFull(int i, int j)
        {

            return _full[i, j];
        }

        public bool Percolate()
        {
            return _percolate;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            List<KeyValuePair<int, int>> neighbors = new List<KeyValuePair<int, int>>();
            if (i + 1 >= 0 && j >= 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i + 1, j));
            }
            if (i >= 0 && j + 1 >= 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i, j + 1));
            }
            if (i - 1 >= 0 && j >= 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i - 1, j));
            }
            if (i >= 0 && j - 1 >= 0)
            {
                neighbors.Add(new KeyValuePair<int, int>(i, j - 1));
            }

            return neighbors;
        }

        public void Open(int i, int j)
        {
            List<KeyValuePair<int, int>> neighborList = CloseNeighbors(i, j);
            //Ouverture de la case
            _open[i, j] = true;
            foreach (KeyValuePair<int, int> neighbor in neighborList)
            {
                //Si case ouverte a pour voisin une case pleine, 
                if (IsFull(neighbor.Key, neighbor.Value))
                {
                    //alors case ouverte --> pleine
                    _full[i, j] = true;
                }
            }

            if (IsFull(i, j))
            {
                FillNeighbors(neighborList);
            }
            if (IsFull(_size, j))
            {
                _percolate = true;
            }
        }

        private void FillNeighbors(List<KeyValuePair<int, int>> neighbors)
        {
            foreach (KeyValuePair<int, int> neighbor in neighbors)
            {
                if (IsOpen(neighbor.Key, neighbor.Value))
                {
                    _full[neighbor.Key, neighbor.Value] = true;
                    FillNeighbors(CloseNeighbors(neighbor.Key, neighbor.Value));
                }
            }
        }

    }
}
