using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text text;
    public GameObject resume, quit, pause;
 
    private void Start()
    {
        Time.timeScale = 0;//пауза, щоб гра не починалась
    }

    public void StartGame()//старт/вимкнути паузу
    {
        Time.timeScale = 1;
        resume.SetActive(false);
        quit.SetActive(false);
        pause.SetActive(true);
    }

    public void Pause()//пауза
    {
        Time.timeScale = 0;
        text.text = "Resume Game";
        resume.SetActive(true);
        quit.SetActive(true);
        pause.SetActive(false);
    }

    public void Restart()//перезагрузка сцени
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()//вихід з гри
    {
        Application.Quit();
    }
}
