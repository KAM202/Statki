using System;
using System.Collections.Generic;
using System.Text;

namespace StatkiC
{
    class Field
    {
        private int x;
        private int y;

        public Field(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
    }
}
