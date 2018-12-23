using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UploadFileTest.Library.TestLink.Api
{
    public static class UpdateTestCase
    {
        public static XmlDocument CreateXmlDocument(string status)
        {
            #region root Node
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("methodCall");
            xmlDoc.AppendChild(rootNode);
            #endregion

            #region XML Node Method name
            XmlNode methodNameNode = xmlDoc.CreateElement("methodName");
            methodNameNode.InnerText = "tl.updateTestCase";
            rootNode.AppendChild(methodNameNode);
            #endregion

            #region XML Parameters
            XmlNode paramsNode = xmlDoc.CreateElement("params");

            #region Setting Number
            XmlNode paramElement = xmlDoc.CreateElement("member");
            XmlNode nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = "devKey";
            XmlNode valueAttribute = xmlDoc.CreateElement("value");
            XmlNode stringAttribute = xmlDoc.CreateElement("string");
            stringAttribute.InnerText = "e161f73815492f9ba9f7ada9a6a1b23d";
            valueAttribute.AppendChild(stringAttribute);
            paramElement.AppendChild(nameElement);
            paramElement.AppendChild(valueAttribute);
            #endregion

            #region Setting Email
            XmlNode paramElement2 = xmlDoc.CreateElement("member");
            XmlNode valueAttribute2 = xmlDoc.CreateElement("value");
            XmlNode stringAttribute2 = xmlDoc.CreateElement("string");
            stringAttribute2.InnerText = "BSI-1";
            valueAttribute2.AppendChild(stringAttribute2);
            paramElement2.AppendChild(valueAttribute2);
            #endregion

            #region Setting validation
            XmlNode paramElement3 = xmlDoc.CreateElement("param");
            XmlNode valueAttribute3 = xmlDoc.CreateElement("value");
            XmlNode stringAttribute3 = xmlDoc.CreateElement("int");
            stringAttribute3.InnerText = status;
            valueAttribute3.AppendChild(stringAttribute3);
            paramElement3.AppendChild(valueAttribute3);
            #endregion

            #region Adding Number, Email and validation to paramsNode
            paramsNode.AppendChild(paramElement);
            paramsNode.AppendChild(paramElement2);
            paramsNode.AppendChild(paramElement3);
            rootNode.AppendChild(paramsNode);
            #endregion

            #endregion

            #region Setting encoding to UTF8
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", null, null);
            xmlDeclaration.Encoding = "UTF-8";
            //xmlDec.Standalone = "yes";
            XmlElement root = xmlDoc.DocumentElement;
            xmlDoc.InsertBefore(xmlDeclaration, root);
            #endregion

            return xmlDoc;

        }
    }
}
