using System.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    //Global variable
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    private void Update()
    {     
        if (!bird.getIsDead())
        {
          gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime,Space.World); 
        }
    }

    public void randSpeed()
    {
      speed = Random.Range(speed, 2f);
    }

    public float getSpeedPipe()
    {
      return speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        if (bird)
        {
            Collider2D collider = GetComponent<Collider2D>();

            if (collider)
            {
              collider.enabled = false;
            }

            bird.Dead();
        }
    }
}