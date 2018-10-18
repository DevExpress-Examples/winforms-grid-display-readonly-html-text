# How to display a readonly HTML formatted text in Grid cells


<p>This example illustrates how to create a custom editor to display a readonly HTML formatted text. In standalone mode you can use the  <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsLabelControltopic"><u>LabelControl</u></a> instead. </p><p>To show the HTML formatted text in a grid you can assign the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsRepositoryRepositoryItemRichTextEdittopic"><u>RepositoryItemRichTextEdit</u></a> to an appropriate column. However, the RichEditControl is quite a complex and "heavy" control. So, if you only need to show the HTML formatted text in the grid without editing it the best way to get it done is to assign a custom  RepositoryItemHtmlLabel to a column. Note that the HtmlLabelViewInfo implements the IHeightAdaptable interface. So, this custom control supports the word wrapping feature and grid's row auto height feature will work properly.</p><p></p>


<h3>Description</h3>

<p>Starting from version 17.2, a new&nbsp;<strong>RepositoryItemHypertextLabel</strong>&nbsp;was added. This repository item should be used when it is necessary to show read-only HTML formatted text.&nbsp;</p>

<br/>


