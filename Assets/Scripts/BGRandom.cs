using UnityEngine;

public class BGRandom : MonoBehaviour {
  [SerializeField] private Sprite BGDay;
  [SerializeField] private Sprite BGNight;
  [SerializeField] private Bird bird;

  private int playTime = 0;
  private SpriteRenderer[] BGround;

  private void Start() 
  {
    if (BGround == null)
    {
      BGround = GetComponentsInChildren<SpriteRenderer>();
    }
  }

  private void Update () 
  {
    playTime = bird.getScore() % 6;
    if(playTime == 0)
    {
        changeBGNight();
    }
    else
    {
        changeBGDay();
    }
  }

  void changeBGNight ()
  {
    for(int i = 0; i < BGround.Length; i ++)
    {
      BGround[i].sprite = BGNight;
    }
  }

  void changeBGDay ()
  {
    for(int i = 0; i < BGround.Length; i ++)
    {
      BGround[i].sprite = BGDay;
    }
  }
  
}