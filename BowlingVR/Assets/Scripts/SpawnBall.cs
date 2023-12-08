using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Valve.VR;

public class SpawnBall : MonoBehaviour
{
    public KillBalls killBalls;
    public List<Material> materials;
    public List<Transform> transforms;

    public GameObject ball;
    public GameObject pin;
    public Transform posSpawnBall;
    private List<GameObject> kolBalls = new List<GameObject>();
    private int kolMaterials;

    public static List<int> schetOchkov = new List<int>();

    //--------------UI-----------------//

    public GameObject oneSet;
    public TextMeshProUGUI oneset_x_one;
    public TextMeshProUGUI oneset_x_two;
    public TextMeshProUGUI oneset_x_three;

    public GameObject twoSet;
    public TextMeshProUGUI twoset_x_one;
    public TextMeshProUGUI twoset_x_two;
    public TextMeshProUGUI twoset_x_three;

    public GameObject threeSet;
    public TextMeshProUGUI threeset_x_one;
    public TextMeshProUGUI threeset_x_two;
    public TextMeshProUGUI threeset_x_three;

    private List<GameObject> pinsDefault = new List<GameObject>();

    void Start()
    {
        kolMaterials = materials.Count;
        CheckKolBallsDelete();
        CheckKolBalls();
    }

    //Clear and new spawn bins
    public void SpawnBin()
    {
            for (int i = 0; i < pinsDefault.Count; i++)
            {
                Destroy(pinsDefault[i]);
            }
            pinsDefault.Clear();


            for (int i = 0; i < transforms.Count; i++)
            {
                GameObject spawnPin = Instantiate(pin, transforms[i].position, pin.transform.rotation);
                spawnPin.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                pinsDefault.Add(spawnPin);
            }
    }

    //Check coins
    public void CheckKolBallsDelete()
    {
        switch(schetOchkov.Count)
        {
            case 1:
                oneSet.SetActive(true);
                oneset_x_one.text = schetOchkov[0].ToString();
                break;
            case 2:
                oneset_x_two.text = schetOchkov[1].ToString();
                break;
            case 3:
                oneset_x_three.text = schetOchkov[2].ToString();
                break;
            case 4:
                oneSet.SetActive(false);
                twoSet.SetActive(true);
                twoset_x_one.text = schetOchkov[3].ToString();
                break;
            case 5:
                twoset_x_two.text = schetOchkov[4].ToString();
                break;
            case 6:
                twoset_x_three.text = schetOchkov[5].ToString();
                break;
            case 7:
                twoSet.SetActive(false);
                threeSet.SetActive(true);
                threeset_x_one.text = schetOchkov[6].ToString();
                break;
            case 8:
                threeset_x_two.text = schetOchkov[7].ToString();
                break;
            case 9:
                DeleteAll();
                break;
        }
    }

    private void CheckKolBalls()
    {
        for (int i = 0; i < kolBalls.Count; i++)
        {
            if (kolBalls[i] == null)
            {
                kolBalls.Remove(kolBalls[i]);
            }
        }

        if (kolBalls.Count < 5)
        {
            GameObject spawn = Instantiate(ball, posSpawnBall.transform.position, new Quaternion(0, 0, 0, 0));
            spawn.transform.localScale = new Vector3(0.0113f, 0.0113f, 0.0113f);
            kolBalls.Add(spawn);
            spawn.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Count)];
            spawn.transform.parent = gameObject.transform;
            spawn.transform.localScale = ball.transform.localScale;
            Rigidbody rb = spawn.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 100);
        }
        Invoke(nameof(CheckKolBalls), 3);
    }


    public void DeleteAll()
    {
        threeSet.SetActive(false);
        oneSet.SetActive(false);
        twoSet.SetActive(false);

        oneset_x_one.text = "";
        oneset_x_two.text = "";
        oneset_x_three.text = "";

        twoset_x_one.text = "";
        twoset_x_two.text = "";
        twoset_x_three.text = "";

        threeset_x_one.text = "";
        threeset_x_two.text = "";
        threeset_x_three.text = "";

        schetOchkov.Clear();

        killBalls.DeleteKol();
    }
}
