using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GemStone gemStone;
    public int rowNum = 7;
    public int colNum = 10;
    public ArrayList gemStoneList;

	// Use this for initialization
	void Start () {
        gemStoneList = new ArrayList();

        for (int row = 0; row < rowNum; row++) {
            ArrayList temp = new ArrayList();
            for (int col = 0; col < rowNum; row++) {
                GemStone c = Instantiate(gemStone) as GemStone;
                c.transform.parent = this.transform;
                temp.Add(c);
                c.GetComponent<GemStone>().UpdatePosition(row, col);
            }
            gemStoneList.Add(temp);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
