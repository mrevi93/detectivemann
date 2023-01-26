using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private GameObject TargetPlayer;
    [SerializeField] private float yMinimum;
    [SerializeField] private float yMaximum;

    void Update()
    {
        //Move Y Camera
        if(TargetPlayer.transform.position.y > yMinimum && TargetPlayer.transform.position.y < yMaximum)
        {
            this.transform.position = new Vector3(TargetPlayer.transform.position.x, TargetPlayer.transform.position.y, this.transform.position.z);
        }

        //Move only X Camera
        else
        {
            this.transform.position = new Vector3(TargetPlayer.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
