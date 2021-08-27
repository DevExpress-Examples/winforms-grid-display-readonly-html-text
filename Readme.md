<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128619517/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3167)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))
* [Program.cs](./CS/WindowsApplication3/Program.cs) (VB: [Program.vb](./VB/WindowsApplication3/Program.vb))
<!-- default file list end -->
# How to display a readonly HTML formatted text in Grid cells


<p>This example illustrates how to create a custom editor to display a readonly HTML formatted text in older versions on our components. In standalone mode you can use the  <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsLabelControltopic"><u>LabelControl</u></a> instead. </p><p>To show the HTML formatted text in a grid you can assign the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsRepositoryRepositoryItemRichTextEdittopic"><u>RepositoryItemRichTextEdit</u></a> to an appropriate column. However, the RichEditControl is quite a complex and "heavy" control. So, if you only need to show the HTML formatted text in the grid without editing it the best way to get it done is to assign a custom  RepositoryItemHtmlLabel to a column. Note that the HtmlLabelViewInfo implements the IHeightAdaptable interface. So, this custom control supports the word wrapping feature and grid's row auto height feature will work properly.</p><p></p>


<h3>Description</h3>

<p>Starting from version 17.2, a new&nbsp;<strong>RepositoryItemHypertextLabel</strong>&nbsp;was added. This repository item should be used when it is necessary to show read-only HTML formatted text.&nbsp;</p>

<br/>


