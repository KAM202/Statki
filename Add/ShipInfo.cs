using System;
using System.Collections.Generic;
using System.Text;

namespace StatkiC
{
    class ShipInfo
    {
        private int shipSize;
        private int shipCount;

        public ShipInfo(int shipSize, int shipCount)
        {
            this.shipSize = shipSize;
            this.shipCount = shipCount;
        }

        public int GetShipSize()
        {
            return shipSize;
        }

        public int GetShipCount()
        {
            return shipCount;
        }
    }
}
