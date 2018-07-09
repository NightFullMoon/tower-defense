﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
   // [HideInInspector]
    public List<GameObject> enemys = new List<GameObject>();

    //多少秒攻击一次
    public float attactRateTime = 1;

    private float timer;

    public GameObject bulletPrefab;

    public Transform firePosition;

    public Transform head;

    // Use this for initialization
    void Start()
    {
        timer = attactRateTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        if (enemys.Count < 1)
        {
            OnNoEnemy();
            return;
        }

        if (null != enemys[0])
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
        else
        {
            UpdateEnemys();
            // OnNoEnemy();
            return;
        }

        if (enemys.Count < 1)
        {
            OnNoEnemy();
            return;
        }

        if (attactRateTime < timer)
        {
            //Debug.Log("Attactk");



            Attactk();
            //timer -= attactRateTime;

        }
        else
        {
            //Debug.Log("attactRateTime" + attactRateTime);
            //Debug.Log("timer" + timer);
        }
    }
    void Attactk()
    {
        OnAttactk(enemys[0]);
    }

    protected virtual void OnAttactk(GameObject enemy)
    {
        timer = 0;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        bullet.GetComponent<bullet>().SetTarget(enemy.transform);
    }

    //每次Update，没有敌人时候的操作
    protected virtual void OnNoEnemy() { }

    private void OnTriggerEnter(Collider other)
    {

        // Debug.Log(other.tag);
        if ("Enemy" == other.tag)
        {
            enemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ("Enemy" == other.tag)
        {
            enemys.Remove(other.gameObject);
        }
    }
    //更新敌人的列表，移除所有空元素
    void UpdateEnemys()
    {
        //enemys.RemoveAll(null);

        List<GameObject> newEnemys = new List<GameObject>();

        foreach (GameObject enemy in enemys)
        {
            if (null != enemy)
            {
                newEnemys.Add(enemy);
            }
        }

        enemys = newEnemys;
    }
}
