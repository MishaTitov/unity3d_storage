using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_coroutine : MonoBehaviour
{

    public Transform[] path;
    IEnumerator currentMoveCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        string[] messages = { "Welcome", "to", "test", "scene" };
        StartCoroutine(PrintMessages(messages, 0.5f));
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentMoveCoroutine != null)
            {
                // to stop coroutine need reference
                StopCoroutine(currentMoveCoroutine);
            }

            currentMoveCoroutine = Move(Random.onUnitSphere * 5, 8);
            // to start coroutine need reference
            StartCoroutine(currentMoveCoroutine);
        }
    }

    IEnumerator FollowPath()
    {
        foreach(Transform waypoint in path)
        {
            // pause coroutine until "Move" has finnished running
            yield return StartCoroutine(Move(waypoint.position, 8));
        }
    }

    IEnumerator Move(Vector3 dest, float speed)
    {
        while(transform.position != dest)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            // pause coroutine until next frame
            yield return null;
        }
    }

    IEnumerator PrintMessages(string[] messages, float delay)
    {
        foreach(string msg in messages)
        {
            print(msg);
            // pause coroutine for delay seconds
            yield return new WaitForSeconds(delay);
        }
    }
}
