using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AIBehaviour), true)] [ExecuteInEditMode]
public class AIBehaviourEditor : Editor
{
    override public void OnInspectorGUI()
    {

        DrawDefaultInspector();
        var behaviour = target as AIBehaviour;


        if(behaviour.priority == AIBehaviour.Priority.Default)
        {
            behaviour.priorityValue = 0;
            serializedObject.ApplyModifiedProperties();
        }
        else if (behaviour.priority == AIBehaviour.Priority.Low)
        {
            behaviour.priorityValue = 10;
        }
        else if (behaviour.priority == AIBehaviour.Priority.Medium)
        {
            behaviour.priorityValue = 50;
        }
        else if (behaviour.priority == AIBehaviour.Priority.High)
        {
            behaviour.priorityValue = 100;
        }
        else if (behaviour.priority == AIBehaviour.Priority.OverrideAll)
        {
            behaviour.priorityValue = 999999;
        }
        else if (behaviour.priority == AIBehaviour.Priority.Custom)
        {
            behaviour.priorityValue = EditorGUILayout.IntField("Priortiy Value", behaviour.priorityValue);
        }

    }
}
