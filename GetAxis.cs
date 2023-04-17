using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAxis : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float jump;

    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");

        if(Input.GetKeyUp(KeyCode.Y)){
            Debug.Log("ปุ่ม Y ถูกปล่อย");
        }

    }
}









