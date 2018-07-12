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

    [HideInInspector]
    public bool isUpgraded = false;

    //已经建造在Cube上的炮塔的信息
    public TurretData BuildedTurretData;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildTurret(TurretData turretData)
    {
        isUpgraded = false;
        BuildedTurretData = turretData;
        turretGo = GameObject.Instantiate(turretData.TurretPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);

    }

    private void OnMouseEnter()
    {
        if (null != turretGo || EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void Upgrade() {
        if (isUpgraded) {
            return;
        }

        Destroy(turretGo);
        isUpgraded = true;
        turretGo = GameObject.Instantiate(BuildedTurretData.TurretUpgradedPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
    }

    public void DestoryTurret() {
        Destroy(turretGo);
        isUpgraded = false;
        turretGo = null;
        BuildedTurretData = null;
    }
}
