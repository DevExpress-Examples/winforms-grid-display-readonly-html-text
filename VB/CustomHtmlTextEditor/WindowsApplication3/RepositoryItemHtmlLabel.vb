Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.Registrator
Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.Utils.Text
Imports DevExpress.XtraEditors.Drawing
Imports System.Drawing
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils

Namespace DXSample

    <UserRepositoryItem("RegisterCustomEdit")>
    Public Class RepositoryItemHtmlLabel
        Inherits RepositoryItem

        Shared Sub New()
            Call RegisterCustomEdit()
        End Sub

        Public Sub New()
        End Sub

        Public Const CustomEditName As String = "CustomEdit"

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return CustomEditName
            End Get
        End Property

        Public Shared Sub RegisterCustomEdit()
            Dim img As Image = Nothing
            Call EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(HtmlLabel), GetType(RepositoryItemHtmlLabel), GetType(HtmlLabelViewInfo), New HtmlLabelPainter(), True, img))
        End Sub

        Private allowHtmlStringField As Boolean

        <DefaultValue(False)>
        Public Property AllowHtmlString As Boolean
            Get
                Return allowHtmlStringField
            End Get

            Set(ByVal value As Boolean)
                If allowHtmlStringField <> value Then
                    allowHtmlStringField = value
                    OnPropertiesChanged()
                End If
            End Set
        End Property

        Public Overrides Sub Assign(ByVal item As RepositoryItem)
            BeginUpdate()
            Try
                MyBase.Assign(item)
                Dim source As RepositoryItemHtmlLabel = TryCast(item, RepositoryItemHtmlLabel)
                If source Is Nothing Then Return
                allowHtmlStringField = source.AllowHtmlString
            Finally
                EndUpdate()
            End Try
        End Sub

        Public Shared Function CalculateStringInfo(ByVal g As Graphics, ByVal appearance As AppearanceObject, ByVal text As String, ByVal bounds As Rectangle) As StringInfo
            Return StringPainter.Default.Calculate(g, appearance, text, bounds)
        End Function
    End Class

    Public Class HtmlLabel
        Inherits BaseEdit

        Shared Sub New()
            RepositoryItemHtmlLabel.RegisterCustomEdit()
        End Sub

        Public Sub New()
        End Sub

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return RepositoryItemHtmlLabel.CustomEditName
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Overloads ReadOnly Property Properties As RepositoryItemHtmlLabel
            Get
                Return TryCast(MyBase.Properties, RepositoryItemHtmlLabel)
            End Get
        End Property
    End Class

    Public Class HtmlLabelViewInfo
        Inherits BaseEditViewInfo
        Implements IHeightAdaptable

        Public Sub New(ByVal item As RepositoryItem)
            MyBase.New(item)
        End Sub

#Region "IHeightAdaptable Members"
        Public Function CalcHeight(ByVal cache As GraphicsCache, ByVal width As Integer) As Integer Implements IHeightAdaptable.CalcHeight
            Dim item As RepositoryItemHtmlLabel = TryCast(Me.Item, RepositoryItemHtmlLabel)
            If item.AllowHtmlString Then
                Dim stringInfo As StringInfo = RepositoryItemHtmlLabel.CalculateStringInfo(cache.Graphics, PaintAppearance, DisplayText, ContentRect)
                Return stringInfo.Bounds.Height
            End If

            CalcTextSize(cache.Graphics, True)
            Return TextSize.Height
        End Function

#End Region
        Public Overrides Property PaintAppearance As AppearanceObject
            Get
                Return MyBase.PaintAppearance
            End Get

            Set(ByVal value As AppearanceObject)
                MyBase.PaintAppearance = value
                PaintAppearance.Options.UseTextOptions = True
                PaintAppearance.TextOptions.WordWrap = WordWrap.Wrap
            End Set
        End Property
    End Class

    Public Class HtmlLabelPainter
        Inherits BaseEditPainter

        Public Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub DrawContent(ByVal info As ControlGraphicsInfoArgs)
            Dim rect As Rectangle = New Rectangle(info.ViewInfo.ContentRect.X, info.ViewInfo.ContentRect.Y, info.ViewInfo.ContentRect.Width, info.ViewInfo.ContentRect.Height)
            info.Graphics.FillRectangle(info.ViewInfo.PaintAppearance.GetBackBrush(info.Cache), rect)
            Dim viewInfo As HtmlLabelViewInfo = TryCast(info.ViewInfo, HtmlLabelViewInfo)
            Dim item As RepositoryItemHtmlLabel = TryCast(viewInfo.Item, RepositoryItemHtmlLabel)
            If item.AllowHtmlString Then
                Dim stringInfo As StringInfo = RepositoryItemHtmlLabel.CalculateStringInfo(info.Graphics, viewInfo.PaintAppearance, viewInfo.DisplayText, rect)
                StringPainter.Default.DrawString(info.Cache, stringInfo)
            Else
                info.Cache.DrawString(viewInfo.DisplayText, viewInfo.PaintAppearance.Font, viewInfo.PaintAppearance.GetForeBrush(info.Cache), viewInfo.ContentRect, viewInfo.PaintAppearance.GetStringFormat())
            End If
        End Sub
    End Class
End Namespace
