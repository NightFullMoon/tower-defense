using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class enemy : MonoBehaviour
{

    public float speed = 10;
    private Transform[] positions;
    private int index = 0;

    public float MaxHP = 150;
    private float hp = 150;
    public GameObject explosionEffect;

    public Slider HPSlider;

    // Use this for initialization
    void Start()
    {
        positions = Waypoints.positions;
        hp = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (positions.Length <= index)
        {
            ReachDestination();
            return;
        }

        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);

        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)
        {
            ++index;
        }

        //if(index) 
    }

    //到达终点
    void ReachDestination() {
        GameObject.Destroy(this.gameObject);
        GameManager.Instance.Failded();
        Debug.Log("到达终点");
    }

    private void OnDestroy()
    {
        enemySpawner.EnemyAliveCont--;
    }

    public void TakeDamage(float damage) {
        if (hp <= 0) {
            return;
        }

        hp -= damage;

        HPSlider.value = (float)hp / MaxHP;
        if (hp <= 0) {
            Die();
        }
    }

    void Die() {
      
        if (explosionEffect) {
            //Debug.Log("播放销毁动画");
            GameObject effect =  GameObject.Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1.5f);
        }

        Destroy(gameObject);

    }
}
