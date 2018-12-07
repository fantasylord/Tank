using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullect : MonoBehaviour {

    public float moveSpeed = 10;
    public BullectClassEnum BullectClass;
    // Transform player = GameObject.Find("Player").transform;
    // Use this for initialization
    EnemyBullect(BullectClassEnum _BullectClassEnum=BullectClassEnum.Enemys)
    {
        BullectClass = _BullectClassEnum;
    }
   
     public enum  BullectClassEnum
    {
        Player,Player2,Enemys
    }
   
    void Start () {
        Destroy(gameObject, 6.0f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime,Space.World);

       
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        switch (collision.tag)
        {
            case "Tank":
                if (BullectClass == BullectClassEnum.Enemys)
                { collision.SendMessage("Death");
                    
                    Destroy(gameObject); }

                    break;
            case "Heart":
                collision.SendMessage("Death");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (BullectClass != BullectClassEnum.Enemys)
                { collision.SendMessage("Death"); Destroy(gameObject); }
                    break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case "Barrier":
              
                Destroy(gameObject);
                break;
            case "Bullect":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
