using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalMiner.library.classes
{
    public class Range
    {
        private Random random = new Random();

        public int min, max;

        public Range(int min, int max) { 
            this.min = min;
            this.max = max;
        }

        public int randomNumber()
        {
            return random.Next(min, max);
        }
    }
}
