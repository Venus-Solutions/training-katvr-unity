using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    public Vector3 movement;

    private AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip colorSound;
    public AudioClip getItemSound;
    
    public int hitCount;
    public TextMeshProUGUI hitScore;
    public TextMeshProUGUI remainItem;

    public TextMeshProUGUI materialName;
    public Graphic materialColor;

    public Material[] ballMaterial;
    // Renderer rend;
    public int materialID = 0;
    public int itemCount;

    public InputActionProperty triggerAction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        // rend = GetComponent<Renderer>();
        // rend.enabled = true;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = new Vector3(x, 0.0f, z);

        // Debug.Log(triggerAction.action.triggered);

        // if(Input.GetMouseButtonDown(0) && Time.timeScale != 0){
        if(triggerAction.action.triggered && Time.timeScale != 0){

            materialID++;
            if(materialID > 4){
                materialID = 0;
            }
            // rend.sharedMaterial = ballMaterial[materialID];

            if(materialID == 1)materialName.text = "สีแดง";
            else if(materialID == 2)materialName.text = "โลหะ";
            else if(materialID == 3)materialName.text = "ก้อนหิน";
            else if(materialID == 4)materialName.text = "สีฟ้า";
            else materialName.text = "สีเหลือง";

            if(materialID == 1)materialColor.color = Color.red;
            else if(materialID == 2)materialColor.color = Color.white;
            else if(materialID == 3)materialColor.color = Color.gray;
            else if(materialID == 4)materialColor.color = Color.blue;
            else materialColor.color = Color.yellow;
            
            audioSource.PlayOneShot(colorSound);
        }

        itemCount = GameObject.FindGameObjectsWithTag("item").Length;
        remainItem.text = "เหลือไอเท็ม x " + itemCount;

        if(itemCount == 0){
            hitScore.enabled = false;
            remainItem.enabled = false;
            materialName.enabled = false;
            materialColor.enabled = false;
        }
    }

    private void FixedUpdate() {
        // rb.AddForce(movement * speed);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "wall"){
            audioSource.PlayOneShot(hitSound);
            hitCount++;
            hitScore.text = "ชนกำแพง x " + hitCount;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "item"){
            audioSource.PlayOneShot(getItemSound);
        }
    }
}



