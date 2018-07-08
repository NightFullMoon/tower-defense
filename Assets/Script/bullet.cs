using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public int damage = 50;
    public float speed = 20;

    public GameObject explosionEffectPrefab;

    private Transform target;


    public void SetTarget(Transform _target)
    {
        target = _target;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //如果目标消失，就直接播放动画并销毁
        if (null == target)
        {
            //Destroy(gameObject);
            Die();
            return;
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void Die()
    {
        if (explosionEffectPrefab)
        {
            GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(effect, 1);
        }
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        if ("Enemy" == other.tag)
        {
            other.GetComponent<enemy>().TakeDamage(damage);
            Die();
        }
    }
}
