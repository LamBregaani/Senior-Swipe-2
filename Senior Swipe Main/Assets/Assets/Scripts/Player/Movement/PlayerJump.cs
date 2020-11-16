using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float m_jumpForce;

    [SerializeField] private float m_fallMulti;

    [SerializeField] private float m_lowJumpMulti;

    [SerializeField] private Collider collider;

    [SerializeField] private LayerMask groundLayers;

    private float m_jumpMulti = 1;

    public float JumpMulti { get => m_jumpMulti; set => m_jumpMulti = value; }


    private float m_jumpDelay = 0;

    public float JumpDelay { get => m_jumpDelay; set => m_jumpDelay = value; }

    private bool wasJumping;

    private Rigidbody m_rb;


    [System.Serializable]
    public class PlayerMovementEvent : UnityEvent { }

    public PlayerMovementEvent onJump;

    public PlayerMovementEvent onLanded;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        CheckGrounded();
        if(wasJumping && IsGrounded())
        { 
            wasJumping = false;
            onLanded.Invoke();
        }
    }

    private void FixedUpdate()
    {
        
        if (m_rb.velocity.y < 0 && !IsGrounded())
        {
            m_rb.AddForce(Vector3.up * Physics.gravity.y * (m_fallMulti - 1));
        }
    }

    private void CheckGrounded()
    {

    }

    private bool IsGrounded()
    {

        Collider[] cols = Physics.OverlapBox(collider.bounds.center, collider.bounds.extents, Quaternion.identity, groundLayers);
        return cols.Length > 0;

    }

    public void OnJump()
    {
        if(IsGrounded())
        {
            StartCoroutine(Jump());
        }
    }

    public IEnumerator Jump()
    {
        
        yield return new WaitForSeconds(m_jumpDelay);
        m_rb.AddForce(Vector3.up * m_jumpForce * m_jumpMulti, ForceMode.VelocityChange);  
        onJump?.Invoke();
        yield return new WaitForSeconds(0.1f);
        wasJumping = true;
    }
}
