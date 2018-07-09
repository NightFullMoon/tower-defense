using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{
    public float damageRate = 60;

    public LineRenderer laserRenderer;

    public GameObject laseEffect;


    protected override void OnAttactk(GameObject enemy)
    {
        laserRenderer.enabled = true;
        //Debug.Log("LaserTurret Attactk");

        laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemy.transform.position });

        enemy.GetComponent<enemy>().TakeDamage(damageRate * Time.deltaTime);
        laseEffect.SetActive(true);
        Vector3 pos = transform.position;
        pos.y = enemy.transform.position.y;
        laseEffect.transform.LookAt(pos);
        laseEffect.transform.position = enemy.transform.position;
    }

    protected override void OnNoEnemy()
    {
        laserRenderer.enabled = false;
        laseEffect.SetActive(false);
    }
}
