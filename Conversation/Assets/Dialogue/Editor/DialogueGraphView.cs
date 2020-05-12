using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using System;

public class DialogGraphView : GraphView
{

    private readonly Vector2 defaultNodeSize = new Vector2(150, 200);

    public DialogGraphView()
    {
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);//zoom in and out
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());


        AddElement(GenerateEntryPointNode());

    }

    private Port GeneratePort(DialougeNode node, Direction portDirection, Port.Capacity capacity=Port.Capacity.Single) {

        return node.InstantiatePort(Orientation.Horizontal,portDirection,capacity,typeof(float));
    }

    private DialougeNode GenerateEntryPointNode()
    {
        var node = new DialougeNode
        {
            title = "START",
            GUID = Guid.NewGuid().ToString(),
            DialogueText = "ENTRYPOINT",
            entryPoint = true

        };

        var generatedPort = GeneratePort(node, Direction.Output);
        generatedPort.name = "Next";
        node.outputContainer.Add(generatedPort);

        node.RefreshExpandedState();
        node.RefreshPorts();


        node.SetPosition(new Rect(100,200,100,150));
        return node;
    }

    public DialougeNode CreateDialogueNode(string nodeName)
    {
        var dialogNode = new DialougeNode {
            title = nodeName,
            DialogueText = nodeName,
            GUID = Guid.NewGuid().ToString()

        };
        var inputPort = GeneratePort(dialogNode, Direction.Input, Port.Capacity.Multi);
        inputPort.name = "Input";
        dialogNode.inputContainer.Add(inputPort);

        var button = new Button(() => { AddChoicePort(dialogNode); });
        button.text = "New choice";
        dialogNode.titleContainer.Add(button);

        dialogNode.RefreshExpandedState();
        dialogNode.RefreshPorts();
        dialogNode.SetPosition(new Rect(Vector2.zero, defaultNodeSize));

        return dialogNode;
    }

    private void AddChoicePort(DialougeNode dialogNode)
    {
        var generatedPort = GeneratePort(dialogNode, Direction.Output);
        var outputPortCount = dialogNode.outputContainer.Query("connector").ToList().Count;
        generatedPort.portName = $"Choice {outputPortCount}";
        dialogNode.outputContainer.Add(generatedPort);
        dialogNode.RefreshExpandedState();
        dialogNode.RefreshPorts();
    }

    public void CreateNode(string nodeName)
    {
        AddElement(CreateDialogueNode(nodeName));
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        var compatiblePorts = new List<Port>();
        ports.ForEach((port) => {
            if(startPort != port && startPort.node != port.node)
            {
                compatiblePorts.Add(port);
            }
        });
        return compatiblePorts;
    }
}
