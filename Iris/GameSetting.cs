using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    public class GameSetting
    {
        public static int WidthNumber = 14;
        public static int HeightNumber = 20;
        public const int SquareSize = 20;
        public static Color GameBackColor = Color.FromArgb(116, 139, 123);
        public static Color SquareForeColor = Color.FromArgb(0, 0, 0);
        public static Color SquareBackColor = Color.FromArgb(116, 139, 123);
        public static Color SquareCenterColor = Color.FromArgb(102, 102, 102);
        public static Square[,] SquareList = new Square[WidthNumber, HeightNumber];
    }
}
