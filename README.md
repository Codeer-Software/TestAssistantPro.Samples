# TestAssistantPro.Samples
It is a sample you can learn how to use TestAssistantPro.

Download form Visual Studio Marketplace  
-------------
[Test Assistant Pro](https://marketplace.visualstudio.com/items?itemName=Codeer.TestAssistantPro "Title")

How to use samples
-------------
[for WinForms](https://github.com/Codeer-Software/TestAssistantPro.Samples/tree/master/WinForms "Title")

Feature
-------------
<table>
<tr>
  <th></th>
  <th align="center">Win32</th>
  <th align="center">WinForms</th>
  <th align="center">WPF</th>
</tr>
<tr>
  <td align="center">Start Capture</td>
  <td align="center">〇</td>
  <td align="center">〇</td>
  <td align="center">〇<td>
</tr>
<tr>
  <td align="center">Create Driver</td>
  <td align="center">TODO</td>
  <td align="center">〇</td>
  <td align="center">TODO</td>
</tr>
<tr>
  <td align="center">Check Driver</td>
  <td align="center">〇</td>
  <td align="center">〇</td>
  <td align="center">〇</td>
</tr>
<tr>
  <td align="center">with Using AI...</td>
  <td colspan=3 align="center">TODO</td>
</tr>
</table>

Summary 
=============

Synergy effect of Code and Tool
-------------
Automatic test creation is software development itself. Sharpened design / implementation is essential to succeed. It does not change.
TestAssistantPro highly assisted implementation of Automatic Test recommended by Codeer.
You can use it as an extension of VisualStudio.

Generating code using the driver
-------------
The automated test code recommended by Codeer is divided between the driver layer and the scenario layer. Technical processing is left to the driver layer, keeping the scenario which becomes the test simple is simple.
With TestAssistantPro you can generate test scenario code using the driver. It uses already implemented code to generate better code.
 ![CaptureCommand.gif](https://raw.githubusercontent.com/Codeer-Software/TestAssistantPro.Samples/master/Img/CaptureCommand.gif)

Synchronized code is output neatly even in the modal dialog.
 ![ModalCaptureCommand.gif](https://raw.githubusercontent.com/Codeer-Software/TestAssistantPro.Samples/master/Img/ModalCaptureCommand.gif)

Driver generation and maintenance
-------------
Most of the drivers can be generated automatically.
 ![CreateDriverCommand.gif](https://raw.githubusercontent.com/Codeer-Software/TestAssistantPro.Samples/master/Img/CreateDriverCommand.gif)
If you want to know the contents of the generated driver, use Check Driver. When the code is selected, the corresponding control is displayed in red frame.
By using the refactoring function of VisualStudio together, people can easily maintain Driver.
 ![CheckDriverCommand.gif](https://raw.githubusercontent.com/Codeer-Software/TestAssistantPro.Samples/master/Img/CheckDriverCommand.gif)

Also supports special control.
-------------
In many cases, Windows applications use standard controls, as well as third-party and unique controls in their respective projects. Even in such a case, you can keep the test scenario simply by creating the corresponding control driver.
Also, by implementing a code generator corresponding to the control driver, it is possible to use the code generation function of TestAssistantPro even with its own control.
 ![CaptureCommand2.gif](https://raw.githubusercontent.com/Codeer-Software/TestAssistantPro.Samples/master/Img/CaptureCommand2.gif)

It is available free of charge until July 31, 2018.
=============
