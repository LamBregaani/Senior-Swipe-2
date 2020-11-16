using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SwitchGadgets : MonoBehaviour
{
    [SerializeField] private float m_switchDelay;

    private int m_gadgetIndex;

    private int m_inputValue;

    private float m_scrollY;

    private bool m_canSwitch = true;

    public Player m_controls;

    private List<EquipableGadget> m_gadgets = new List<EquipableGadget>();

    private EquipableGadget m_equipedWeapon;

    [System.Serializable]
    public class GadgetChangedEvent : UnityEvent<EquipableGadget> { }

    [SerializeField] public GadgetChangedEvent onGadgetChanged;


    private void Awake()
    {
        foreach (var _gadget in GetComponentsInChildren<EquipableGadget>())
        {
            AddWeapon(_gadget);
        }


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



    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        foreach (EquipableGadget _gadget in m_gadgets)
        {
            _gadget?.gameObject.SetActive(false);
        }
        m_equipedWeapon = m_gadgets[m_gadgetIndex];
        m_equipedWeapon.gameObject.SetActive(true);
        onGadgetChanged.Invoke(m_gadgets[m_gadgetIndex]);
    }

    private void Update()
    {
        m_scrollY = m_controls.MainControls.SwitchGadgets.ReadValue<float>();
        if (m_scrollY > 0 && m_canSwitch)
        {
            StartCoroutine(SwitchDelay());
            Value(1);
            SwitchWeapon();
        }
        else if (m_scrollY < 0 && m_canSwitch)
        {
            StartCoroutine(SwitchDelay());
            Value(-1);
            SwitchWeapon();
        }
    }

    public void SwitchWeapon()
    {

            m_gadgetIndex += m_inputValue;

            m_gadgetIndex %= m_gadgets.Count;
            if (m_gadgetIndex < 0)
            {
                m_gadgetIndex = m_gadgets.Count - 1;
            }
            m_equipedWeapon.gameObject.SetActive(false);

            m_equipedWeapon = m_gadgets[m_gadgetIndex];
            m_equipedWeapon.gameObject.SetActive(true);
            onGadgetChanged.Invoke(m_gadgets[m_gadgetIndex]);
        

    }

    private IEnumerator SwitchDelay()
    {
        m_canSwitch = false;
        yield return new WaitForSeconds(m_switchDelay);
        m_canSwitch = true;
    }

    public void AddWeapon(EquipableGadget _gadget)
    {
        m_gadgets.Add(_gadget);
    }

    public void Value(int _value)
    {
        m_inputValue = _value;
    }
}
