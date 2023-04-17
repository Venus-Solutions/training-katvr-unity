using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorController : MonoBehaviour
{
    public Material[] wallMaterial;
    Renderer rend;
    public TextMeshProUGUI displayText;

    private PlayerController playerController;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update() {
        if(playerController.itemCount == 0){
            displayText.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            rend.sharedMaterial = wallMaterial[0];
            displayText.text = "ชนเข้าให้!";
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.tag == "Player"){
            rend.sharedMaterial = wallMaterial[1];
            displayText.text = "เดินต่อไป...";
        }
    }
}







