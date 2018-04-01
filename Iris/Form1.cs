using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iris
{
    public partial class Iris : Form
    {
        private int WidthNumber = GameSetting.WidthNumber;
        private int HeightNumber = GameSetting.HeightNumber;
        private int TinyNumber = 6;
        private Block currentBlock; //当前在运行的方块
        private Block nextBlock;   //下一个即将出现的方块
        private Point startLocation = new Point((GameSetting.WidthNumber / 2 - 2) * GameSetting.SquareSize, 0 * GameSetting.SquareSize);  //方块产生的位置
        public Iris()
        {
            InitializeComponent();
            picBackGround.BackColor = GameSetting.GameBackColor;
            this.picBackGround.Width = GameSetting.SquareSize * WidthNumber;
            this.picBackGround.Height = GameSetting.SquareSize * HeightNumber;
            this.picNextPreview.BackColor = GameSetting.GameBackColor;
            this.picNextPreview.Width = GameSetting.SquareSize * TinyNumber;
            this.picNextPreview.Height = GameSetting.SquareSize * TinyNumber;
            picBackGround.Paint += picBackGround_Paint;
            picNextPreview.Paint += picNextPreview_Paint;
            this.KeyDown += Iris_KeyDown;
            BeginGame();
        }

        private void BeginGame()
        {
            timer.Interval = 600;
            timer.Start();
        }

        private void Iris_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentBlock == null) 
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.Right: currentBlock.Right(); break;//向右移动
                case Keys.Left: currentBlock.Left(); break; //向左移动
                case Keys.Up: break; //旋转
                case Keys.Down: currentBlock.Down(); break; //向下加速
            }
            picBackGround.Focus();
        }

        private void picBackGround_Paint(object sender, PaintEventArgs e)
        {
            for (int m = 0; m < WidthNumber; m++)
            {
                for (int n = 0; n < HeightNumber; n++)
                {
                    Point p = new Point(m * GameSetting.SquareSize, n * GameSetting.SquareSize);
                    Size size = new Size(GameSetting.SquareSize, GameSetting.SquareSize);
                    Square squre = new Square(size, GameSetting.SquareCenterColor, GameSetting.SquareBackColor, p);
                    squre.Draw(e.Graphics);
                    GameSetting.SquareList[m, n] = squre;
                }
            }
        }

        private void picNextPreview_Paint(object sender, PaintEventArgs e)
        {
            for (int m = 0; m < TinyNumber; m++)
            {
                for (int n = 0; n < TinyNumber; n++)
                {
                    Point p = new Point(m * GameSetting.SquareSize, n * GameSetting.SquareSize);
                    Size size = new Size(GameSetting.SquareSize, GameSetting.SquareSize);
                    Square squre = new Square(size, GameSetting.SquareCenterColor, GameSetting.SquareBackColor, p);
                    squre.Draw(e.Graphics);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (currentBlock == null)
            {
                currentBlock = new Block(Graphics.FromHwnd(picBackGround.Handle), startLocation, Block.BlockTypes.Random);
                nextBlock = new Block(Graphics.FromHwnd(picNextPreview.Handle), new Point(GameSetting.SquareSize, GameSetting.SquareSize), Block.BlockTypes.Random);
                picNextPreview.Refresh();
                nextBlock.Draw();
            }
            if (!currentBlock.Down())
            {
                currentBlock = new Block(Graphics.FromHwnd(picBackGround.Handle), startLocation, nextBlock.BlockType);
                nextBlock = new Block(Graphics.FromHwnd(picNextPreview.Handle), new Point(GameSetting.SquareSize, GameSetting.SquareSize), Block.BlockTypes.Random);
                picNextPreview.Refresh();
                nextBlock.Draw();
            }
        }
    }
}
