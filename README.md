# B 

## Example of estimating PI using dotnet core 3.1 and Visual Studio 2019 preview

##How to use##

Clone the project to your C:\

###It will create C:\B\EstimatePI\EstimatePI
   Dotnet core 3.1 dll use to generate random x and y and calculate distance
   if distance is less than 1 than point is within the circle
   
###It will create C:\B\EstimatePI\EstimatePI.Tests
   Dotnet core 3.1 testing using xunit... not done yet
   
###It will create C:\B\EstimatePI\EstimatePIConsole
   Dotnet core 3.1 console application to estimate PI
   This app can run up to 100 C:\B\EstimatePI\EstimatePIPartConsole at the same time
   Running this app using
     EstimatePIConsole 100000000 100
     arg[0] = 100000000 === Number of Darts to throw in total
     arg[1] = 100 === Number of process/app (EstimatePIPartConsole) to use
     This app with the EstimatePIPartConsole actually creates the required number of temp file of type C:\EstimatePI\EstimatedPI_1.csv
     where the 1, 2, 3, 4 is actually use to distinguish all the temp files
     At the end the app reads all these temp file to gather all the partial results and combine/add them 
     into a new file called C:\EstimatePI\EstimatedPIResults.csv while deleting all the temp file not used anymore
   
###It will create C:\B\EstimatePI\EstimatePIPartConsole
   Dotnet core 3.1 console application to estimate PI
   Running this app using 
      EstimatePIPartConsole 123456789 1000000 1
      arg[0] = 123456789 === SecurityCode
      arg[1] = 1000000 === Number of Darts to throw
      arg[2] = 1 === Use to create the temp file with partial results
      would run the EstimatePI function with 1000000 darts and will created a temp file called C:\EstimatePI\EstimatedPI_1.csv
      the first arg is just in case one would want to have a SecurityCode to run the app
      
###It will create C:\B\EstimatePI\EstimatePIWindow
   Dotnet core 3.1 windows application to estimate PI
   Running this app will show some parameters you can set as well as a button "Start Estimating PI"
   Clicking on the "Start Estimating PI" will automatically run C:\B\EstimatePI\EstimatePIConsole\bin\Debug\netcoreapp3.1\EstimatePIConsole.exe with WindowStyle Hidden and NoCreateWindow set
   
