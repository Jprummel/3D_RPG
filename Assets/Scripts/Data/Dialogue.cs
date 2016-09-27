using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogueTree
{
    public class Dialogue
    {
        public List<DialogueNode> Nodes;

        public void AddNode(DialogueNode node)
        {
            //if the node is null, then its an ExitNode and we can skip adding it.
            if (node == null) return;

            //add the node to the dialougs list of nodes
            Nodes.Add(node);
            //Give the node an ID
            node.nodeID = Nodes.IndexOf(node);
        }

        public void AddOption(string text, DialogueNode node, DialogueNode dest)
        {
            //Add the destination node to the dialouge if its not already there
            if (!Nodes.Contains(dest))
            {
                AddNode(dest);
            }

            //Add the parent node to the dialouge if it's not already there
            if (!Nodes.Contains(node))
            {
                AddNode(node);
            }

            DialogueOption option;

            //create an option object. if the destination is an ExitNode, set the index to -1
            if (dest == null)
            {
                option = new DialogueOption(text, -1);
            }
            else
            {
                option = new DialogueOption(text, dest.nodeID);
            }

            node.options.Add(option);
        }

        public Dialogue()
        {

        }
    }
}
