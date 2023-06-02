using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_PD_Pacman.BL
{
    class Cell
    {
        public char Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(char value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }

        public bool IsPacmanPresent()
        {
            return Value == 'P';
        }

        public bool IsGhostPresent()
        {
            return Value == 'G';
        }
    }

    class Grid
    {
        public List<List<Cell>> Cells { get; set; }

        public Grid(int rowSize, int columnSize, string path)
        {
            Cells = new List<List<Cell>>(rowSize);
            for (int i = 0; i < rowSize; i++)
            {
                var row = new List<Cell>();
                for (int j = 0; j < columnSize; j++)
                {
                    
                }
                Cells.Add(row);
            }
        }

        public Cell GetLeftCell(Cell cell)
        {
            if (cell.X > 0)
            {
                return Cells[cell.Y][cell.X - 1];
            }
            else
            {
                return null;
            }
        }

        public Cell GetRightCell(Cell cell)
        {
            if (cell.X < Cells[cell.Y].Count - 1)
            {
                return Cells[cell.Y][cell.X + 1];
            }
            else
            {
                return null;
            }
        }

        public Cell GetUpCell(Cell cell)
        {
            if (cell.Y > 0)
            {
                return Cells[cell.Y - 1][cell.X];
            }
            else
            {
                return null;
            }
        }

        public Cell GetDownCell(Cell cell)
        {
            if (cell.Y < Cells.Count - 1)
            {
                return Cells[cell.Y + 1][cell.X];
            }
            else
            {
                return null;
            }
        }

        public Cell FindPacman()
        {
            foreach (var row in Cells)
            {
                foreach (var cell in row)
                {
                    if (cell.IsPacmanPresent())
                    {
                        return cell;
                    }
                }
            }
            return null;
        }

        public Cell FindGhost(char character)
        {
            foreach (var row in Cells)
            {
                foreach (var cell in row)
                {
                    if (cell.IsGhostPresent() && cell.Value == character)
                    {
                        return cell;
                    }
                }
            }
            return null;
        }

        public void Draw()
        {
            foreach (var row in Cells)
            {
                foreach (var cell in row)
                {
                    Console.Write(cell.Value);
                }
                Console.WriteLine();
            }
        }
    }


    /*===========================================================================*/
    class Ghost
    {
        public int X{ get; set;}
        public int Y { get; set; }
        public int Speed { get; set; }
        public Random random = new Random();

        public Ghost(int x, int y, int speed)
        {
            X = x;
            Y = y;
            Speed = speed;
        }

        public void Move()
        {
            int direction = random.Next(4);
            switch (direction)
            {
                case 0:
                    X += Speed;
                    break;
                case 1:
                    X -= Speed;
                    break;
                case 2:
                    Y += Speed;
                    break;
                case 3:
                    Y -= Speed;
                    break;
            }
        }

        public void Draw()
        {
            Console.Write("G");
        }
    }

    class Pacman
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pacman(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(char direction)
        {
            switch (direction)
            {
                case 'W':
                    Y -= 1;
                    break;
                case 'A':
                    X -= 1;
                    break;
                case 'S':
                    Y += 1;
                    break;
                case 'D':
                    X += 1;
                    break;
            }
        }
    }

}
