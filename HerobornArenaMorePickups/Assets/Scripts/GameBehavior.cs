using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public static int staminaText;
    public static string detected = "HIDDEN";
    public static int bullets = 10;

    void OnGUI()
    { 

        GUI.Box(new Rect(20, 20, 150, 25), "Stamina: " +
           staminaText);

        GUI.Box(new Rect(20, 50, 150, 25), "Status: " +
           detected);

        GUI.Box(new Rect(20, 80, 150, 25), "Bullets: " +
           bullets);

        if (showWinScreen)
        {
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
