using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public AudioSource opening;
    public AudioSource gameBgm;
    public AudioSource clearBgm;
    public GameObject startPanel;
    public GameObject textPanel;

    private void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        opening.Play();
        gameBgm.Stop();
    }

    public void GameStart()
    {
        startPanel.gameObject.SetActive(false);
        textPanel.gameObject.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        opening.Stop();
        gameBgm.Play();
    }
}
