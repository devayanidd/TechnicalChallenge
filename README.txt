Install Visual Studio and while setup - use NUnit Framework
Include all required selenium extentions through Nuget Package Manager.

Attached "MyTheresaChallenge" has the answers for the BASICS and TEST CASE CHALLENGE 
Other Attached are the 2 scenarios of AUTOMATION TEST CHALLENGE(Test Case2 and Test Case3) 
-> LoginToMyTheresa.cs file is for TestCase2(logging as a stranger to the MyTheresa webite)
	- I've created an account through mailbox.cc and used those credentials for registering into the website(extra)
	- I've logged to the Mytheresa website.
-> PullRequests.cs file is for the TestCase3(which opens github open pull requests, creates a new file and enters information of pull 
requests into the csv file)
	- I've just coded for complete data to the csv file
	- And also in format[Name of PR,datetime,author] for the first open PR and can be created for all the records  by a for loop
-> Attached ListOfPR.csv is the output file which is created when the 'Can_Count_PullRequests' test cases is executed.


As mentioned I've included all the drivers in my code since it has to be executed in any of the browsers.

