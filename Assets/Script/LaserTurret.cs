using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : Turret
{
    public float damageRate = 60;

    public LineRenderer laserRenderer;


    protected override void OnAttactk(GameObject enemy)
    {
        laserRenderer.enabled = true;
        //Debug.Log("LaserTurret Attactk");

        laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemy.transform.position });
    }

    protected override void OnNoEnemy()
    {
        laserRenderer.enabled = false;
    }
}
