using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using KursMVVM.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class LoadPDFClient : ILoadInteface<Client>
    {
        public Task LoadList(string path)
        {
            throw new NotImplementedException();
        }

        public async Task Upload(string path, List<Client> list)
        {
            using (PdfDocument pdfDoc = new PdfDocument(new PdfWriter(path)))
            using (Document doc = new Document(pdfDoc))
            {
                PdfFont cyrillicFont = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\arial.ttf", "Identity-H");
                doc.SetFont(cyrillicFont);
                PdfFont bold = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\arialbd.ttf", PdfEncodings.IDENTITY_H);
                Paragraph paragraph = new Paragraph(new Text("Клиенты").SetFont(bold).SetFontSize(20));
                paragraph.SetTextAlignment(TextAlignment.CENTER);
                doc.Add(paragraph);
                
                Table table = new Table(UnitValue.CreatePercentArray(new float[] { 10, 10, 10,10,10,10,10}));
                table.SetMarginTop(5);
                table.SetTextAlignment(TextAlignment.CENTER);
                for (int j = 0; j < 7; j++)
                {
                    string nameColumn = "";
                    switch (j)
                    {
                        case 0: nameColumn = "Имя"; break;
                        case 1: nameColumn = "Отчество"; break;
                        case 2: nameColumn = "Фамилия"; break;
                        case 3: nameColumn = "Адрес"; break;
                        case 4: nameColumn = "Телефон"; break;
                        case 5: nameColumn = "Номер договора"; break;
                        case 6: nameColumn = "Дата договора"; break;
                    }
                    table.AddCell(nameColumn);
                }
                foreach (Client item in list)
                {
                    table.AddCell(item.FirstName);
                    table.AddCell(item.LastName);
                    table.AddCell(item.Surname);
                    table.AddCell(item.Address);
                    table.AddCell(item.Phone);
                    table.AddCell(item.NumberDogovor.ToString());
                    table.AddCell(item.DataDogovor);
                }
                doc.Add(table);
                doc.Close();
            }
        }
    }
}
