using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1F;
    }

    public void SetGameSpeed(int playerDistance)
    {
        switch (playerDistance)
        {
            case 25:
                Time.timeScale = 1.1F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                break;
            case 50:
                Time.timeScale = 1.2F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                break;
            case 75:
                Time.timeScale = 1.3F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                break;
            case 100:
                Time.timeScale = 1.4F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                break;
            case 200:
                Time.timeScale = 1.6F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                break;
            case 300:
                Time.timeScale = 1.8F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                break;
        }
    }
}
