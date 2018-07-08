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

    public GameObject UpgradeCanvas;

    public Button UpgradeBtn;


    //private GameObject selectedTurretGo;

    //用来保存最后选中的MapCube
    private MapCube selectedMapCube;
    //private bool isBuildMenuDisplay = false;

    private Animator UIAnimator;

    private void Start()
    {
        UIAnimator = UpgradeCanvas.GetComponent<Animator>();
    }

    void ChangeMoney(int change = 0)
    {
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


                if (selectedMapCube == mapCube)
                {
                    if (UpgradeCanvas.activeInHierarchy)
                    {
                        //hideUpgradeUI();
                        StartCoroutine(hideUpgradeUI());
                    }
                    else
                    {
                        // 显示升级菜单
                        ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);

                    }
                }
                else
                {
                    ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                }

                selectedMapCube = mapCube;
                return;
            }


            if (null == selectedTurretData)
            {
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
            mapCube.BuildTurret(selectedTurretData);

            //mapCube.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 0);

        }
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisabledUpgrade = false)
    {
        StopCoroutine("hideUpgradeUI");


        UpgradeCanvas.transform.position = pos;
        UpgradeCanvas.SetActive(false);
        UpgradeCanvas.SetActive(true);
        UpgradeBtn.interactable = !isDisabledUpgrade;
        //isBuildMenuDisplay = true;

    }
    IEnumerator hideUpgradeUI()
    {
        UIAnimator.SetTrigger("hide");
        yield return new WaitForSeconds(0.8f);
        UpgradeCanvas.SetActive(false);
        //isBuildMenuDisplay = false;
    }

    //点击升级按钮的时候
    public void OnClickUpgradeBtn()
    {
        //if()
        selectedMapCube.Upgrade();
        StartCoroutine(hideUpgradeUI());
    }

    //点击销毁按钮的时候
    public void OnClickDestoryBtn()
    {
        selectedMapCube.DestoryTurret();
        StartCoroutine(hideUpgradeUI());
    }
}
