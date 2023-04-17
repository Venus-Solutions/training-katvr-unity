using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public float speed = 100;
    private PlayerController playerController;
    [SerializeField] int materialID;
    BoxCollider boxCollider;
    
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        transform.Rotate(Time.deltaTime * speed, Time.deltaTime * speed, 0);
        // transform.Translate(0, 0, Time.deltaTime * 1);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player" && playerController.materialID == materialID){
            boxCollider.isTrigger = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        boxCollider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            Destroy(this.gameObject);
        }
    }
}

// materialID = playerController.materialID;  // เอาค่า PlayerController.materialID มาโชว์ใน Inspector