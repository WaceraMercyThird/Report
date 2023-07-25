using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_pdf
{
    internal class PdfGenerator
    {
        public void GenerateInvoice(string filePath, Invoice invoice)
        {
            // Create a new PDF document
            var document = new PdfDocument();

            // Add a new page to the document
            var page = document.AddPage();

            // Create a graphics object for the page
            var gfx = XGraphics.FromPdfPage(page);

            // Set up the fonts
            var titleFont = new XFont("Arial", 24, XFontStyle.Bold);
            var headingFont = new XFont("Arial", 16, XFontStyle.Bold);
            var normalFont = new XFont("Arial", 12);

            // Set up the text format
            var format = new XStringFormat
            {
                Alignment = XStringAlignment.Near,
                LineAlignment = XLineAlignment.Near
            };

            // Define margins and spacing
            double margin = 40;
            double xPosition = margin;
            double yPosition = margin;

            // Draw the invoice title
            gfx.DrawString("REPORT", titleFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 40;

            // Draw company details
            gfx.DrawString("JamboPay", headingFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 20;
            gfx.DrawString("View Park Towers", normalFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 20;
            gfx.DrawString("Nairobi, Kenya", normalFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 40;

            // Draw customer details
            gfx.DrawString("Customer:", headingFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 20;
            gfx.DrawString(invoice.CustomerName, normalFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 20;
            gfx.DrawString(invoice.CustomerAddress, normalFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 20;
            gfx.DrawString(invoice.CustomerCity + ", " + invoice.CustomerCountry, normalFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 40;

            // Draw the invoice items table header
            gfx.DrawString("Item", headingFont, XBrushes.Black, xPosition, yPosition, format);
            xPosition += 200;
            gfx.DrawString("Quantity", headingFont, XBrushes.Black, xPosition, yPosition, format);
            xPosition += 100;
            gfx.DrawString("Unit Price", headingFont, XBrushes.Black, xPosition, yPosition, format);
            yPosition += 20;
            xPosition = margin;

            // Draw a horizontal line below the header
            gfx.DrawLine(XPens.Black, margin, yPosition, page.Width - margin, yPosition);
            yPosition += 10;

            // Draw the invoice items
            foreach (var item in invoice.Items)
            {
                gfx.DrawString(item.Name, normalFont, XBrushes.Black, xPosition, yPosition, format);
                xPosition += 200;
                gfx.DrawString(item.Quantity.ToString(), normalFont, XBrushes.Black, xPosition, yPosition, format);
                xPosition += 100;
                gfx.DrawString(item.UnitPrice.ToString("C"), normalFont, XBrushes.Black, xPosition, yPosition, format);
                yPosition += 20;
                xPosition = margin;
            }

            // Draw a horizontal line below the items
            gfx.DrawLine(XPens.Black, margin, yPosition, page.Width - margin, yPosition);
            yPosition += 10;

            // Draw the total amount
            gfx.DrawString("Total:", headingFont, XBrushes.Black, xPosition, yPosition, format);
            gfx.DrawString(invoice.TotalAmount.ToString("C"), headingFont, XBrushes.Black, page.Width - 200, yPosition, format);

            // Save the PDF to the specified file path
            document.Save(filePath);
        }

    }
}

