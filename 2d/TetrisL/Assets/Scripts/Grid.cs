using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

    public static int w = 10;
    public static int h = 20;

    public static Transform[,] grid = new Transform[w, h];

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Vector2 roundVec2(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    public static bool insideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
    }

    public static bool isRowFull(int y)
    {
        // 如果一行中有一个nul，则返回false
        for (int x = 0; x < w; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }

        return true;
    }

    public static void deleteRow(int y)
    {
        // 删除某一行所有数据
        for (int x = 0; x < w; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static void decreaseRow(int y)
    {
        for (int x = 0; x < w; x++)
        {
            if (grid[x, y] != null)
            {
                //1. 移动该行的数据到下一行
                grid[x, y - 1] = grid[x, y];
                //2. 清空该行
                grid[x, y] = null;
                //2. 改变原来的方块的位置
                grid[x, y-1].position += new Vector3(0, -1, 0);
            }
        }
    }


    public static void decreaseRowAbove(int y)
    {
        // 从指定的行开始，把上面的数据乡下移动
        for (int i = y; i < h; i++)
        {
            decreaseRow(i);
        }
    }

    public static void deleteFullRows()
    {
        // 删除某一行所有数据
        for (int y = 0; y < h;)
        {
            if (isRowFull(y))
            {
                deleteRow(y);
                // 上面的向下填充
                decreaseRowAbove(y + 1);
            }
            else
            {
                y++;
            }
        }
    }

}
