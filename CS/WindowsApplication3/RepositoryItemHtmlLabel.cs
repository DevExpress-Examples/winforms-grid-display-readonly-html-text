using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.Utils.Text;
using DevExpress.XtraEditors.Drawing;
using System.Drawing;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;

namespace DXSample
{
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemHtmlLabel : RepositoryItem
    {

        static RepositoryItemHtmlLabel() { RegisterCustomEdit(); }

        public RepositoryItemHtmlLabel() { }

        public const string CustomEditName = "CustomEdit";

        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {
            Image img = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(HtmlLabel), typeof(RepositoryItemHtmlLabel),
              typeof(HtmlLabelViewInfo), new HtmlLabelPainter(), true, img));
        }

        private bool allowHtmlString;

        [DefaultValue(false)]
        public bool AllowHtmlString
        {
            get { return allowHtmlString; }
            set
            {
                if (allowHtmlString != value)
                {
                    allowHtmlString = value;
                    OnPropertiesChanged();
                }
            }
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemHtmlLabel source = item as RepositoryItemHtmlLabel;
                if (source == null) return;
                allowHtmlString = source.AllowHtmlString;
            }
            finally
            {
                EndUpdate();
            }
        }

        public static StringInfo CalculateStringInfo(Graphics g, AppearanceObject appearance, string text, Rectangle bounds ){
            return StringPainter.Default.Calculate(g, appearance, text, bounds);
        }
    }

    public class HtmlLabel : BaseEdit
    {

        static HtmlLabel() { RepositoryItemHtmlLabel.RegisterCustomEdit(); }

        public HtmlLabel() { }

        public override string EditorTypeName
        {
            get
            {
                return
RepositoryItemHtmlLabel.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemHtmlLabel Properties
        {
            get { return base.Properties as RepositoryItemHtmlLabel; }
        }

    }
    public class HtmlLabelViewInfo : BaseEditViewInfo, IHeightAdaptable
    {
        public HtmlLabelViewInfo(RepositoryItem item) : base(item) { }

        #region IHeightAdaptable Members

        public int CalcHeight(GraphicsCache cache, int width)
        {
            RepositoryItemHtmlLabel item = Item as RepositoryItemHtmlLabel;
            if (item.AllowHtmlString)
            {
                StringInfo stringInfo = RepositoryItemHtmlLabel.CalculateStringInfo(cache.Graphics, PaintAppearance, DisplayText, ContentRect);
                return stringInfo.Bounds.Height;
            }
            CalcTextSize(cache.Graphics, true);
            return TextSize.Height;
        }

        #endregion

        public override AppearanceObject PaintAppearance
        {
            get
            {
                return base.PaintAppearance;
            }
            set
            {
                base.PaintAppearance = value;
                PaintAppearance.Options.UseTextOptions = true;
                PaintAppearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            }
        }
    }

    public class HtmlLabelPainter : BaseEditPainter
    {
        public HtmlLabelPainter() : base() { }
        protected override void DrawContent(ControlGraphicsInfoArgs info)
        {
            Rectangle rect = new Rectangle(info.ViewInfo.ContentRect.X, info.ViewInfo.ContentRect.Y, info.ViewInfo.ContentRect.Width,
                info.ViewInfo.ContentRect.Height);
            info.Graphics.FillRectangle(info.ViewInfo.PaintAppearance.GetBackBrush(info.Cache), rect);
            HtmlLabelViewInfo viewInfo = info.ViewInfo as HtmlLabelViewInfo;
            RepositoryItemHtmlLabel item = viewInfo.Item as RepositoryItemHtmlLabel;
            if (item.AllowHtmlString)
            {
                StringInfo stringInfo = RepositoryItemHtmlLabel.CalculateStringInfo(info.Graphics, 
                    viewInfo.PaintAppearance, viewInfo.DisplayText, rect);
                StringPainter.Default.DrawString(info.Cache, stringInfo);
            }
            else
                info.Cache.DrawString(viewInfo.DisplayText, viewInfo.PaintAppearance.Font, viewInfo.PaintAppearance.GetForeBrush(info.Cache),
                    viewInfo.ContentRect, viewInfo.PaintAppearance.GetStringFormat());
        }
    }
}