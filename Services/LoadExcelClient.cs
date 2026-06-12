using KursMVVM.Models;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace KursMVVM.Services
{
    public class LoadExcelClient : ILoadInteface<Client>
    {
        public Task LoadList(string path)
        {
            throw new NotImplementedException();
        }

        public async Task Upload(string path, List<Client> list)
        {
            ExcelPackage.License.SetNonCommercialPersonal("KBK");
            var fileInfo = new FileInfo(path);
            using (var package = new ExcelPackage(fileInfo))
            {
                try
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Clients");
                    worksheet.Cells["A1"].Value = "IdClient";
                    worksheet.Cells["B1"].Value = "FirstName";
                    worksheet.Cells["C1"].Value = "LastName";
                    worksheet.Cells["D1"].Value = "Surname";
                    worksheet.Cells["E1"].Value = "Address";
                    worksheet.Cells["F1"].Value = "Phone";
                    worksheet.Cells["G1"].Value = "NumberDogovor";
                    worksheet.Cells["H1"].Value = "DateDogovor";
                    int i = 2;
                    foreach (var item in list)
                    {
                        worksheet.Cells["A" + i].Value = item.IdClient;
                        worksheet.Cells["B" + i].Value = item.FirstName;
                        worksheet.Cells["C" + i].Value = item.LastName;
                        worksheet.Cells["D" + i].Value = item.Surname;
                        worksheet.Cells["E" + i].Value = item.Address;
                        worksheet.Cells["F" + i].Value = item.Phone;
                        worksheet.Cells["G" + i].Value = item.NumberDogovor;
                        worksheet.Cells["H" + i].Value = item.DataDogovor;
                        i++;
                    }
                    await package.SaveAsync();
                }
                catch (Exception ex)
                {
                    var box = MessageBoxManager.GetMessageBoxStandard("Ошибка", ex.Message, ButtonEnum.Ok);
                }
            }

        }
    }
}
