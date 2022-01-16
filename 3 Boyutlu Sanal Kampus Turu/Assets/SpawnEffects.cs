using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffects : MonoBehaviour
{
    [SerializeField]private GameObject Triggerpf;
    Vector3 pos = new Vector3(0, 2, 0);
    private GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        pos = player.transform.position;

        SpawnObjects(); 

    }
    void SpawnObjects()
    {
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                pos.x = i * 30 + 15;
                pos.z = j * 30 + 15;
                Instantiate(Triggerpf,pos,Quaternion.identity,this.transform);
            }
        }
    }
}
