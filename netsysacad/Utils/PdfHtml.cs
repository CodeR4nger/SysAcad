using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharpCore;

namespace netsysacad.Utils;

public static class PdfHtml
{
    public static byte[] ConvertHtmlToPdf(string html)
    {
        var document = new PdfDocument();
        PdfGenerator.AddPdfPages(document, html, PageSize.A4);
        using var stream = new MemoryStream();
        document.Save(stream, false);
        return stream.ToArray();
    }
}
