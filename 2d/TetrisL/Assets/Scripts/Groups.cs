using UnityEngine;
using System.Collections;

public class Groups : MonoBehaviour {

    float lastFall;

	// Use this for initialization
	void Start () {
	    
        if (!isValidGroupPos())
        {
            Debug.Log("GAMEOVER");

            GameObject.Find("Canvas").GetComponent<GUIManager>().showGameOver();

            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (isValidGroupPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (isValidGroupPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            if (isValidGroupPos())
            {
                updateGrid();
            }
            else
            {
                transform.Rotate(0, 0, 90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)
            || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGroupPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                // 消除
                Grid.deleteFullRows();

                FindObjectOfType<Spawner>().spawnNext();
                enabled = false;
            }

            lastFall = Time.time;
        }
    }

    bool isValidGroupPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            // 判断是否在边界之类内
            if (!Grid.insideBorder(v))
            {
                return false;
            }

            // 现在的grid对应的格子里是null
            if (Grid.grid[(int)v.x, (int)v.y] != null && Grid.grid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void updateGrid()
    {
        // 清空上一次数据
        for (int y = 0; y < Grid.h; y++)
        { 
            for (int x = 0; x < Grid.w; x++)
            {
                if (Grid.grid[x, y] != null
                    && Grid.grid[x, y].parent == transform)
                {
                    Grid.grid[x, y] = null;
                }
            }
        }
        

        // 更新位置信息 
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}
