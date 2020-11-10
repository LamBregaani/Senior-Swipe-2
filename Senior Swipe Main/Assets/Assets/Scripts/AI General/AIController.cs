using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AIController : MonoBehaviour
{
    private List<AIBehaviour> aIBehaviours = new List<AIBehaviour>();

    private List<AIBehaviour> aIBehavioursSorted = new List<AIBehaviour>();

    private void Update()
    {
        if(aIBehaviours.Count > 0)
            aIBehavioursSorted[0].Behaviour();
    }

    public void AddBehaviours(AIBehaviour behaviour)
    {
        aIBehaviours.Add(behaviour);
        UpdatePriorityList();
    }

    public void RemoveBehavior(AIBehaviour behaviour)
    {
        aIBehaviours.Remove(behaviour);
        UpdatePriorityList();
    }

    private void UpdatePriorityList()
    {

        var orderedList = aIBehaviours.OrderByDescending(p => p.PriorityValue()).ThenByDescending(p => p.TimeStamp());

        aIBehavioursSorted = orderedList.ToList();

        if (aIBehaviours.Count > 0)
            aIBehavioursSorted[0].StopAllCoroutines();

    }
}
