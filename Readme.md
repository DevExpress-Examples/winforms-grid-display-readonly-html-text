<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128619517/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3167)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Data Grid - Display read-only HTML text in data cells

This example creates a [HypertextLabel](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel) editor and assigns it to the **Html** column to display an HTML formatted text (data editing is not supported). The `HypertextLabel` control was first introduced in v17.2.

![](https://raw.githubusercontent.com/DevExpress-Examples/how-to-display-a-readonly-html-formatted-text-in-grid-cells-e3167/17.2.3%2B/media/winforms-grid-html-formatting.png)

```csharp
private void OnFormLoad(object sender, EventArgs e) {
    DataTable dt = CreateData();
    gridControl1.DataSource = dt;
    RepositoryItemHypertextLabel edit = new RepositoryItemHypertextLabel();
    gridControl1.RepositoryItems.Add(edit);
    gridView1.Columns["Html"].ColumnEdit = edit;
}
private static DataTable CreateData() {
    DataTable dt = new DataTable();
    dt.Columns.Add("Html");
    dt.Columns.Add("String");
    dt.Rows.Add("<size=14>Size = 14<br>" +
                "<b>Bold</b> <i>Italic</i> <u>Underline</u><br>" +
                "<size=11>Size = 11<br>" +
                "<color=255, 0, 0>Sample Text</color></size>", "String a");
    dt.Rows.Add("<size=15>Size = 15<br>" +
                "<b>Bold</b> <i>Italic</i> <u>Underline</u><br>" +
                "<size=10>Size = 10<br>" +
                "<color=255, 255, 0>Sample Text</color></size>", "String b");
    dt.Rows.Add("<size=18>Size = 18<br>" +
                "<b>Bold</b> <i>Italic</i> <u>Underline</u><br>" +
                "<size=8>Size = 8<br>" +
                "<color=255, 0, 255>Sample Text</color></size>", "String c");
    return dt;
}
```

> **Note**
> 
> You can also use the [Rich Text Editor](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit) to display RTF data in grid cells. This is a complex and "heavy" control. Use the [HypertextLabel](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel) lightweight control if you do not need to edit cell values. This editor supports word wrapping and row auto height features (its `HtmlLabelViewInfo` class implements `IHeightAdaptable`).


## Files to Review

* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))


## Documentation

* [HTML-inspired Text Formatting](https://docs.devexpress.com/WindowsForms/4874/common-features/html-text-formatting)
