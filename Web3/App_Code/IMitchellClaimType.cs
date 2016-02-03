using System;
interface IMitchellClaimType
{
    long AssignedAdjusterID { get; set; }
    string ClaimFirstName { get; set; }
    string ClaimLastName { get; set; }
    string ClaimNumber { get; set; }
    DateTime LossDate { get; set; }
    LossInfoType LossInfo { get; set; }
    StatusCode Status { get; set; }
    VehicleListType Vehicles { get; set; }
}
