using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillBalls : MonoBehaviour
{
    public TextMeshProUGUI schet;
    public SpawnBall spawnBall;
    public int kolTrigger = 0;

    private GameObject game;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            game = other.gameObject;
            Invoke(nameof(Delete), 7);
        }
    }

    private void Delete()
    {
        kolTrigger += 1;


        SpawnBall.schetOchkov.Add(int.Parse(schet.text));
        spawnBall.CheckKolBallsDelete();


        schet.text = 0.ToString();
        if(kolTrigger == 3 || kolTrigger == 6 || kolTrigger == 9)
        {
            StartCoroutine(DeleteBins());
            if (kolTrigger == 9)
            {
                DeleteKol();
            }
        }
        Destroy(game);
    }

    IEnumerator DeleteBins()
    {
        animator.SetBool("play", true);
        yield return new WaitForSeconds(3);
        animator.SetBool("play", false);
        spawnBall.SpawnBin();

    }

    public void DeleteKol()
    {
        kolTrigger = 0;
    }
}