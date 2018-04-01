using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    /// <summary>
    /// 方块
    /// </summary>
    public class Block
    {
        public Graphics graphics;
        public BlockTypes BlockType;
        public Square square1;  //组成block的四个小方块
        public Square square2; //组成block的四个小方块
        public Square square3; //组成block的四个小方块
        public Square square4; //组成block的四个小方块
        public enum BlockTypes
        {
            Random = 0,
            Square = 1,
            Line = 2,
            J = 3,
            L = 4,
            T = 5,
            Z = 6,
            S = 7
        };//一共有7种形状
        public enum RotateDirections
        {
            North = 1,
            East = 2,
            South = 3,
            West = 4
        };//方块方向
        private RotateDirections MyRotation = RotateDirections.North;

        public Block(Graphics g, Point thisLocation, BlockTypes bType)
        {
            this.graphics = g;
            if (bType == BlockTypes.Random)
            {
                Random random = new Random();
                bType = (BlockTypes)(random.Next(7) + 1);
            }
            BlockType = bType;
            Size size = new Size(GameSetting.SquareSize, GameSetting.SquareSize);
            square1 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, thisLocation);
            //设置小方块的位置，组合成指定形状的一个大方块
            switch (BlockType)
            {
                case BlockTypes.Square:
                    square2 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y));
                    square3 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X, thisLocation.Y + GameSetting.SquareSize));
                    square4 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y + GameSetting.SquareSize));
                    break;
                case BlockTypes.Line:
                    square2 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y));
                    square3 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize * 2, thisLocation.Y));
                    square4 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize * 3, thisLocation.Y));
                    break;
                case BlockTypes.J:
                    square1.Location.X = square1.Location.X + GameSetting.SquareSize;
                    square2 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y + GameSetting.SquareSize));
                    square3 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y + GameSetting.SquareSize * 2));
                    square4 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X, thisLocation.Y + GameSetting.SquareSize * 2));
                    break;
                case BlockTypes.L:
                    square2 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X, thisLocation.Y + GameSetting.SquareSize));
                    square3 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X, thisLocation.Y + GameSetting.SquareSize * 2));
                    square4 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y + GameSetting.SquareSize * 2));
                    break;
                case BlockTypes.T:
                    square2 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y));
                    square3 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize * 2, thisLocation.Y));
                    square4 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y + GameSetting.SquareSize));
                    break;
                case BlockTypes.Z:
                    square2 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y));
                    square3 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y + GameSetting.SquareSize));
                    square4 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize * 2, thisLocation.Y + GameSetting.SquareSize));
                    break;
                case BlockTypes.S:
                    square1.Location.X = square1.Location.X + GameSetting.SquareSize;
                    square2 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize + GameSetting.SquareSize, thisLocation.Y));
                    square3 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X + GameSetting.SquareSize, thisLocation.Y + GameSetting.SquareSize));
                    square4 = new Square(size, GameSetting.SquareForeColor, GameSetting.SquareBackColor, new Point(thisLocation.X, thisLocation.Y + GameSetting.SquareSize));
                    break;
            }

        }

        /*画方块*/
        public void Draw()
        {
            square1.Draw(graphics);
            square2.Draw(graphics);
            square3.Draw(graphics);
            square4.Draw(graphics);
        }
        /*擦方块*/
        public void Erase()
        {
            square1.Erase(graphics);
            square2.Erase(graphics);
            square3.Erase(graphics);
            square4.Erase(graphics);
        }

        public void Left()
        {
            if (square1.Location.X - GameSetting.SquareSize < 0 ||
                square2.Location.X - GameSetting.SquareSize < 0 ||
                square3.Location.X - GameSetting.SquareSize < 0 ||
                square4.Location.X - GameSetting.SquareSize < 0)
            {
                return;
            }
            else
            {
                this.Erase();
                square1.Location.X = square1.Location.X - GameSetting.SquareSize;
                square2.Location.X = square2.Location.X - GameSetting.SquareSize;
                square3.Location.X = square3.Location.X - GameSetting.SquareSize;
                square4.Location.X = square4.Location.X - GameSetting.SquareSize;
                this.Draw();
            }
        }

        public void Right()
        {
            if (square1.Location.X + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.WidthNumber ||
                square2.Location.X + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.WidthNumber ||
                square3.Location.X + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.WidthNumber ||
                square4.Location.X + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.WidthNumber)
            {
                return;
            }
            else
            {
                this.Erase();
                square1.Location.X = square1.Location.X + GameSetting.SquareSize;
                square2.Location.X = square2.Location.X + GameSetting.SquareSize;
                square3.Location.X = square3.Location.X + GameSetting.SquareSize;
                square4.Location.X = square4.Location.X + GameSetting.SquareSize;
                this.Draw();
            }
        }

        public bool Down()
        {
            if (square1.Location.Y + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.HeightNumber ||
                square2.Location.Y + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.HeightNumber ||
                square3.Location.Y + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.HeightNumber ||
                square4.Location.Y + GameSetting.SquareSize >= GameSetting.SquareSize * GameSetting.HeightNumber)
            {
                return false;
            }
            else
            {
                this.Erase();
                square1.Location.Y = square1.Location.Y + GameSetting.SquareSize;
                square2.Location.Y = square2.Location.Y + GameSetting.SquareSize;
                square3.Location.Y = square3.Location.Y + GameSetting.SquareSize;
                square4.Location.Y = square4.Location.Y + GameSetting.SquareSize;
                this.Draw();
                return true;
            }
        }

        public void Rotate()
        { 
        }
    }
}
