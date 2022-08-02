using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StatkiC
{
    class Board
    {
        protected int size;
        protected int[,] board;
        protected int shipCounts;

        public Board()
        {
            board = new int[Game.sizeBoard, Game.sizeBoard];
        }

        protected void FillBoard()
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    board[i, j] = (int)EField.EMPTY;
                }
            }
        }

        public int GetShipsCount()
        {
            return shipCounts;
        }

        public int[,] GetBoard()
        {
            return board;
        }

    }

}
