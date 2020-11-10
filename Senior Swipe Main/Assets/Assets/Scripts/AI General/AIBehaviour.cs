using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIController))]
public abstract class AIBehaviour : MonoBehaviour
{
    public enum Priority { Default, Low, Medium, High, OverrideAll, Custom}
    public Priority priority;

    [HideInInspector]public int priorityValue;

    public int PriorityValue() => priorityValue;


    [SerializeField] private string behaviourName;

    public string BehaviourName() => behaviourName;

    private float timeStamp;

    public float TimeStamp() => timeStamp;

    private AIController aIController;

    abstract public void Awake();

    abstract public void Behaviour();

    abstract public void CheckBehaviourConditions();

    [ContextMenu("Add")]
    public void AddToAIController()
    {
        aIController.AddBehaviours(this);
        timeStamp = Time.time;
    }

    [ContextMenu("Remove")]
    public void RemoveFromAIController()
    {
        aIController.RemoveBehavior(this);
    }

    public void GetAIController()
    {
        aIController = GetComponent<AIController>();
    }

}
