using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;
    public Text countText;
    public Text livesText;
    public Text winText;
    private int count;
    private int lives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lives = 3;
        count = 0;
        SetlivesText();
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);

            lives = lives - 1;

            count = count + 0;

            SetlivesText();
        }
        if (count == 6)
        {
            transform.position = new Vector2(50.0f, 0.0f);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 18)
        {
            Destroy(this);
            winText.text = "You win! Game created by Meaghan Archer!";
        }
    }
    void SetlivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            Destroy(this);
            winText.text = "You Lose!";
        }
    }
}
