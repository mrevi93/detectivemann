using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunTimer : MonoBehaviour
{
    public float MaxTime;
    public float CurrentTime;

  
    void Start()
    {
        CurrentTime = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        float Ratio;
        Ratio = CurrentTime/MaxTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90 * Ratio));

        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }

        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
