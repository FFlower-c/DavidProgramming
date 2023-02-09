using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Enemy2 : EnemyParents
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI enemyPos2;
    // Start is called before the first frame update
    public void Start()
    {
        waitingTIme = WaitTime;
    }

    // Update is called once per frame
    public void Update()
    {
        KillEnemy();
        Move();
    }
    public override void KillEnemy()
    {
        base.KillEnemy();
        if (EnemyHealth <= 0)
        {
            text.text = "Blue Enemy killed";
            text.color = Color.blue;
        }

    }
    public override void Move()
    {
        Vector3 vector3 = transform.position;
        base.Move();
        enemyPos2.text = "Enemy Position:" + vector3;
    }
}
