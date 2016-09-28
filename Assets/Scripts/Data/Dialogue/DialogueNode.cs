using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
    public class DialogueNode
    {
        public int nodeID = -1;
        public string text;
        public List<DialogueOption> options;
        //Parameterless constructor for serialization
        public DialogueNode()
        {
            options = new List<DialogueOption>();
        }

        public DialogueNode(string textValue)
        {
            text = textValue;
            options = new List<DialogueOption>();
        }
    }
}
