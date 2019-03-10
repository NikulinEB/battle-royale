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
            _lives = value;
            if (_lives == 0)
            {
                Death();
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
}
