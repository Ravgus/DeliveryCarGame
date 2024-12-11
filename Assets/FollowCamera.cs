using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = this.thingToFollow.transform.position + new Vector3(0, 0, -12);
    }
}
