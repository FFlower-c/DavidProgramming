using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewordObject : MonoBehaviour
{
    public Material[] Materials;
    public Rigidbody2D Rigidbody2D;
    
    public enum RewordObject
    {
        RedObject,BlueOject,GreenObject,YellowObject,PurpleOject
    };

    public RewordObject objects;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Set();
    }

    // Update is called once per frame
    void Update()
    {
        Destory();

        switch (objects)
        {
            
            case RewordObject.BlueOject:
                gameObject.GetComponent<SpriteRenderer>().material = Materials[3];
                break;
            case RewordObject.RedObject:
                gameObject.GetComponent<SpriteRenderer>().material = Materials[1];
                break;
            case RewordObject.GreenObject:
                gameObject.GetComponent<SpriteRenderer>().material = Materials[2];
                break;
            case RewordObject.YellowObject:
                gameObject.GetComponent<SpriteRenderer>().material = Materials[4];
                break;
            case RewordObject.PurpleOject:
                gameObject.GetComponent<SpriteRenderer>().material = Materials[0];
                break;

        }
    }

    public void JumpOut(Vector2 dir,float force)
    {
        Rigidbody2D.AddForce(dir * force);
    }
    void SwitchState(RewordObject type)
    {
        objects = type;
    }
    public void Set()
    {
        int randomInt = Random.Range(1, 5);
        switch (randomInt)
        {
            case 1:
                SwitchState(RewordObject.RedObject);
                break;
            case 2:
                SwitchState(RewordObject.BlueOject);
                break;
            case 3:
                SwitchState(RewordObject.GreenObject);
                break;
            case 4:
                SwitchState(RewordObject.YellowObject);
                break;
            case 5:
                SwitchState(RewordObject.PurpleOject);
                break;

        }
    }

   public void Destory()
    {
      Destroy(gameObject,3.0f);
       
    }
}
