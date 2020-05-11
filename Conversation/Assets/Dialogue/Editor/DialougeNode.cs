using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class DialougeNode : Node
{
    public string GUID;// unique ID that we pass for each of the nodes

    public string DialogueText;

    public bool entryPoint = false;


}
