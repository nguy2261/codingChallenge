using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServiceUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string filename = TextBox1.Text;
        Service mysr = new Service();
        Label9.Text = mysr.CreateRequest(filename);
    }
    protected void ReadClaim_Click(object sender, EventArgs e)
    {
        lstVehi.Items.Clear();
        string claimNum = TextBox2.Text;
        Service mysr = new Service();
        if(!mysr.loadDbs())
            return;
        int index = mysr.claimIndex(claimNum);
        if (index == -1)
        {
            claimNumlbl.Text = "Couldn't find the claim number";
            return;
        }
        MitchellClaimType RClaim = mysr.backing_store[index];
        claimNumlbl.Text = RClaim.ClaimNumber;
        FName.Text = RClaim.ClaimFirstName;
        LName.Text = RClaim.ClaimLastName;
        Status.Text = RClaim.Status.ToString();
        lossdate.Text = RClaim.LossDate.ToString();
        CauseOfLossCode.Text = RClaim.LossInfo.CauseOfLoss.ToString();
        reportDate.Text = RClaim.LossInfo.ReportedDate.ToString();
        desResult.Text = RClaim.LossInfo.LossDescription;
        aaID.Text = RClaim.AssignedAdjusterID.ToString();
        for (int i = 0; i < RClaim.Vehicles.count;i++ )
        {
            VehicleInfoType vehi = RClaim.Vehicles.VehiclesDetails[i];
            lstVehi.Items.Add("Model Year:      " + vehi.ModelYear);
            lstVehi.Items.Add("Make Description:        " + vehi.MakeDescription);
            lstVehi.Items.Add("Model Description:       " + vehi.ModelDescription);
            lstVehi.Items.Add("Engine Description:      " + vehi.EngineDescription);
            lstVehi.Items.Add("Exterior Color:      " + vehi.ExteriorColor);
            lstVehi.Items.Add("Vin:     " + vehi.Vin);
            lstVehi.Items.Add("License Plate:       " + vehi.LicPlate);
            lstVehi.Items.Add("License Plate State:     " + vehi.LicPlateState);
            lstVehi.Items.Add("License Plate Expiration Date:       " + vehi.LicPlateExpDate);
            lstVehi.Items.Add("Damage Description:      " + vehi.DamageDescription);
            lstVehi.Items.Add("Mileage:     " + vehi.Mileage);
            lstVehi.Items.Add("-----------------END----------------");
        }
    }
    protected void searchVehiClaim_Click(object sender, EventArgs e)
    {
        lstClaim.Items.Clear();
        string begin = txtBegin.Text;
        string end = txtEnd.Text;

        Service mysr = new Service();
        string result = mysr.FindClaim(begin, end);
        string[] vehiList = result.Split(';');
        for (int i = 0; i < vehiList.Length; i++)
        {
            if (vehiList[i].Trim().Length > 0)
            {
                lstClaim.Items.Add(vehiList[i]);
            }
        }
    }


    protected void VehicleSearchByClaim_Click(object sender, EventArgs e)
    {
        lstVehiClaim.Items.Clear();
        string claimNum = vehiClaim.Text;
        Service mysr = new Service();
        if(!mysr.loadDbs())
            return;
        int index = mysr.claimIndex(claimNum);
        if (index == -1)
        {
            claimNumlbl.Text = "Couldn't find the claim number";
            return;
        }
        MitchellClaimType RClaim = mysr.backing_store[index];

        for (int i = 0; i < RClaim.Vehicles.count; i++)
        {
            VehicleInfoType vehi = RClaim.Vehicles.VehiclesDetails[i];
            lstVehiClaim.Items.Add("Model Year:      " + vehi.ModelYear);
            lstVehiClaim.Items.Add("Make Description:        " + vehi.MakeDescription);
            lstVehiClaim.Items.Add("Model Description:       " + vehi.ModelDescription);
            lstVehiClaim.Items.Add("Engine Description:      " + vehi.EngineDescription);
            lstVehiClaim.Items.Add("Exterior Color:      " + vehi.ExteriorColor);
            lstVehiClaim.Items.Add("Vin:     " + vehi.Vin);
            lstVehiClaim.Items.Add("License Plate:       " + vehi.LicPlate);
            lstVehiClaim.Items.Add("License Plate State:     " + vehi.LicPlateState);
            lstVehiClaim.Items.Add("License Plate Expiration Date:       " + vehi.LicPlateExpDate);
            lstVehiClaim.Items.Add("Damage Description:      " + vehi.DamageDescription);
            lstVehiClaim.Items.Add("Mileage:     " + vehi.Mileage);
            lstVehiClaim.Items.Add("-----------------END----------------");
        }
    }
}