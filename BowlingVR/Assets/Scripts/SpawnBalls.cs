using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public List<Transform> posBalls = new List<Transform>();
    public List<Material> materials = new List<Material>();
    public GameObject ball;
    private int a;
    public void Start()
    {
        SpawnBallsRandom();
    }

    public void SpawnBallsRandom()
    {
        for (int i = 0; i < posBalls.Count; i++)
        {
            a = Random.Range(0, 2);
            if (a == 1)
            {
                GameObject spawn = Instantiate(ball, posBalls[i].position, new Quaternion(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180), 0));
                spawn.tag = "Ball";
                spawn.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Count)];
                spawn.transform.localScale = new Vector3(0.0113f, 0.0113f, 0.0113f);
            }
        }
    }
}
