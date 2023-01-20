using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;
    float visibleHeightTreshold;


    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightTreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < visibleHeightTreshold)
        {
            Destroy(gameObject);
        }
    }
}
