<!-- default file list -->
*Files to look at*:

* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))
* [RepositoryItemHtmlLabel.cs](./CS/WindowsApplication3/RepositoryItemHtmlLabel.cs) (VB: [RepositoryItemHtmlLabel.vb](./VB/WindowsApplication3/RepositoryItemHtmlLabel.vb))
<!-- default file list end -->
# How to create a custom editor allowing you to display a readonly HTML formatted text 


<p>This example illustrates how to create a custom editor to display a readonly HTML formatted text. In standalone mode you can use the  <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsLabelControltopic"><u>LabelControl</u></a> instead. </p><p>To show the HTML formatted text in a grid you can assign the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsRepositoryRepositoryItemRichTextEdittopic"><u>RepositoryItemRichTextEdit</u></a> to an appropriate column. However, the RichEditControl is quite a complex and "heavy" control. So, if you only need to show the HTML formatted text in the grid without editing it the best way to get it done is to assign a custom  RepositoryItemHtmlLabel to a column. Note that the HtmlLabelViewInfo implements the IHeightAdaptable interface. So, this custom control supports the word wrapping feature and grid's row auto height feature will work properly.</p><p></p>

<br/>


