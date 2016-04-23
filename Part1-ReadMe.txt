=================
== Part 1 - C# ==
=================

Use the Part1.General and Part1.General.UnitTests projects for the steps in Part 1.
Create any additional classes, interfaces, collections, enums, etc. as needed.
Organize into namespaces, folders, or even new projects if needed.


== Step 1. ==
Using the Patient.cs file, create a Patient class that can track the following attributes:
	- Medical record number (string)
	- First and last name
	- Street address including city, state, and zip code


== Step 2. ==
A patient can have one or more insurance policies. For simplicity, an insurance policy has a provider name and a policy number (string). 
Create a class to represent these policies and add a way for the Patient class to have one or more.


== Step 3. ==
Suppose we need to add validation to this Patient class. The medical record number, first and last name, and street address must contain some string value that is not empty or null. Don't worry about checking if the address is real.
In addition, the Patient class must have at least one valid insurance policy which also should be validated (non-null or empty strings).
Create the functionality needed to validate the Patient class.


== Step 4. ==
Test the functionality of your validation in the Part1.General.UnitTests project.


== Step 5. ==
Let's pretend that we need to manually handle the disposing of the Patient class.
Implement the proper cleanup methods so that when the Patient object is cleaned up by the .NET garbage collector, we have the opportunity to run custom cleanup code.
For now, just set all the properties to null in the cleanup method.


== Step 6. ==
Make the Patient class to where other developers could implement Patient and override functionality.

Make the class you created to represent insurance policies so that no other developer could subclass it.


== Step 7. ==
As of Visual Studio 2015 .NET 4.6, there are at least 3 ways to concatenate a string. On the Patient class, create 
methods GetDisplayText1(), GetDisplayText2(), and GetDisplayText3() which use each of these methods. The output
should be in the format:

	[FirstName] [LastName]

If the Patient class has at least one insurance policy, add some text to the end so the output is like this:

	[FirstName] [LastName] - [InsuranceProviderName] [InsurancePolicyNumber]


== Step 8. ==
Use the PatientRepository.cs file for this step.
Implement a Search method so that accepts an anonymous function as a parameter which will be executed to provide custom filter logic on the Data property, a private array of Patient classes.
The anonymous function should be constrained to accept a Patient object as a parameter and return a bool.


== Step 9. ==
Create unit test methods to verify the functionality of the Search method.


== Step 10. ==
Create an extension method for Patient class that will serialize the object into JSON.


== Step 11. ==
Decorate the properties and methods of the Patient class with descriptions so that the descriptions show up in Intellisense.


== Step 12. ==
Create a NuGet package from the Part1.General class library project.