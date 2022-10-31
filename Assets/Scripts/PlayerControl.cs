using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 movement;
    private void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement = movement * GameManager.instance.speedPlayer * Time.deltaTime;
        transform.position = transform.position + movement;
    }
}
