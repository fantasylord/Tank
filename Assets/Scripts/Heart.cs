using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    
    //引用，获取组件
    private SpriteRenderer sr;
    public GameObject explosionPrefab;//爆炸效果
    public Sprite BrokenSprite;
    public AudioClip dieAudio;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	public void Death()
    {
        sr.sprite = BrokenSprite;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(dieAudio,transform.position);
        PlayerManager.Instance.isHeartDead = true;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
