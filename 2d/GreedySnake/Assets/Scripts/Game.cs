using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {


    public Snake snake;
    public FoodSpawner foodSpawner;
    public Text title;
    public Text pressAnykey;

    // Use this for initialization
    void Start () {
        snake.onLose += OnLose;
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyUp(KeyCode.Space))
        {
            snake.gameObject.SetActive(true);
            foodSpawner.gameObject.SetActive(true);
            title.enabled = false;
            pressAnykey.enabled = false;
        }

	}
    

    void OnLose()
    {
        title.enabled = true;
        title.text = "You lose";
        Time.timeScale = 0;
    }
}
