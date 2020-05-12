using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

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
        ConstructGraphView();
        GenerateToolBar();

    }

    private void ConstructGraphView()
    {
        _graphView = new DialogGraphView
        {
            name = "Dialogue Graph"
        };

        _graphView.StretchToParentSize();
        rootVisualElement.Add(_graphView);
    }

    private void GenerateToolBar()
    {
        var toolbar = new Toolbar();
        var nodeCreateButton = new Button(() => {
            _graphView.CreateNode("Dialogue Node");
        });
        nodeCreateButton.text = "Create node";
        toolbar.Add(nodeCreateButton);
        rootVisualElement.Add(toolbar);//Add to the window in unity

    }

    //Like destroy method
    public void OnDisable()
    {
        rootVisualElement.Remove(_graphView);
    }


}
