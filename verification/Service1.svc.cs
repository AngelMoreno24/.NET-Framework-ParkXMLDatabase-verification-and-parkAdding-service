using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Schema;
using System.Xml;

namespace verification
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //creates a string to store "no error" or error info
        static string output = "";
        public string Verification(string xml, string xsd)
        {

            //empty output
            output = "";

            //Create the XmlSchemaSet class
            XmlSchemaSet sc = new XmlSchemaSet();

            //Add the schema to the collection before performing validation
            sc.Add(null, xsd);

            //Define the validation settings
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            //Create the XmlReader object.
            XmlReader reader = XmlReader.Create(xml, settings);

            //Parse the file and will call event handler if invalid
            while (reader.Read()) ;
            if (output == "")
                output += "No error";

            return string.Format(output);
        }

        //Display  validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            //store error message in output
            output += "Validation Error:" + e.Message + "\n";
        }
    }
}
