# AmadeusProjectDiego
This This is the test repo for the amadeus company.

first step, create the database
CREATE Amadeus DATABASE

Second step change the database server credentials in the Startup.css

@"Server=XXX;Database=Amadeus;Trusted_Connection=True;user id=sa;password=XXXX";

update the database in the VE package manager console

Update-Database -Project main -Context AmadeusDbContext -StartupProject main -Verbose


Angular

dependency installation
npm install

Run Project:
ng serve  --open

