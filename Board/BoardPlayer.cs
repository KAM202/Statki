using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatkiC
{
    class BoardPlayer : Board
    {
        private StartWindow startWindow;
        private int shipSize; // rozmiar statku
        private int shipCount; // liczba statkow
        private bool isCompleted;
        private Field firstPoint;
        private List<ShipInfo> shipList;

        public BoardPlayer(StartWindow startWindow)
        {
            this.startWindow = startWindow;
            this.size = Game.sizeBoard;
            this.shipList = Game.shipList;
            this.shipSize = this.shipList.ElementAt(0).GetShipSize();
            this.shipCount = this.shipList.ElementAt(0).GetShipCount();
            this.shipList.RemoveAt(0);
            this.firstPoint = null;
            this.isCompleted = false;
            CountNumberShips();
            this.shipCounts = Game.shipCount;
        }

        public void SetField(int x, int y)
        { 
            if (!CheckField(x, y) || isCompleted) return;
            
            if(firstPoint == null || shipSize == (int)EShip.ONE) //pierwszy punkt 
            {
                startWindow.buttonArray[x, y].Text = shipSize.ToString();
                startWindow.buttonArray[x, y].Enabled = false;
                firstPoint = (shipSize == (int)EShip.ONE)? null: new Field(x, y);
                if (shipSize == (int)EShip.ONE)
                {
                    board[x, y] = (int)EShip.ONE;
                    UpdateShipSizeAndCount();
                }
            }
            else
            {
                if (!CheckDistanceBetweenFields(x, y, firstPoint.getX(), firstPoint.getY())) return;
                FillShip(x, y, firstPoint.getX(), firstPoint.getY());
                UpdateShipSizeAndCount();
                firstPoint = null;
            }
        }
        public void UpdateShipSizeAndCount()
        {
            if (--shipCount == (int)EShip.NONE)
            {
                if (shipList.Count() == (int)EShip.NONE)
                {
                    isCompleted = true;
                }
                else
                {
                    this.shipSize = this.shipList.ElementAt(0).GetShipSize();
                    this.shipCount = this.shipList.ElementAt(0).GetShipCount();
                    shipList.RemoveAt(0);
                }
                
            }
            shipCounts--;
            startWindow.UpdateShipsCount(shipCounts.ToString());
            startWindow.UpdateShipSize(shipSize.ToString());
            firstPoint = null;
        }

        private void CountNumberShips()
        {
            int tempNumber = 1;
            foreach(ShipInfo shipInfo in Game.shipList)
            {
                tempNumber += shipInfo.GetShipCount();
            }
            Game.shipCount = tempNumber;
        }

        public bool CheckDistanceBetweenFields(int xFirst, int yFirst, int xSecond, int ySecond)
        {
            return ((Math.Abs(xFirst - xSecond) == shipSize-1 && yFirst == ySecond) || (Math.Abs(yFirst - ySecond) == shipSize-1 && xFirst == xSecond));
        }

        public bool CheckField(int x, int y) //sprawdza 3x3
        {
            if (firstPoint != null && shipSize == (int)EShip.TWO)
            {
                board[firstPoint.getX(), firstPoint.getY()] = (int)EShip.NONE;

            }

            int tempA = x - 1;
            int tempB = y - 1;

            for(int i = 0; i < 3; i++)
            {
                if(tempA+i < 0 || tempA+i > Game.sizeBoard - 1)
                {
                    continue;
                }
                for (int j = 0; j < 3; j++)
                {
                    if(tempB + j < 0 || tempB + j > Game.sizeBoard - 1)
                    {
                        continue;
                    }
                    if (board[tempA + i, tempB + j] != 0)
                    {
                        if (firstPoint != null && shipSize == (int)EShip.TWO)
                        {
                            board[firstPoint.getX(), firstPoint.getY()] = (int)EShip.TWO;
                        }
                        return false;
                    }
                }
            }

            if (firstPoint != null && shipSize == (int)EShip.TWO)
            {
                board[firstPoint.getX(), firstPoint.getY()] = (int)EShip.TWO;
            }
            return true;

        }

        public void FillShip(int xFirst, int yFirst, int xSecond, int ySecond)
        {
            if (shipSize == (int)EShip.TWO)
            {
                board[xFirst, yFirst] = shipSize;
                startWindow.buttonArray[xFirst, yFirst].Text = shipSize.ToString();
                startWindow.buttonArray[xFirst, yFirst].Enabled = false;
                return;
            }

            EDirection eDirection = ((xFirst == xSecond) ? EDirection.HORIZONTAL : EDirection.VERTICAL);
            int firstPoint = (eDirection == EDirection.HORIZONTAL) ? (yFirst < ySecond) ? yFirst : ySecond : (xFirst < xSecond)? xFirst : xSecond;
            int secondPoint = (eDirection == EDirection.HORIZONTAL) ? (yFirst > ySecond) ? yFirst : ySecond : (xFirst > xSecond)? xFirst : xSecond;
            
            for(int i = firstPoint; i < secondPoint + 1; i++)
            {
                if (eDirection == EDirection.HORIZONTAL)
                {
                    board[xFirst, i] = shipSize;
                    startWindow.buttonArray[xFirst, i].Text = shipSize.ToString();
                    startWindow.buttonArray[xFirst, i].Enabled = false;
                }
                else
                {
                    board[i, yFirst] = shipSize;
                    startWindow.buttonArray[i, yFirst].Text = shipSize.ToString();
                    startWindow.buttonArray[i, yFirst].Enabled = false;
                }
                
            }
        }
    }
}
