using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine.UIElements;

public class DialogGraph : EditorWindow
{
    private DialogGraphView _graphView;

    [MenuItem("Graph/Dialogue Graph")]

    public static void openDialogueGraphWindow()
    {
        var window = GetWindow<DialogGraph>();
        window.titleContent =new GUIContent( "Dialogue Graph");


    }
    //Like start method
    public void OnEnable()
    {
        _graphView = new DialogGraphView
        {
            name = "Dialogue Graph"
        };

        _graphView.StretchToParentSize();
        rootVisualElement.Add(_graphView);

    }


    //Like destroy method
    public void OnDisable()
    {
        rootVisualElement.Remove(_graphView);
    }

}
