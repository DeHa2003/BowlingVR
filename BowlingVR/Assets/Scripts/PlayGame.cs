using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelExit;
    public SpawnBalls spawnBalls;
    private GameObject doroga;
    private GameObject canvas;
    public void ExitGame()
    {

        panelStart.SetActive(true);
        panelExit.SetActive(false);
        doroga.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        doroga.gameObject.transform.GetChild(0).gameObject.GetComponent<SpawnBall>().DeleteAll();
        doroga.gameObject.transform.GetChild(0).gameObject.GetComponent<SpawnBall>().enabled = false;


        GameObject[] objBalls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < objBalls.Length; i++)
        {
            Destroy(objBalls[i]);
        }

        GameObject[] objPins = GameObject.FindGameObjectsWithTag("Pin");
        for (int i = 0; i < objPins.Length; i++)
        {
            Destroy(objPins[i]);
        }

        spawnBalls.SpawnBallsRandom();

    }
    public void StartGame(GameObject dorozhka)
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        for (int i = 0; i < balls.Length; i++)
        {
            Destroy(balls[i]);
        }

        doroga = dorozhka;                              
        dorozhka.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        dorozhka.gameObject.transform.GetChild(0).gameObject.GetComponent<SpawnBall>().enabled = true;                             
        dorozhka.gameObject.transform.GetChild(0).gameObject.GetComponent<SpawnBall>().SpawnBin();
        dorozhka.gameObject.transform.GetChild(0).gameObject.GetComponent<SpawnBall>().DeleteAll();                                               
        panelExit.SetActive(true);
        panelStart.SetActive(false);
    }

    public void OnTV(GameObject canvas)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Canvas");
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(false);
        }
        canvas.SetActive(true);
    }
}
