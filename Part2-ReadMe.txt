=================
== Part 2 - C# ==
=================

The goal is to make a simple color selector web app:
	+ It should work on IE11 and Chrome 46+
	+ See the Screenshots folder to see the end result
	+ Feel free to modify values in the instructions below to achieve similar or better results
	+ Feel free to add new files or modify existing ones


Your results may differ and that's ok! There is not one right answer.


== Step 1. ==
Ensure that HomePage.html is interpreted as HTML5 and that IE does not render the page in compatibility mode, but instead uses the latest rendering engine.


== Step 2. ==
Set the font of the body to Arial size 15px.


== Step 3. ==
The <section> tag containing the unordered list items such as Home, Patient Queue, etc. will be our navigation bar.
Style this <section> tag so that it's background color is rgb(0, 120, 215).


== Step 4. ==
Style the unordered list in the navigation bar so that there are no bullet points and clear any margins and padding.


== Step 5. ==
Make the unordered list items display horizontally with a 14px padding and width of 140px.
Also make the text color white and change the cursor so that the user knows this is a clickable item.


== Step 6. ==
Make the unordered nav list items' backgrounds change to rgb(0, 188, 242) when the user hovers over them.

Also make it to where one of the list items can be marked as active so we can show the user what page they are currently on.


== Step 7. ==
The next steps deal with the main content of the page found in the <div> tag at the root of the <body> tag.

Make sure this <div> tag has a width of 850px and is horizontally centered in the browser window.


== Step 8. ==
Each of the <div> tags that contain a <span> tag with a color name will become a color block.

Make each of these <div> tags flow horizontally with widths and heights of 150px each.

Each color block contains the name of the color. Make this text white, centered, and 10px away from the top edge of the color block.


== Step 9. ==
Set the background colors of each block according to their labels:
	Blue = rgb(0, 120, 215)
	Orange = rgb(216, 59, 1)
	Red = rgb(232, 17, 35)
	Purple = rgb(92, 45, 145)
	Green = rgb(16, 134, 16)


== Step 10. ==
Add some effect on the hover of these color blocks to let the user know they are clickable.
Be creative yet tasteful - imagine what you would expect if you were using this application.


== Step 11. ==
Create a javascript function in HomeScripts.js that will change the background color of <div id="selectedColor"> when one of the color blocks is clicked.