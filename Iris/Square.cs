using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris
{
    public class Square
    {
        public Point Location;
        public Size Size;
        public Color ForeColor;
        public Color BackColor;
        public Square(Size initSize, Color initForeColor, Color initBackColor, Point position = default(Point))
        {
            Size = initSize;
            ForeColor = initForeColor;
            BackColor = initBackColor;
            Location = position;
        }
        //画方块
        public void Draw(Graphics g)
        {
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(Location, Size);
            gp.AddRectangle(rec);
            Color[] surroundColor = new Color[] { BackColor };
            PathGradientBrush pb = new PathGradientBrush(gp);
            pb.CenterColor = ForeColor;
            pb.SurroundColors = surroundColor;
            g.FillPath(pb, gp);
        }
        //擦除方块
        public void Erase(Graphics g)
        {
            //Rectangle rec = new Rectangle(Location, Size);
            //g.FillRectangle(new SolidBrush(GameSetting.GameBackColor), rec);
            GraphicsPath gp = new GraphicsPath();
            Rectangle rec = new Rectangle(Location, Size);
            gp.AddRectangle(rec);
            PathGradientBrush pb = new PathGradientBrush(gp);
            pb.CenterColor = GameSetting.SquareCenterColor;
            pb.SurroundColors = new Color[] { GameSetting.SquareBackColor };
            g.FillPath(pb, gp);
        }
    }
}
