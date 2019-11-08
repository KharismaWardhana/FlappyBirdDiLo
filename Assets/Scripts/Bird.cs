using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    //Global Variables
    [SerializeField] private float upForce = 100f;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead, OnAddPoint;
    [SerializeField] private int score;
    [SerializeField] private Text scoreText;

    private Rigidbody2D m_rgbody2D;
    private Animator m_animator;
    public bool isImmune;
    public Image GameOver;

    // Start is called before the first frame update
    void Start ()
    {
        m_rgbody2D  = GetComponent<Rigidbody2D>();
        m_animator  = GetComponent<Animator>();
        isImmune    = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isDead && Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        
        if (isImmune)
        {
            StartCoroutine(handleImmune());
        }
    }

    IEnumerator handleImmune()
    {
        Debug.Log("Power-Ups Active Immune");
        
        m_animator.ResetTrigger("isFlapping");
        m_animator.SetTrigger("isImmune");

        yield return new WaitForSeconds(10);
        
        isImmune = false;
        m_animator.ResetTrigger("isImmune");
        m_animator.SetTrigger("isFlapping");

        yield return null;
    }

    public void activePower(bool isActive)
    {
        if (isActive)
        {
            transform.localScale = new Vector3(5f, 5f, 5f);
        }     
        else
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
        }
    }

    public void activeSpeed(bool isActive)
    {
        if (isActive)
        {
            m_rgbody2D.velocity = Vector2.right;
        }
        else
        {
            m_rgbody2D.velocity = Vector2.left;
        }
    }


    public bool getIsDead ()
    {
        return isDead;
    }

    public void Dead ()
    {
        if (isImmune)
        {
            return;
        }

        if (!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }

        isDead = true;
        scoreText.text = "Press P to play again";
        GameOver.gameObject.SetActive(true);
    }

    void Jump ()
    {
        if (m_rgbody2D == null)
            return;

        m_rgbody2D.velocity = Vector2.zero;
        m_rgbody2D.AddForce(new Vector2(0f, upForce));

        if (OnJump != null)
        {
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)    
    {
        m_animator.enabled = false;
    }

    public void AddScore (int value)
    {
        score += value;
        scoreText.text = score.ToString();
        
        if (score%5 == 0)
        {
            isImmune = true;
        }

        if (OnAddPoint != null)
        {
            OnAddPoint.Invoke();
        }
    }

    public int getScore ()
    {
        return score;
    }
}
