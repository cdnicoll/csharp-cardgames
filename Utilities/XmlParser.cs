using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Utilities
{
    public class XmlParser
    {

        private XmlDocument xDoc;
        public string FileName { get; set; }

        public XmlParser(string filename)
        {
            FileName = filename;
            xDoc = new XmlDocument();
            xDoc.Load(FileName);

        }


        /// <summary>
        /// get all node values of a specific node name
        /// </summary>
        /// <param name="nodeName">name of node to fetch</param>
        public XmlNodeList getNodeValues(string nodeName)
        {
           XmlNodeList nodes = xDoc.GetElementsByTagName(nodeName);
           //List<String> node = nodes.InnerHtml;
            return nodes;
        }


    }
}
