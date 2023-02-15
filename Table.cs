using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Задание_08._03
{
    public class Table
    {
        static Random Random = new Random();
        public int Width;
        public int Height;
        public int Angle = 0;
        Point LeftBottom;

        public Table(Point leftBottom)
        {
            const int MaxSquare = 6;
            LeftBottom = leftBottom;
            Height = Random.Next(2, 4);
            Width = MaxSquare / Height;
        }
        public Point GetLeftBottom()
        {
            return LeftBottom;
        }
        public Point GetRightBottom()
        {
            Point point = new Point();
            point.X = (int)Math.Round(LeftBottom.X + Width * Math.Cos(Angle * Math.PI / 180));
            point.Y = (int)Math.Round(LeftBottom.Y + Width * Math.Sin(Angle * Math.PI / 180));
            return point;
        }
        public Point GetTopLeft()
        {
            Point point = new Point();
            point.X = (int)Math.Round(LeftBottom.X - Height * Math.Sin(Angle * Math.PI / 180));
            point.Y = (int)Math.Round(LeftBottom.Y + Height * Math.Cos(Angle * Math.PI / 180));
            return point;
        }
        public Point GetTopRight()
        {
            Point point = new Point();
            point.X = (int)Math.Round(LeftBottom.X + Width * Math.Cos(Angle * Math.PI / 180) - Height * Math.Sin(Angle * Math.PI / 180));
            point.Y = (int)Math.Round(LeftBottom.Y + Width * Math.Sin(Angle * Math.PI / 180) + Height * Math.Cos(Angle * Math.PI / 180));
            return point;
        }
        public void TurnLeft()
        {
            Angle += 90;
            if (Angle >= 360)
            {
                Angle -= 360;
            }
        }
        public void TurnRight()
        {
            Angle -= 90;
            if (Angle <= -360)
            {
                Angle += 360;
            }
        }
        public void MoveLeft(int offset)
        {
            LeftBottom.X -= offset;
        }
    }
    public static class ListTables
    {
        public static List<Table> Tables = new List<Table>();
        static Random Random = new Random();
        const int MaxTableCount = 20;
        const int MinTableCount = 3;
        const int Xoffset = 6;
        private static int leftBottomX = 0;

        static ListTables()
        {
            int tableCount = Random.Next(MinTableCount, MaxTableCount + 1);
            for (int i = 0; i < tableCount; i++)
            {
                Tables.Add(new Table(new Point(leftBottomX, 0)));
                leftBottomX += Xoffset;
            }
        }

        static public void AddTable()
        {
            Tables.Add(new Table(new Point(leftBottomX, 0)));
            leftBottomX += Xoffset;
        }
        static public void RemoveTable(int tableNumber)
        {
            Tables.RemoveAt(tableNumber);
            for (int i = tableNumber; i < Tables.Count; i++)
            {
                Tables[i].MoveLeft(Xoffset);
            }
            leftBottomX -= Xoffset;
        }
        static public void TurnLeftAllTable()
        {
            foreach (Table table in Tables)
            {
                table.TurnLeft();
            }
        }
        static public void TurnRightAllTable()
        {
            foreach (Table table in Tables)
            {
                table.TurnRight();
            }
        }
    }
}
