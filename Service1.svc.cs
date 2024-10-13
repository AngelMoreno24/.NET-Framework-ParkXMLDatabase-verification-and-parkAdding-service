using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace addPark
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string AddPark(string type, string Owner, string Name, string address, string Url, string NeighboringStates, string Establishedn, string Founder)
        {
            //create info to store lines of the read text
            string info = "";

            //Creates list to store info
            List<string> read = new List<string>();
            List<string> addedPark = new List<string>();

            //WebClient client = new WebClient();
            //string asd = client.DownloadString("https://www.public.asu.edu/~agmoren8/Parks.xml");
            //StreamReader reader = new StreamReader("https://www.public.asu.edu/~agmoren8/Parks.xml");

            //reads the xml file from the asu web page
            StreamReader reader = new StreamReader(WebRequest.Create("https://www.public.asu.edu/~agmoren8/Parks.xml").GetResponse().GetResponseStream());

            //reads a few lines to get past the first <Parks> line
            info = reader.ReadLine();
            read.Add(info);
            info = reader.ReadLine();
            read.Add(info);
            info = reader.ReadLine();
            read.Add(info);


            //read the file and stop reading once reaching the </Parks>
            while (info[0] != '<' && info[1] != '/' && info[2] != 'P')
            {
                //reads each line and stores it as a string
                info = reader.ReadLine();
                if (info[0] != '<' && info[1] != '/' && info[2] != 'P')
                    read.Add(info);
            }



            //add park type to list
            read.Add("\t<Park type=\"" + type + "\">");
            addedPark.Add("\t<Park type=\"" + type + "\">");

            //add Owner to list
            read.Add("\t\t<Owner>" + Owner + "</Owner>");
            addedPark.Add("\t\t<Owner>" + Owner + "</Owner>");

            //add Name to list
            read.Add("\t\t<Name>" + Name + "</Name>");
            addedPark.Add("\t\t<Name>" + Name + "</Name>");

            //add Reservation to list
            read.Add("\t\t<Reservation>");
            addedPark.Add("\t\t<Reservation>");

            //add Address to list
            read.Add("\t\t\t<Address>" + address + "</Address>");
            addedPark.Add("\t\t\t<Address>" + address + "</Address>");

            //add Url to list
            read.Add("\t\t\t<Url>" + Url + "</Url>");
            addedPark.Add("\t\t\t<Url>" + Url + "</Url>");

            //add Reservation to list
            read.Add("\t\t</Reservation>");
            addedPark.Add("\t\t</Reservation>");

            //create a list to store each state after parsing them
            List<string> states = new List<string>();

            //create variable to be used to pars NeighboringStates string
            string st = "";
            string temp = "";

            //Pars the NeighboringStates string to seperate each state
            for (int i = 0; i < NeighboringStates.Length; i++)
            {
                //add all but last state to list
                if (NeighboringStates[i] == ',')
                {
                    states.Add(temp);
                    st += temp;
                    temp = "";
                    i++;
                }

                //read the string char by char
                temp += NeighboringStates[i];

                //add final state to list
                if (i == NeighboringStates.Length - 1)
                {
                    states.Add(temp);
                    st += temp;
                    temp = "";
                }
            }

            //add all NeighboringStates elements to xml
            foreach (var state in states)
            {
                read.Add("\t\t<NeighboringStates>" + state + "</NeighboringStates>");
                addedPark.Add("\t\t<NeighboringStates>" + state + "</NeighboringStates>");
            }



            //add Establishn and founder if not empty
            if (Founder == "")
            {
                read.Add("\t\t<Establishedn>" + Establishedn + "</Establishedn>");
                addedPark.Add("\t\t<Establishedn>" + Establishedn + "</Establishedn>");
            }
            else
            {
                read.Add("\t\t<Establishedn Founder=\"" + Founder + "\">" + Establishedn + "</Establishedn>");
                addedPark.Add("\t\t<Establishedn Founder=\"" + Founder + "\">" + Establishedn + "</Establishedn>");
            }

            //add Park endline to list
            read.Add("\t</Park>");
            addedPark.Add("\t</Park>");

            //add Parks to list for file end
            read.Add("</Parks>");





            //Add all information to file
            string directoryPath = HttpContext.Current.Server.MapPath("~/App_Data/Parks.xml");

            //empty file before adding xml info
            System.IO.File.WriteAllText(directoryPath, string.Empty);
            StreamWriter writer = File.AppendText(directoryPath);

            //add xml data to file
            foreach (var line in read)
            {
                writer.WriteLine(line);
            }


            writer.Close();

            //create the output string
            string output = "";

            //adds new park xml to output
            foreach (var line in addedPark)
            {
                output += line + "\n";
            }

            //return ouput
            return string.Format(output.ToString());


        }
    }
}
