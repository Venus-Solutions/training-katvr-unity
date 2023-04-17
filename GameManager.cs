using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject winMessage;
    private PlayerController playerController;
    private AudioSource audioSource;
    public AudioClip winSound;

    public InputActionProperty gripAction;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1){
            Time.timeScale = 0;
            pauseUI.SetActive(true);
        }

        if(playerController.itemCount == 0 && !winMessage.activeInHierarchy){
            audioSource.PlayOneShot(winSound);
            Time.timeScale = 0;
            winMessage.SetActive(true);
        }

        if(winMessage.activeInHierarchy && gripAction.action.triggered){
        // if(winMessage.activeInHierarchy && Input.GetKeyDown(KeyCode.R)){
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void continueGame(){
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void quitGame(){
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
