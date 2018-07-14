using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStone : MonoBehaviour {

    public int _row = 0;
    public int _col = 0;

    public float offsetX = 0;
    public float offsetY = 0;

    public GameObject[] gemStoneBgs;
    public int gemStoneType;

    private GameObject gemStoneBg;

    public GameController gameConller;

    public SpriteRenderer spriteRender;

    public bool isSelected
    {
        set
        {
            if (value)
            {
                spriteRender.color = Color.red;
            }
            else
            {
                spriteRender.color = Color.white;
            }
        }
    }

    // Use this for initialization
    void Start () {
        gameConller = GameObject.Find("GameController").GetComponent<GameController>();
        spriteRender = gemStoneBg.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdatePosition(int row, int col)
    {
        this._row = row;
        this._col = col;

        this.transform.position = new Vector3(col + offsetX, row + offsetY, 0);
    }

    public void RandomCreateGemStoneBg()
    {
        if (gemStoneBg == null)
        {
            gemStoneType = Random.Range(0, gemStoneBgs.Length);
            gemStoneBg = Instantiate(gemStoneBgs[gemStoneType]) as GameObject;
            gemStoneBg.transform.parent = this.transform;
        }
    }

    public void Dispose()
    {
        Destroy(gemStoneBg.gameObject);
        Destroy(this.gameObject);
        gameConller = null;
    }

    public void TweenToPosition(int row, int col)
    {
        this._row = row;
        this._col = col;
        iTween.MoveTo(this.gameObject, iTween.Hash("x", _col +offsetX, "y", _row+offsetY, "time", 0.3f));

    }

    public void OnMouseDown()
    {
        gameConller.Select(this);
    }
}
