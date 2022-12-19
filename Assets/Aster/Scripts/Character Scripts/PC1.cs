using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC1 : MonoBehaviour
{
    public float speed = 3.0f;
    
    //Changed maxHealth to 100
    public int maxHealth = 100;
    public float timeInvincible = 1.0f;
    //Create heathbar object, should be tied to the UI component in the top left
    //  Look at HealthBar.cs in the Health Bar Sprites file for more info on the object
    public HealthBar healthBar;

    public int health { get { return currentHealth; }}
    public int currentHealth;

    public int moneyCounter;

    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    public GameObject projectilePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal,vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        //This will be used to simulate the player getting hurt, This will trigger if you press the space bar
        //if(Input.GetKeyDown(KeyCode.Space)){
          //  ChangeHealth(-20);
        //}

        //if(Input.GetKeyDown(KeyCode.P)){
          //  ChangeHealth(20);
        //}
        if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }

    public void ChangeHealth(int amount){
        if(amount < 0)
        {
            animator.SetTrigger("Hit");
            if(isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }

}