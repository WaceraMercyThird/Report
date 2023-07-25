using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Report_pdf
{
    internal class Program
    {
        public static void Main()
        {
            // Specify the file path where the PDF will be saved
            string filePath = "C:\\Temp\\InvoiceReport.pdf";

            // Create an instance of the PdfGenerator class
            var pdfGenerator = new PdfGenerator();

            // Create a list of InvoiceItem
            var items = new List<InvoiceItem>
            {
                new InvoiceItem { Name = "Item 1", Quantity = 2, UnitPrice = 10.0m },
                new InvoiceItem { Name = "Item 2", Quantity = 1, UnitPrice = 15.0m },
                new InvoiceItem { Name = "Item 3", Quantity = 3, UnitPrice = 5.0m }
            };

            // Create an instance of the Invoice class with sample data
            var invoice = new Invoice
            {
                CustomerName = "John Smith",
                CustomerAddress = "123 Main Street",
                CustomerCity = "Nairobi",
                CustomerCountry = "Kenya",
                Items = items,
                TotalAmount = items.Sum(item => item.Quantity * item.UnitPrice)
            };



            // Call the GenerateInvoice method to create the invoice PDF
            pdfGenerator.GenerateInvoice(filePath, invoice);


            Console.WriteLine("PDF created successfully!");
        }
    }
}
