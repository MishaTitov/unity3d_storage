using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 7;
    public event System.Action OnPlayerDeath;
    float screenHalfWidthInWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float velocity = inputHorizontal * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
