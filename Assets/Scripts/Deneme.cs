using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deneme : MonoBehaviour
{
    public IsDead isDead;
    public SpriteRenderer charSprite;
    public Animator charAnim;
    public Rigidbody2D rigidBody;
    public AudioSource sesler;
    public AudioClip zýplama;
    public AudioClip skil0;
    public AudioClip scoreAudio;

    public float moveSpeed;
    public float jumpForce;
    public bool isPlaying;
    public bool isOnGround;
    public float skillRate = 2f;
    private float nextSkillTime;

    private void Awake()
    {
        GameManager.score = 0;
        Cursor.visible = false;
    }

    private void Update()
    {
        isPlaying = charAnim.GetBool("isWalkingAndPlaying");
        charAnim.SetBool("isWalking", false);
        charAnim.SetBool("isWalkingAndPlaying", false);

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            charSprite.flipX = false;
            charAnim.SetBool("isWalking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            charSprite.flipX = true;
            charAnim.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.W) && isOnGround == true)
        {
            jump();
        }
        if (Input.GetKey(KeyCode.Q) && isOnGround == true)
        {
            DoubleJump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ground Check
        if (collision.gameObject.tag.Equals("Platform"))
        {
            isOnGround = true;
            charAnim.SetBool("isJumping", false);
            charAnim.SetBool("isJumpingAndPlaying", false);
        }
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            Cursor.visible = true;
            isDead.isDead = true;
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.tag.Equals("Window"))
        {
            Cursor.visible = true;
            isDead.isDead = true;
            SceneManager.LoadScene("GameOver");
        }
    }

    private void DoubleJump()
    {
        charAnim.SetBool("isJumpingAndPlaying", true);
        float temp = jumpForce * 1.25f;
        rigidBody.AddForce(Vector2.up * temp, ForceMode2D.Impulse);
        isOnGround = false;
        sesler.PlayOneShot(skil0);
    }

    private void jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isOnGround = false;
        charAnim.SetBool("isJumping", true);
        sesler.PlayOneShot(zýplama);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            GameManager.score++;
            sesler.PlayOneShot(scoreAudio);
        }
        if (collision.gameObject.tag == "Window")
        {
            GameManager.score++;
            sesler.PlayOneShot(scoreAudio);
        }
    }
}