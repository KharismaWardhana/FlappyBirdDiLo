using System.Collections;
using UnityEngine;


public class PipeSpawner : MonoBehaviour
{
    //Global variables
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp,pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] public float holeSize = 1f; 
    [SerializeField] private float maxMinOffset = 1;
    [SerializeField] private Point point;



    private Coroutine CR_Spawn;
    private int playerScore = 0;

    private void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        if (CR_Spawn == null)
        {
          CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        Pipe newPipeUp   =  Instantiate(pipeUp,transform.position,Quaternion.Euler(0,0,180));
        Pipe newPipeDown =  Instantiate(pipeDown,transform.position,Quaternion.identity);
        randHoleSize();
      
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        // float y = maxMinOffset * Mathf.Sin(Time.time);
        float y = maxMinOffset * Mathf.Cos(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;
        
        newPipeUp.gameObject.SetActive(true);
        newPipeDown.gameObject.SetActive(true);

        Point newPoint = Instantiate(point, transform.position,Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;
    }
    
    public void randHoleSize()
    {
      // progress player leveling 
      // random hole size berdasarkan point player
      playerScore = bird.getScore();
      if (playerScore >= 15)
      {
        holeSize = Random.Range(holeSize, 1f);
      }
      else if (playerScore < 5)
      {
        holeSize = Random.Range(holeSize, 4f);  
      }
      else
      {
        holeSize = Random.Range(holeSize, 2f);            
      }
    }

    public void randSpawnInterval()
    {
      // progress player leveling 
      // random spawnInterval berdasarkan point player
      if (playerScore >= 15)
      {
        spawnInterval = Random.Range(spawnInterval, 1f);
      }
      else if (playerScore < 5)
      {
        spawnInterval = Random.Range(spawnInterval, 4f);  
      }
      else
      {
        spawnInterval = Random.Range(spawnInterval, 2f);            
      }
    }


    IEnumerator IeSpawn()
    {
        while (true)
        {
            if (bird.getIsDead())
            {
              StopSpawn();
            }
            
            SpawnPipe();
            randSpawnInterval();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}