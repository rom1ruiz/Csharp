using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }
        /// <summary>
        /// Fraction
        /// </summary>
        public double Fraction { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            PclData data = new PclData();
            double isPercolate = PercolationValue(size);
            //data.Mean = ;
            //data.Fraction = ;
            //data.StandardDeviation = ;
            return new PclData();
        }

        public double PercolationValue(int size)
        {
            Random rd = new Random();
            Percolation p = new Percolation(size);
            double isPercolate;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                //Ouverture d'une case aléatoire
                int i = rd.Next(0, size);
                int j = rd.Next(0, size);
                p.Open(i, j);
                

            } while (p.Percolate());
            sw.Stop();
            isPercolate = sw.ElapsedMilliseconds;
            return isPercolate;
        }
    }
}
