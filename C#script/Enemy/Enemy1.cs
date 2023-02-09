using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Enemy1 : EnemyParents
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI enemyPos1;
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
        if (EnemyHealth<=0)
        {
            text.text = "Red Enemy killed";
            text.color = Color.red;
        }
        
    }
    public override void DamageTake(int damage)
    {
        base.DamageTake(damage);
    }

    public override void Move()
    {
        Vector3 vector3 = transform.position;
        base.Move();
        enemyPos1.text = "Enemy Position:" + vector3;
    }
}
