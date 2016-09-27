using System.Collections.Generic;
using DialogueTree;
using System.Xml.Serialization;
using System.IO;
using System;

namespace DialogueTest
{
    class DialogueProgram
    {
        static void Main(string[] args)
        {
            Dialogue dia = LoadDialogue("DialogTest.xml");
        }

        static void RunDialogue(Dialogue dia)
        {
            //create a indexer, set it to 0 - the dialogues Start node.
            int nodeID = 0;

            //while the next node is not an exit node, traverse the dialogue tree based on the user
            //input
            while (nodeID != -1)
            {
                nodeID = RunNode(dia.Nodes[nodeID]);
            }
        }

        static int RunNode(DialogueNode node)
        {
            int nextNode = -1;
            
            
            return nextNode;
        }

        private static void CreateDialogue()
        {
            Dialogue dia = new Dialogue();

            //create some nodes for testing
            DialogueNode node1 = new DialogueNode("Hi there");
            DialogueNode node2 = new DialogueNode("Im a test npc");
            DialogueNode node3 = new DialogueNode("SMD");

            dia.AddNode(node1);
            dia.AddNode(node2);
            dia.AddNode(node3);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dialogue));
            StreamWriter writer = new StreamWriter("DialogueTest.xml"); //Outputs text into a file and gets the path to write to
            xmlSerializer.Serialize(writer, dia);
        }

        private static Dialogue LoadDialogue(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Dialogue));
            StreamReader reader = new StreamReader(path); //Reads text from a file

            Dialogue dia = (Dialogue)xmlSerializer.Deserialize(reader);
            return dia;
        }
    }
}