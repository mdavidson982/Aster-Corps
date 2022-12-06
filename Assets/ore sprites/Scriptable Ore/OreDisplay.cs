using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDisplay : MonoBehaviour
{

    public Ore ore;
    public SpriteRenderer oreImage;
    public float frequency = 1.25f;
    public float amplitude = 0.25f;
    public float moveSpeed = 2f;
    private bool trigger = false;
    private GameObject player; 
    // Start is called before the first frame update

    Vector2 posOffset =  new Vector2();
    Vector2 tempPos = new Vector2();

    private void Awake(){
        player = GameObject.Find("Player");
    }
    void Start()
    {
        oreImage.sprite = ore.artwork;
        oreImage.transform.localScale = new Vector2(2,2);
        posOffset = transform.position;
    }

    void Update(){
        if(!trigger){

        
        tempPos = posOffset;
        tempPos.y += (Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude);
        transform.position = tempPos;
        }else{
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        }
    }
    

    private void OnTriggerEnter2D(Collider2D other){
        //Debug.Log("Yes, you're in");
        trigger = true;
    }

}