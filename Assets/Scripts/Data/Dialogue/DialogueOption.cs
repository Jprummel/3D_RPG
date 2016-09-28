using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
    public class DialogueOption
    {
        //The options of what the player can say

        public string text;
        public int destinationNodeID;

        //Parameterless constructor for serialization

        public DialogueOption() { }

        public DialogueOption(string textvalue, int dest)
        {
            this.text = textvalue;
            this.destinationNodeID = dest;
        }

    }
}