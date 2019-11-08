using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Point : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    void Update()
    {
        if (!bird.getIsDead())
        {
          transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetSize(float size)
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider != null)
        {
            collider.size = new Vector2(collider.size.x, size);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird && !bird.getIsDead())
        {
            bird.AddScore(1);
            if(bird.getScore() % 5 == 0)
            {
              randPowerUps();
            }
        }
    }

    
    public void randPowerUps()
    {
      StartCoroutine(IncSpeed());
    }

    IEnumerator IncSpeed()
    {
      bird.activeSpeed(true);
      yield return new WaitForSeconds(60);

      bird.activeSpeed(false);
      yield return null;
    }
}