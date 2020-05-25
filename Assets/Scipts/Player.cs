using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpforce = 2f;
    public Rigidbody2D rb;
    public string currentColor;

    public SpriteRenderer sr;

    public Color cyan;
    public Color Yellow;
    public Color Magenta;
    public Color Pink;

    private void Start()
    {
        SetRandomColor();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.tag != currentColor)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch(index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = cyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = Yellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = Magenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = Pink;
                break;
        }
    }

}
