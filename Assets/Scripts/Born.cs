using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {

    public GameObject PlayerPrefab;
    public GameObject[] EnemyPrefab;
    public bool IsGetPlayer = false;
	// Use this for initialization
	void Start () {
        Invoke("BornTank", 1f);
        Destroy(gameObject,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   private void BornTank()
    {
        if (IsGetPlayer)
        {
        Instantiate(PlayerPrefab, transform.position, Quaternion.identity);

          }
        else
        {

            int i = Random.Range(0, 2);
            Instantiate(EnemyPrefab[i], transform.position, Quaternion.identity).GetComponent<Enemy>().Level = i+1;
        }
    }
}
