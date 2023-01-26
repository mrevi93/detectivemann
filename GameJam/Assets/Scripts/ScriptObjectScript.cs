using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptObjectScript : MonoBehaviour
{
    public int Coins;
    public int CoinsNeededToWin;
    public string SceneToLoad;

    private void Update()
    {
        if(Coins >= CoinsNeededToWin)
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}
