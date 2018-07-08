using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

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

    private void OnMouseEnter()
    {
        if (null != turretGo || EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
