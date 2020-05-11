using UnityEngine;
using System.Collections;

public class Maze
{

    int width;
    int height;

    bool[,] grid;

    System.Random rg;

    int startX;
    int startY;

    public bool[,] Grid
    {
        get { return grid; }
    }

    public Maze(int width, int height, System.Random rg)
    {
        this.width = width;
        this.height = height;

        this.startX = 10;
        this.startY = 10;

        this.rg = rg;
    }

    public Maze(int width, int height, int startX, int startY, System.Random rg)
    {
        this.width = width;
        this.height = height;

        this.startX = startX;
        this.startY = startY;

        this.rg = rg;
    }

    public void Generate()
    {
        grid = new bool[width, height];

        startX = 1;
        startY = 1;

        grid[startX, startY] = true;

        MazeDigger(startX, startY);
    }

    public Vector3 GetGoalPosition()
    {
        int radius = 2;
        int endX, endY;
        int attempt = PlayerPrefs.GetInt("Attempt");
        if (attempt == -1 || attempt == 1)
        {
            endX = width;
            endY = startY;
        } else if (attempt == 2)
        {
            endX = width - 8;
            endY = height - (startY + 3);
        } else
        {
            endX = width - 2;
            endY = startY;
        }


        for (int x = endX - radius; x <= endX + radius; x++)
        {
            for (int y = endY - radius; y <= endY + radius; y++)
            {
                if (GetCell(x, y))
                {
                    return new Vector3(x, y);
                }
            }
        }

        return Vector3.one * 1000;
    }

    public bool GetCell(int x, int y)
    {
        if (x >= width || x < 0 || y >= height || y <= 0)
        {
            return false;
        }

        return grid[x, y];
    }

    void MazeDigger(int x, int y)
    {
        int[] directions = new int[] { 1, 2, 3, 4 };

        Tools.Shuffle(directions, rg);

        for (int i = 0; i < directions.Length; i++)
        {
            if (directions[i] == 1)
            {
                if (y - 2 <= 0)
                    continue;

                if (grid[x, y - 2] == false)
                {
                    grid[x, y - 2] = true;
                    grid[x, y - 1] = true;

                    MazeDigger(x, y - 2);
                }
            }

            if (directions[i] == 2)
            {
                if (x - 2 <= 0)
                    continue;

                if (grid[x - 2, y] == false)
                {
                    grid[x - 2, y] = true;
                    grid[x - 1, y] = true;

                    MazeDigger(x - 2, y);
                }
            }

            if (directions[i] == 3)
            {
                if (x + 2 >= width - 1)
                    continue;

                if (grid[x + 2, y] == false)
                {
                    grid[x + 2, y] = true;
                    grid[x + 1, y] = true;

                    MazeDigger(x + 2, y);
                }
            }

            if (directions[i] == 4)
            {
                if (y + 2 >= height - 1)
                    continue;

                if (grid[x, y + 2] == false)
                {
                    grid[x, y + 2] = true;
                    grid[x, y + 1] = true;

                    MazeDigger(x, y + 2);
                }
            }
        }
    }

}