using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    public bool vertical;
    public float changeTime = 2.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    public float range = 3.0f;
    private GameObject User;
    Animator animator;

    bool alive = true;


    private void Awake()
    {
        //User is used in reference to get the positional data of the Player
        User = GameObject.Find("Player");
    }


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }

        

        Vector2 position = rigidbody2D.position;

        if(Vector2.Distance(User.transform.position, position) <= range)
        {
            transform.position = Vector2.MoveTowards(transform.position, User.transform.position, speed * Time.deltaTime);
        }

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PC1 player = other.gameObject.GetComponent<PC1>();

        if (player != null)
        {
            player.ChangeHealth(-20);
        }
    }

    //health system for enemies needed when implementing combat
    //make a function that changes alive from True to False

}