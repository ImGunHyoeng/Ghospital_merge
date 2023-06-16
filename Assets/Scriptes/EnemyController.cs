using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float delta = 0f;
    public float speed = 3.0f;
    int direction = 1;
    GameObject director;
    Transform playerpos;
    public int patten;
    GameObject generator;
    public Sprite fast_monster;



    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.generator = GameObject.Find("EnemyGenerator");
        if (GameObject.FindWithTag("Player") == null)
            this.playerpos = GameObject.FindWithTag("Untouchable").gameObject.transform;
        else
            this.playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        patten = generator.GetComponent<EnemyGenerator>().patten;
        
    }

    
    void Update()
    {
        
        switch(patten)
        {
            case 1:
                delta += Time.deltaTime;
                if (transform.position.x >= 10)
                {
                    direction = -1;
                }
                if (transform.position.x <= -10)
                {
                    direction = 1;
                }
                if (delta > 2.0f)
                {
                    transform.Translate(direction * speed * Time.deltaTime, 0, 0);
                }
                break;
            case 2:
                transform.position = Vector3.MoveTowards(transform.position, this.playerpos.position, speed * Time.deltaTime);
                gameObject.GetComponent<SpriteRenderer>().sprite = fast_monster;
                break;
        }
        
        
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            
            this.director.GetComponent<GameDirector>().meetEnemy();
        }
        if(patten==2)
            if(collision.gameObject.tag=="Untouchable")
                this.director.GetComponent<GameDirector>().meetEnemy(); 
    }
}
