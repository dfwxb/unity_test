using UnityEngine;
using System.Collections;

public class GemStone : MonoBehaviour {

    public int row;
    public int col;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdatePosition(int row, int col) {
        this.row = row;
        this.col = col;

        this.transform.position = new Vector3(row, col, 0);
    }
}
