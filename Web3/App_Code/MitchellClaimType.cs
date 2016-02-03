using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

/// <summary>
/// Summary description for MitchellClaimType
/// </summary>

 [XmlRoot("MitchellClaimType")]
    public class MitchellClaimType : IMitchellClaimType
    {
        [XmlElement("ClaimNumber")]
        public string ClaimNumber { get; set; }

        [XmlElement("ClaimFirstName")]
        public string ClaimFirstName { get; set; }

        [XmlElement("ClaimLastName")]
        public string ClaimLastName { get;  set; }

        [XmlElement("Status")]
        public StatusCode Status { get;  set; }

        [XmlElement("LossDate")]
        public DateTime LossDate { get;  set; }

        [XmlElement("LossInfo")]
        public LossInfoType LossInfo { get;  set; }

        [XmlElement("AssignedAdjusterID")]
        public long AssignedAdjusterID { get;  set; }

        [XmlElement("Vehicles")]
        public VehicleListType Vehicles { get;  set; }

        public MitchellClaimType(string CN, string CFN, string CLN, StatusCode stt, DateTime LDate, LossInfoType LI, long aaID, VehicleListType vehi)
        {
            ClaimNumber = CN;
            ClaimFirstName = CFN;
            ClaimLastName = CLN;
            Status = stt;
            LossDate = LDate;
            LossInfo = LI;
            AssignedAdjusterID = aaID;
            Vehicles = vehi;
        }

        public MitchellClaimType() { }
    }

    public enum StatusCode
    {
        OPEN,
        CLOSED,
    }

    public enum CauseOfLossCode
    {
        Collision = 0,
        Explosion = 1,
        Fire = 2,
        Hail = 3,
        Mechanical_Breakdown = 4,
        Other = 5
    }

    public class LossInfoType
    {
        public CauseOfLossCode CauseOfLoss { get;  set; }
        public DateTime ReportedDate { get;  set; }
        public string LossDescription { get;  set; }

        public LossInfoType(CauseOfLossCode col, DateTime rd, string ld)
        {
            CauseOfLoss = col;
            ReportedDate = rd;
            LossDescription = ld;
        }

        public LossInfoType() { }
    }

    [XmlInclude(typeof(VehicleListType))]
    [XmlRoot("VehicleInfoType")]
    public class VehicleInfoType
    {
        [XmlElement("ModelYear")]
        public int ModelYear { get;  set; }

        [XmlElement("MakeDescription")]
        public string MakeDescription { get;  set; }

        [XmlElement("ModelDescription")]
        public string ModelDescription { get;  set; }

        [XmlElement("EngineDescription")]
        public string EngineDescription { get;  set; }

        [XmlElement("ExteriorColor")]
        public string ExteriorColor { get;  set; }

        [XmlElement("Vin")]
        public string Vin { get;  set; }

        [XmlElement("LicPlate")]
        public string LicPlate { get;  set; }

        [XmlElement("LicPlateState")]
        public string LicPlateState { get;  set; }

        [XmlElement("LicPlateExpDate")]
        public DateTime LicPlateExpDate { get;  set; }

        [XmlElement("DamageDescription")]
        public string DamageDescription { get;  set; }

        [XmlElement("Mileage")]
        public int Mileage { get;  set; }

        public VehicleInfoType(int MY, string MakeD, string ModeD, string ED, string EC, string V, string Lp, string lps, DateTime lped, string DD, int mil)
        {
            ModelYear = MY;
            MakeDescription = MakeD;
            ModelDescription = ModeD;
            EngineDescription = ED;
            ExteriorColor = EC;
            Vin = V;
            LicPlate = Lp;
            LicPlateState = lps;
            LicPlateExpDate = lped;
            DamageDescription = DD;
            Mileage = mil;
        }

        public VehicleInfoType() { }
    }

    [XmlInclude(typeof(VehicleInfoType))]
    [XmlRoot("VehicleListType")]
    public class VehicleListType
    {
        [XmlArray("Vehicles")]
        [XmlArrayItem("VehiclesDetails")]
        public VehicleInfoType[] VehiclesDetails = new VehicleInfoType[10];

        public int count = 0;
        public void add(VehicleInfoType vh)
        {
            VehiclesDetails[count] = vh;
            count++;
        }
        public VehicleListType(int num)
        {
            VehicleInfoType[] VehiclesDetails = new VehicleInfoType[num];
        }

        public VehicleListType() { }
    }