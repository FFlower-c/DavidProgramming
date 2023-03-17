using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chest : MonoBehaviour
{
    public bool open;
    public GameObject objects;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (open)
            {
                GameObject obj = Instantiate(objects, transform.position, Quaternion.identity);
                rewordObject rewordObject = obj.GetComponent<rewordObject>();
                Vector2 Dir = new Vector2(Random.Range(-1, 2), 1);
                rewordObject.JumpOut(Dir, Random.Range(100,200));
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ( collision.CompareTag("Player") )
        {
            open = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            open = false;
        }
    }


}
