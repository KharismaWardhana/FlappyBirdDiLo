using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    //Global variables
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform nextPos;

    void Start()
    {
        if (bird == null)
        {
            Debug.Log("Check Bird NULL===>>");
        }
    }

    void Update()
    {
        if (bird == null || (bird != null && !bird.getIsDead()))
        {
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void randSpeed()
    {
      speed = Random.Range(speed, 2f);
    }

    public void SetNextGround(GameObject ground)
    {
        if (ground == null)
            return;

        ground.transform.position = nextPos.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (bird != null && !bird.getIsDead())
        {
            bird.Dead();
        }
    }
}
