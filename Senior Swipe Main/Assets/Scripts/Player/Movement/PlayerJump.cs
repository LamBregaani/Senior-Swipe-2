using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float m_jumpForce;

    [SerializeField] private float m_fallMulti;

    [SerializeField] private float m_lowJumpMulti;

    private bool m_canJump = true;

    private Rigidbody m_rb;

    [System.Serializable]
    public class PlayerMovementEvent : UnityEvent { }

    public PlayerMovementEvent onJump;

    public PlayerMovementEvent onLanded;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (m_rb.velocity.y < 0 && m_canJump == false)
        {
            m_rb.AddForce(Vector3.up * Physics.gravity.y * (m_fallMulti - 1));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground or Wall"))
        {
            m_canJump = true;
            onLanded?.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground or Wall"))
        {
            m_canJump = false;
        }
    }



    private bool CheckIfGrounded()
    {
        return true;
    }

    public void OnJump()
    {
        if(m_canJump)
        {
            Jump();
        }
    }

    public void Jump()
    {
        m_rb.AddForce(Vector3.up * m_jumpForce, ForceMode.VelocityChange);
        m_canJump = false;
        onJump?.Invoke();
    }
}
