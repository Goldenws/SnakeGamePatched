using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorizontalLine top = new HorizontalLine(0, 119, 0, '#');
            VerticalLine left = new VerticalLine(0, 29, 0, '#');
            HorizontalLine bottom = new HorizontalLine(0, 119, 29, '#');
            VerticalLine right = new VerticalLine(0, 29, 119, '#');

            VerticalLine obstacle = new VerticalLine(10, 13, 50, 'W');
            HorizontalLine obstacle2 = new HorizontalLine(2, 12, 21, 'W');
            wallList.Add(top);
            wallList.Add(left);
            wallList.Add(bottom);
            wallList.Add(right);
            wallList.Add(obstacle);
            wallList.Add(obstacle2);
            

           
        }

        public void Draw()
        {
            foreach(var wall in wallList)
            {
                wall.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
