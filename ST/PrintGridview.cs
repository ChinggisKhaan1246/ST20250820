using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System;

public class PrintGridview
{
    // GridView-ийг хэвлэх функц
    public static void Print(GridView gridView, int leftMargin, int topMargin, int bottomMargin, int rightMargin,
                             string headerLeft, string headerMiddle, string headerRight,
                             string footerLeft, string footerRight, bool landscape)
    {
        // PrintableComponentLink объект үүсгэх
        PrintableComponentLink printableLink = new PrintableComponentLink(new PrintingSystem());

        // GridControl-ийг хэвлэх компонент болгон тохируулах
        printableLink.Component = gridView.GridControl;

        // Хэвлэх цаасны хэмжээ, чиглэл тохируулах
        printableLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
        printableLink.Landscape = landscape; // Хэвлэх чиглэл

        // Margin-уудыг тохируулах
        float mmToPixelLeft = leftMargin * 96 / 25.4f;
        float mmToPixelTop = topMargin * 96 / 25.4f;
        float mmToPixelBottom = bottomMargin * 96 / 25.4f;
        float mmToPixelRight = rightMargin * 96 / 25.4f;

        printableLink.Margins.Left = (int)mmToPixelLeft;
        printableLink.Margins.Top = (int)mmToPixelTop;
        printableLink.Margins.Bottom = (int)mmToPixelBottom;
        printableLink.Margins.Right = (int)mmToPixelRight;

        // Документ үүсгэх
        printableLink.CreateDocument();

        // Header болон Footer агуулга тохируулах
        PageHeaderFooter phf = printableLink.PageHeaderFooter as PageHeaderFooter;

        // Header агуулга тохируулах
        phf.Header.Content.Clear();
        phf.Header.Content.AddRange(new string[] { headerLeft, headerMiddle, headerRight });
        phf.Header.LineAlignment = BrickAlignment.Far; // Header баруун талд байрлана

        // Footer агуулга тохируулах
        phf.Footer.Content.Clear();
        phf.Footer.Content.AddRange(new string[] { footerLeft, "[Page # of Pages #]", footerRight});
        //phf.Footer.LineAlignment = BrickAlignment.Far; // Footer баруун талд байрлана

        // Print Preview гаргах
        printableLink.Margins.Left = printableLink.Margins.Left - 10;
        printableLink.ShowPreview();
        
       
    }
}
