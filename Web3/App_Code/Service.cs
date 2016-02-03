using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //Create an linked list of MitchellClaimType to represent the backing store database
    public MitchellClaimType[] backing_store = new MitchellClaimType[20];
    XmlDocument XmlInput = new XmlDocument();
    int claimCount = 0;
    [WebMethod]
    public string CreateRequest(String filename)
    {
        //Get the file path from the text box and try to open the file 
        XmlDocument XmlInput = new XmlDocument();
        if (!File.Exists(filename))
        {
            // dump to the log file the file was not found at the location... filename
            return "Error opening xml file";
        }
        StreamReader sr = File.OpenText(filename);
        String line = sr.ReadToEnd();
        XmlInput.LoadXml(line);
        try
        {
            loadfromXML(XmlInput); //Extract the xml file to Mitchell claim object and store to backing store
            //
        }
        catch
        {
            return "Error reading xml file";
        }
        return "Xml File is successfully uploaded and stored";
    }

    [WebMethod]
    public string ReadClaim(string claimNum)
    {
        if (loadDbs())
        {
            for (int i = 0; i < claimCount; i++)
            {
                if (backing_store[i].ClaimNumber == claimNum)
                {
                    return (returnFromXML(backing_store[i]));
                }
            }
            return "Couldn't find the claim according to the claim number";
        }
        else
            return "Could not load database";
    }

    [WebMethod]
    public string FindClaim(string strbegin, string strend)
    {
        if (loadDbs())
        {
            DateTime begin;
            DateTime end;
            if (DateTime.TryParse(strbegin, out begin) && DateTime.TryParse(strend, out end))
            {
                string result = "";
                for (int i = 0; i < claimCount; i++)
                {
                    if (backing_store[i].LossDate.CompareTo(begin) > -1 && backing_store[i].LossDate.CompareTo(end) < 1)
                    {
                        result += backing_store[i].ClaimNumber + ";";
                    }
                }

                if (result.Length > 0)
                {
                    return result;
                }
                else
                {
                    return "Error 404 Not Found";
                }
            }
            else
            {
                return "Error wrong date format";
            }
        }
        else
        {
            return "Couldn't load database";
        }
    }

    [WebMethod]
    public string FindVehicle(string claimNum)
    {
        //Load the database
        if (loadDbs())
        {
            //Search the database for according claim Number
            int claimSearch = claimIndex(claimNum);

            //Return the claim if find, else return error message
            if (claimSearch > -1)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(VehicleListType));
                StringWriter sw = new StringWriter();
                XmlTextWriter tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, backing_store[claimSearch].Vehicles);
                return sw.ToString();
            }
            else
                return String.Format("Error 404: Couldn't find vehicles involved in claim number {0}", claimNum);
        }
        else
            return "Couldn't load database";
    }


    //Helper Function - Not in web service
    public void loadfromXML(XmlDocument xdoc)
    {
        //Read the information from the xml xdoc XML Document
        //Assumption: All submitted files must be in this formatting 
            var tClaimNumber = xdoc.DocumentElement.ChildNodes[0].InnerText;
            var tClaimFirstName = xdoc.DocumentElement.ChildNodes[1].InnerText;
            var tClaimLastName = xdoc.DocumentElement.ChildNodes[2].InnerText;
            var tStatus = (StatusCode)Enum.Parse(typeof(StatusCode), xdoc.DocumentElement.ChildNodes[3].InnerText);
            var tLossDate = DateTime.Parse(xdoc.DocumentElement.ChildNodes[4].InnerText);
            var aaID = long.Parse(xdoc.DocumentElement.ChildNodes[6].InnerText);
            var li = xdoc.DocumentElement.ChildNodes[5];
            var ColCode = (CauseOfLossCode)Enum.Parse(typeof(CauseOfLossCode), li.ChildNodes[0].InnerText, false);
            var date = DateTime.Parse(li.ChildNodes[1].InnerText);
            var des = li.ChildNodes[2].InnerText;
            var tLossInfo = new LossInfoType(ColCode, date, des);
            var vehi = xdoc.DocumentElement.ChildNodes[7];

        //Reading Vehicles attributes of the claim xml file
        VehicleListType VehicleList = new VehicleListType();
            foreach (XmlNode veNode in vehi)
            {
                var ModelYear = int.Parse(veNode.ChildNodes.Item(1).InnerText);
                var MakeDescription = veNode.ChildNodes.Item(2).InnerText;
                var ModelDescription = veNode.ChildNodes.Item(3).InnerText;
                var EngineDescription = veNode.ChildNodes.Item(4).InnerText;
                var ExteriorColor = veNode.ChildNodes.Item(5).InnerText;
                var Vin = veNode.ChildNodes.Item(0).InnerText;
                var LicPlate = veNode.ChildNodes.Item(6).InnerText;
                var LicPlateState = veNode.ChildNodes.Item(7).InnerText;
                var LicPlateExpDate = DateTime.Parse(veNode.ChildNodes.Item(8).InnerText);
                var DamageDescription = veNode.ChildNodes.Item(9).InnerText;
                var Mileage = int.Parse(veNode.ChildNodes.Item(10).InnerText);
                var tVehicle = new VehicleInfoType(ModelYear, MakeDescription, ModelDescription, EngineDescription, ExteriorColor, Vin, LicPlate, LicPlateState, LicPlateExpDate, DamageDescription, Mileage);
                VehicleList.add(tVehicle);
            }
        //Create an MitchellClaimType object based on the information getting from XML file    
        MitchellClaimType addClaim = new MitchellClaimType(tClaimNumber, tClaimFirstName, tClaimLastName, tStatus, tLossDate, tLossInfo, aaID, VehicleList);
        
        //In this demo, this will add the new submitted claim into the database
        //In real program, this will fetch this object into the database - SQL Server or anything else
        backing_store[claimCount] = addClaim;
        claimCount++;
    }

    public string returnFromXML(MitchellClaimType searchClaim)
    {
        //This function will convert an MitchellClaimType object into an XML file.
        //This can be done better if I can figure out how I can indent and give space between each element from the XML
        XmlSerializer serializer = new XmlSerializer(typeof(MitchellClaimType));
        StringWriter sw = new StringWriter();
        XmlTextWriter tw = new XmlTextWriter(sw);
        serializer.Serialize(tw, searchClaim);
        return sw.ToString();
    }

    public bool loadDbs()
    {
        //Since I don't have an embedded SQL server in this project so I implement a function called loaded Database.
        //This function will read location Xml claim file and store them into an array of MitchellClaimType representing the database

        //PLEASE CHANGE the Directory of claim files representing the database store. It's different on different machine
        //The GetFiles method will read all the files in that directory
        string[] database = Directory.GetFiles("C:/Users/admin/Documents/Visual Studio 2013/WebSites/Web3/App_Data");
        for (int i = 0; i < database.Count(); i++)
        {
            string db = database[i];
            if (!File.Exists(db))
            {
                // Dump to the log file the file was not found at the location... filename
                return false;
            }
            try //Try to catch any errror 
            {
                StreamReader sr = File.OpenText(db);
                String line = sr.ReadToEnd();
                XmlInput.LoadXml(line);
                loadfromXML(XmlInput);
            } catch
            {
                return false;
            }
        }
        return true;
    }

    //This function is 
    public int claimIndex(string claimNum)
    {
        for (int i = 0; i < claimCount; i++)
        {
            if (backing_store[i].ClaimNumber == claimNum)
            {
                return i;
            }
        }
        return -1;
    }
}
 