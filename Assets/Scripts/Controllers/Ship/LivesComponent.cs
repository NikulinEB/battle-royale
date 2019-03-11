using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class LivesComponent : MonoBehaviour
{
    [SerializeField]
    private int _livesCount = 3;
    private int _lives;
    public int Lives {
        get
        {
            return _lives;
        }
        private set
        {
            if (value >= 0)
            {
                _lives = value;

                if (_lives == 0)
                {
                    Death();
                }
            }
            else
            {
                _lives = 0;
            }
        }
    }
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        Lives = _livesCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Bullet"))
        {
            Lives--;
            Destroy(collision.gameObject);
        } else if (collision.tag.Equals("Player") || collision.tag.Equals("Enemy"))
        {
            collision.transform.GetComponent<LivesComponent>()?.Death();
            this.Death();
        }
    }

    private void Death()
    {
        _animator?.Play("Death");
    }

    /// <summary>
    /// Called by animation event.
    /// </summary>
    private void DestroyGameobject()
    {
        Destroy(gameObject);
    }

    public void ResetLives()
    {
        Lives = _livesCount;
    }
}
