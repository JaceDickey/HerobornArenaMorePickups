using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Collect all 4 items to end the level!";
    public bool showWinScreen = false;
    public int maxItems = 4;
    public int _itemsCollected = 0;
    public int _playerHP = 10;

    public int Items
    {
        // 2
        get { return _itemsCollected; }

        // 3
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }
    void OnGUI()
    {
        // 4
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" +
            _playerHP);

        // 5
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " +
           _itemsCollected);

        // 6
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height -
           50, 300, 50), labelText);
        if (showWinScreen)
        {
            // 4
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
               Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
