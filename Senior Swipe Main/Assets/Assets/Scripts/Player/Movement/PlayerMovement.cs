using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour, ISlippySlimeEffect
{
    [SerializeField] private float m_playerSpeed;

    [SerializeField] private float m_startMaxSpeed;

    [SerializeField] private PhysicMaterial[] m_phyMats;

    [SerializeField] private Collider m_collider;

    private bool isMoving;

    private float m_maxSpeed;

    public void MaxSpeed(float _value)
    {
        m_maxSpeed = m_startMaxSpeed * _value;
    }

    private Vector3 m_currentSpeed;

    private Rigidbody m_rb;

    public Player m_controls;

    private Coroutine m_slippySlime;

    [System.Serializable]
    public class PlayerMovementEvent : UnityEvent { }

    public PlayerMovementEvent onStartMovement;

    public PlayerMovementEvent onStopMovement;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        MaxSpeed(1);
    }

    private void OnEnable()
    {
        if (m_controls == null)
        {
            m_controls = new Player();
        }

        m_controls.MainControls.Enable();
    }

    private void OnDisable()
    {
        m_controls.MainControls.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 _inputDirection = m_controls.MainControls.Movement.ReadValue<Vector2>();
        if (m_rb.velocity.x == 0 && m_rb.velocity.z == 0 && m_maxSpeed > m_startMaxSpeed)
            m_maxSpeed = m_startMaxSpeed * 1;
        Movement(_inputDirection);
        if (_inputDirection.x != 0 || _inputDirection.y != 0)
        {
            if(!isMoving)
            {
                isMoving = true;
                onStartMovement.Invoke();
            }

        }
        else if (_inputDirection.x == 0 || _inputDirection.y == 0 && isMoving != false)
        {
            if(isMoving)
            {
                isMoving = false;
                onStopMovement.Invoke();
            }

        }
            
    }




    private void Movement(Vector2 _inputDirection)
    {
        

        Vector3 _movement = new Vector3(_inputDirection.x, 0, _inputDirection.y);
        if (m_rb.velocity.magnitude < m_maxSpeed)
        {
            
            m_rb.AddRelativeForce(_movement * m_playerSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }



    }

    public void SlippySpeed(float _value)
    {
        if (m_slippySlime == null)
            StopAllCoroutines();
            m_slippySlime = StartCoroutine(SlippySlimeDuration(_value));
        

    }

    private IEnumerator SlippySlimeDuration(float _value)
    {
        m_collider.material = m_phyMats[1];
        m_maxSpeed = m_startMaxSpeed * _value;
        yield return new WaitForSeconds(0.1f);
        m_slippySlime = null;
        yield return new WaitForSeconds(0.05f);
        //m_maxSpeed = m_startMaxSpeed * 1;
        m_collider.material = m_phyMats[0];
    }
}
