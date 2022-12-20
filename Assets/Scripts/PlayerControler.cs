using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{

    public Text scoreText;
    public float score;
    public float speed;
    public float jumpForce;


    private GameObject spawn;
    private Rigidbody2D rigidbody2d;
    private bool isGround;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spawn = GameObject.FindWithTag("Respawn");
        transform.position = spawn.transform.position;
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreText.text = score.ToString();

    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
       // SceneManager.LoadScene(0);



        //сохран€ем координаты игрока
        Vector3 position = transform.position;

        //добавл€ем к сохранЄнным координатам ввод с клавиатуры
        position.x += Input.GetAxis("Horizontal") * speed;

        //ѕрисваеваем игроку новую позицию
        transform.position = position;

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            Jump();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {

            if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }
            animator.SetInteger("State", 1);
        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }
    private void Jump()
    { 
        rigidbody2d.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public void AddCoin(int count)
    {
        score += count;

        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    






}
