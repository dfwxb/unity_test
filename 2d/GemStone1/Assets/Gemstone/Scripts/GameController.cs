using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GemStone gemStone;
    public ArrayList gemStones;

    public int rowNum = 7;
    public int colNum = 10;

    public GemStone curGemStone;
    public ArrayList gemStoneMatches;


    public AudioClip matchClip;
    public AudioClip swapClip;
    public AudioClip errClip;

    public AudioSource audioSource;

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();

        gemStones = new ArrayList();

        for (int row = 0; row < rowNum; row++)
        {
            ArrayList temp = new ArrayList();
            for (int col = 0; col < colNum; col++)
            {
                GemStone c = AddGemStone(row, col);
                temp.Add(c);
            }
            gemStones.Add(temp);
        }

        if (CheckHorizontalMatches() || CheckVerticalMatches())
        {
            RemoveMaches();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public GemStone AddGemStone(int row, int col)
    {
        GemStone c = Instantiate(gemStone) as GemStone;
        c.transform.parent = this.transform;
        c.GetComponent<GemStone>().RandomCreateGemStoneBg();
        c.GetComponent<GemStone>().UpdatePosition(row, col);

        return c;
    }

    public void RemoveGemStone(GemStone c)
    {
        Debug.Log("移除");
        c.Dispose();
        audioSource.PlayOneShot(matchClip);
        for (int r=c._row+1; r<rowNum; r++)
        {
            GemStone t = GetGemStone(r, c._col);
            t._row--;
            setGemStone(t._row, t._col, t);
            //t.UpdatePosition(t._row, t._col);
            t.TweenToPosition(t._row, t._col);
        }

        GemStone newGemStone = AddGemStone(rowNum, c._col);
        newGemStone._row--;
        setGemStone(newGemStone._row, newGemStone._col, newGemStone);
        //newGemStone.UpdatePosition(newGemStone._row, newGemStone._col);
        newGemStone.TweenToPosition(newGemStone._row, newGemStone._col);
    }

    public void Select(GemStone c)
    {
        //Destroy(c.gameObject);
        if (curGemStone == null)
        {
            curGemStone = c;
            curGemStone.isSelected = true;
        }
        else
        {
            if (Mathf.Abs(curGemStone._row - c._row) + Mathf.Abs(curGemStone._col - c._col) == 1)
            {
                StartCoroutine(ExchangeAndMatches(curGemStone, c));
            }
            else
            {
                audioSource.PlayOneShot(errClip);
            }

            curGemStone.isSelected = false;
            curGemStone = null;
        }
    }

    IEnumerator ExchangeAndMatches(GemStone c1, GemStone c2)
    {
        Exchange(c1, c2);

        yield return new WaitForSeconds(0.5f);

        if (CheckHorizontalMatches() || CheckVerticalMatches())
        {
            RemoveMaches();
        }
        else
        {
            Exchange(c1, c2);
        }
    }

    public void RemoveMaches()
    {
        for (int i = 0; i < gemStoneMatches.Count; i++)
        {
            GemStone c = gemStoneMatches[i] as GemStone;
            RemoveGemStone(c);
        }
        gemStoneMatches.Clear();
        StartCoroutine(WaitForCheckMachesAgain());
    }

    IEnumerator WaitForCheckMachesAgain()
    {
        yield return new WaitForSeconds(0.5f);
        if (CheckHorizontalMatches() || CheckVerticalMatches())
        {
            RemoveMaches();
        }
    }

    public void AddMaches(GemStone c)
    {
        if (gemStoneMatches == null)
        {
            gemStoneMatches = new ArrayList();
        }

        int index = gemStoneMatches.IndexOf(c);
        if (index == -1)
        {
            gemStoneMatches.Add(c);
        }
    }

    public bool CheckHorizontalMatches()
    {
        bool isMaches = false;

        for(int r = 0; r < rowNum; r++)
        {
            for (int c = 0; c < colNum - 2; c++)
            {
                if (GetGemStone(r, c) == null || GetGemStone(r, c + 1) == null
                    || GetGemStone(r, c + 2) == null)
                {
                    continue;
                }

                if (GetGemStone(r, c).gemStoneType == GetGemStone(r, c+1).gemStoneType
                    && GetGemStone(r, c).gemStoneType == GetGemStone(r, c + 2).gemStoneType)
                {
                    Debug.Log("发现行相同的宝石");
                    AddMaches(GetGemStone(r, c));
                    AddMaches(GetGemStone(r, c+1));
                    AddMaches(GetGemStone(r, c+2));
                    isMaches = true;
                }
            }
        }

        return isMaches;
    }

    public bool CheckVerticalMatches()
    {
        bool isMaches = false;


        for (int c = 0; c < colNum; c++)
        {
            for (int r = 0; r < rowNum - 2; r++)
            {
                if (GetGemStone(r, c) == null || GetGemStone(r+1, c) == null
                    || GetGemStone(r+2, c) == null)
                {
                    continue;
                }

                if (GetGemStone(r, c).gemStoneType == GetGemStone(r+1, c).gemStoneType
                    && GetGemStone(r, c).gemStoneType == GetGemStone(r+2, c).gemStoneType)
                {
                    Debug.Log("发现列相同的宝石");
                    AddMaches(GetGemStone(r, c));
                    AddMaches(GetGemStone(r+1, c));
                    AddMaches(GetGemStone(r+2, c));
                    isMaches = true;
                }
            }
        }

        return isMaches;
    }

    // 宝石交换位置
    public void Exchange(GemStone c1, GemStone c2)
    {
        audioSource.PlayOneShot(swapClip);

        setGemStone(c1._row, c1._col, c2);
        setGemStone(c2._row, c2._col, c1);

        int tRow;
        tRow = c1._row;
        c1._row = c2._row;
        c2._row = tRow;

        int tCol;
        tCol = c1._col;
        c1._col = c2._col;
        c2._col = tCol;

        // 更新位置
        //c1.UpdatePosition(c1._row, c1._col);
        //c2.UpdatePosition(c2._row, c2._col);
        c1.TweenToPosition(c1._row, c1._col);
        c2.TweenToPosition(c2._row, c2._col);
    }

    public GemStone GetGemStone(int row, int col)
    {
        ArrayList temp = gemStones[row] as ArrayList;
        GemStone c = temp[col] as GemStone;

        return c;
    }

    public void setGemStone(int row, int col, GemStone c)
    {
        ArrayList temp = gemStones[row] as ArrayList;
        temp[col] = c;
    }
}
