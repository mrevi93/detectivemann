using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject ScriptTarget;
    private bool Collected;

    private void Awake()
    {
        GameObject.Find("ScriptObject").GetComponent<ScriptObjectScript>().CoinsNeededToWin += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && !Collected)
        {
            Collected = true;
            ScriptTarget = GameObject.Find("ScriptObject");
            ScriptTarget.GetComponent<ScriptObjectScript>().Coins += 1;
            GameObject.Find("CoinText").GetComponent<TextMesh>().text = "x" + ScriptTarget.GetComponent<ScriptObjectScript>().Coins;
            this.transform.position = new Vector3(0, -30, 0);
            Destroy(this.gameObject, 0.5f);
        }
    }

}
