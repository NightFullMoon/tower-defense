using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{

    [HideInInspector]
    public GameObject turretGo;
    //保存当前Cube身上的炮台

    public GameObject buildEffect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildTurret(GameObject turret)
    {
        turretGo = GameObject.Instantiate(turret, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);

    }
}
