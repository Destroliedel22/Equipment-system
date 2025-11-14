using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StaticInteractable))]
public class StaticInteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        StaticInteractable myTarget = (StaticInteractable)target;

        DrawDefaultInspector();

        //Creates the dropdown of the parameters of the selected animator
        var parameters = myTarget.animator.parameters;

        if(parameters.Length > 0 )
        {
            string[] parameterNames = new string[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                parameterNames[i] = parameters[i].name;
            }

            //Makes the dropdown
            int selectedIndex = EditorGUILayout.Popup("Select Animator Parameter", 0, parameterNames);

            myTarget.selectedParameter = parameterNames[selectedIndex];
        }
    }

}
