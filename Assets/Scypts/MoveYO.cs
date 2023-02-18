using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MoveYO : MonoBehaviour
{
    //This will show up in the inspector
    [SerializeField] 
    public TextMeshProUGUI PickUpWater;
    [SerializeField] 
    public TextMeshProUGUI WinGame;
    [SerializeField] 
    public TextMeshProUGUI PickUpTreasures;
    [SerializeField] 
    MenuManagerNextLevel menu2;
    [SerializeField] 
    MenuManager menu;
    [SerializeField] 
    MenuManagerEndOfGame menuEndGame;
    
    //Text mesh PRO
    public TextMeshProUGUI 
        HealthPointsText;
    public TextMeshProUGUI 
        CountText;
    public TextMeshProUGUI 
        CountTreasureText;

    //Public vars
    public float startimeBtwatack;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int damage;
    public float moveSpeed = 3.9f;
    public Animator anim;
    public bool isGrounded = false;
    
    //Private vars
    private float movement;
    private bool isHurt = false;
    private int doubleJump;
    private bool waterIn = false;
    private float timeBtwAtack;

    //Integers
    int countTreasures;
    int countFountains;
    int countKeys;
    int count;
    int hP;

    void Start()
    {
        countFountains = 0;
        countKeys = 0;
        countTreasures = 0;
        count = 0;
        hP = 100;
        SetHealthPoints();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();//Jump
        movement = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * moveSpeed;
        if (movement > 0.01)
        {
            transform.localScale = new Vector3(0.6f, 0.5f, 1);
        }
        else if (movement < -0.01)
        {
            transform.localScale = new Vector3(-0.6f, 0.5f, 1);
        }

        anim.SetBool("run", movement != 0);
        anim.SetBool("grounded", isGrounded);
        anim.SetBool("gotHurt", isHurt);
      
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Attack();
        }
    }
    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 23.6f), ForceMode2D.Impulse);
            
            anim.SetTrigger("jump");
            isGrounded = false;
        }
    }
    private void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D Enemy in hitEnemies)
        {
            Debug.Log("You hit an enemy");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("UnderFloor"))
        {
            Destroy(gameObject);
            menu.gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Crapi"))
        {
            isHurt = true;  
            hP -= 10 ;
            SetHealthPoints();
            if(hP==0)
            {
                menu.gameObject.SetActive(true);
            }
        }
        //Collisions level one
        if (collision.gameObject.CompareTag("Fountain"))
        {
            collision.gameObject.SetActive(false);
            countFountains += 1;
            setCountTextFountains();
        }
        if(countFountains==3)
        {
            SetPickUpWaterText();
            waterIn = true;
        }
        if(collision.gameObject.CompareTag("Home")&&waterIn==true)
        {
            menu2.gameObject.SetActive(true);
        }

        //Collisions level two
        if(collision.gameObject.CompareTag("Key"))
        {
            collision.gameObject.SetActive(false);
            countKeys += 1;
            SetCountKeysText();
        }
        if(countKeys==3)
        {
            waterIn = true;
        }

        //Collisions level three
        if (collision.gameObject.CompareTag("Treasure"))
        {
            collision.gameObject.SetActive(false);
            countTreasures += 1;
            setCountTreasuresText();
        }

        if (countTreasures == 3)
        {
            SetPickUpTRSRsText();
            waterIn = true;
        }
        
        if (collision.gameObject.CompareTag("GameOver") && waterIn == true)
        {
            SetWinGame();
            menuEndGame.gameObject.SetActive(true);
        }
    }
    
    private void SetHealthPoints()
    {
        HealthPointsText.text = hP.ToString()+" HP left";
    }
    private void setCountTextFountains()
    {
        CountText.text = countFountains.ToString() + " x Fountain/s";
    }
    private void setCountTreasuresText()
    {
        CountText.text = countTreasures.ToString()+" x Treasure/s";
    }
    private void SetPickUpWaterText()  
    {
        PickUpWater.text = "Take the water home";
    }
    private void SetWinGame()
    {
        WinGame.text = "Well done ! You can return home";
    }
    private void SetCountKeysText()
    {
        CountText.text = countKeys.ToString() + " x KEYS";
    }
    private void SetPickUpTRSRsText()
    {
        PickUpTreasures.text = "";
    }
}
