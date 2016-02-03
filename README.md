# codingChallenge

Link for download the zip file: http://www.mediafire.com/download/18nuoh8cfhob8v2/Web3.zip

Implement a Claims Web-Service in C# with ASP.NET 3.5 delivered as a Web Service and a Web Application. 
This application will perform these operation:
- Create a claim and persist it to a backing store
- Read a claim from the backing store
- Find a list of claims in the backing store by date range of LossDate
- Read a specific vehicle from a specific claim [Optional]

I developed this project in Visual Studio 2013 with Visual C# and ASP.NET 3.5
Assumption for Createing a Claim:
  *Assume the user will always submit the xml file in the same format with create-claim.xml
  *Since I couldn't implement an embedded sql express and web service does not have run time memory so I couldn't save the submission claim file to the database. A potential solution is to save the submitting xml file to the local folder but it will be different depends on the machine.


To open the solution, download the files on my submission GitHub and open it in Visual Studio 2013 (may work on VS 2015)
I also attached a compressed file including all the submission on Git Hub that everyone can download from Media Fire for convenience. Then, you can run the solution by either Launch file Service.cs or ServiceUI.aspx. 
Warning: It might go into some error of "HTTP Error 403.14 - Forbidden" due to restriction of permission on the local server
This issue can be solved changing the Directory Browser Permission to True in IIS 8 on Windows machine

The project uses an array of object to represent the backing store but in the real practice, it will be a connection to the database such as SQL Server. If this project is implemented to a real SQL server, the data model will be described below.

There are four main files for the project:
- MitchellClaimType.cs: contains all the class for MitchellClaimType and its attributes
- Service.cs: implements the CRUD operation for the web service
- ServiceUI.aspx: contains the Web Application which reference the web service (aka a User-friendly UI)
- ServiceUI.aspx.cs: contains the code for implementation of the web application

Testing: 
The web service and web application are tested via Test Client and Test Cases, which are inlcuded in the submission.
However, due to some technical issues I couldn't attach the unit tests for this project.

Data Model: https://www.mediafire.com/?uog89n19yup3or6
There will be 3 tables for data model of this project: A MitchellClaim table, a Vehicle table and a Loss Info table.
- The MitchellClaim table includes all the attributes described in the .vsd file and it is the main table.
- The Vehicle table will reference to MitchellClaim table based on the Claim Number and each vehicle is identified by its License plate. A Mitchell Claim can have one-to-many vehicles involved
- The LossInfo table will also reference to MitchellClaim table by the Claim Number. A Mitchell Claim will have one-to-one Loss Info.

Test Case: https://www.mediafire.com/?okb4o53wux8rjpq
The Test case is displayed in an Excel file, which includes ID, name, Test step and Expected Result from the Web Service.

Thank you for your time and your consideration reading my work for this coding challenge!! Have a great day!
