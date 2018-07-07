using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public TurretData LaserTurretData;
    public TurretData MissileTurretData;
    public TurretData StandardTurretData;

    //表示当前选择的炮台
    private TurretData selectedTurretData;


    public Text moneyText;
    private int money = 1000;
    public Animator moneyAnimator;

    void ChangeMoney(int change = 0) {
        money += change;
        moneyText.text = "$" + money;
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            //Debug.Log(isOn);
            //Debug.Log("选中 LaserTurret");
            selectedTurretData = LaserTurretData;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            //Debug.Log("选中 MissileTurretData");
            selectedTurretData = MissileTurretData;
        }
    }

    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            //Debug.Log("选中 StandardTurretData");
            selectedTurretData = StandardTurretData;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            //炮台的建造
            //1。必须点在mapCube上
            //2.该mapCube必须是空的

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));

            if (!isCollider)
            {
                return;
            }


            // Debug.Log("检测到射线碰撞");
            //得到点击的Cube
            MapCube mapCube = hit.collider.GetComponent<MapCube>();

            if (null != mapCube.turretGo)
            {
                // TODO:升级处理
                return;
            }


            if (money < selectedTurretData.cost)
            {
                //给出钱不够的提示
                moneyAnimator.SetTrigger("flicker");
                return;
            }

            // 创建新的
            ChangeMoney(-selectedTurretData.cost);
            mapCube.BuildTurret(selectedTurretData.TurretPrefab);
            

            //mapCube.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);

        }
    }
}
