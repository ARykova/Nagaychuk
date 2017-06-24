using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Model;

namespace DataAccessLayer
{
    public class Repository
    {
        public List<BottomElement> GetAllBottomElements()
        {
            var _xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = _xlApp.Workbooks.Open("D:\\Kuhnya.xlsx", Editable: true);

            List<BottomElement> BottomElements = new List<BottomElement>();
            var xlWorkSheet = xlWorkBook.Sheets[1];
            for (int i = 2; i < (xlWorkSheet.Rows.Count); i += 5)
            {
                if (xlWorkSheet.Cells[i, 1].Value != null)
                {
                    int j = 3;
                    int i2 = 1;
                    for(int k = 0; k < 12; k++)
                    {
                        if (xlWorkSheet.Cells[i + i2, j].Value != "-")
                        {
                            BottomElements.Add(new BottomElement { Name = xlWorkSheet.Cells[i, 1].Value,
                                                                   Material = xlWorkSheet.Cells[i + i2, 2].Value,
                                                                   Size = xlWorkSheet.Cells[i, j].Value,
                                                                   Price = xlWorkSheet.Cells[i + i2, j].Value });
                        }

                        if (j == 5)
                        {
                            j = 3;
                            i2++;
                        }
                    }
                    
                }
                else break;
            }
            _xlApp.Quit();
            
            return BottomElements;
        }

        //public List<Order> Orders { get; set; }

        //public List<Order> GetAllOrder()
        //{
        //    var _xlApp = new Microsoft.Office.Interop.Excel.Application();
        //    var xlWorkBook = _xlApp.Workbooks.Open("D:\\1.xlsx", Editable: true);
        //    List<Order> Orders = new List<Order>();
        //    var xlWorkSheet = xlWorkBook.Sheets[2];
        //    for (int i = 2; i < (xlWorkSheet.Rows.Count); i++)
        //    {
        //        if (xlWorkSheet.Cells[i, 1].Value != null)
        //        {
        //            Orders.Add(new Order
        //            {
        //                KitchenType = new Kitchen { Name = xlWorkSheet.Cells[i, 1].Value, Price = xlWorkSheet.Cells[i, 2].Value },
        //                A = xlWorkSheet.Cells[i, 3].Value,
        //                B = xlWorkSheet.Cells[i, 4].Value
        //            });
        //        }
        //        else break;
        //    }
        //    _xlApp.Quit();
        //    return Orders;
        //}

        //public void SaveOrders(List<Order> ords)
        //{
        //    var _xlApp = new Microsoft.Office.Interop.Excel.Application();
        //    var xlWorkBook = _xlApp.Workbooks.Open("D:\\1.xlsx", Editable: true);
        //    var xlWorkSheet = xlWorkBook.Sheets[2];
        //    for (int i = 2; i <= ords.Count; i++)
        //    {
        //        xlWorkSheet.Cells[i, 1] = ords[i - 1].KitchenType.Name;
        //        xlWorkSheet.Cells[i, 2] = ords[i - 1].KitchenType.Price;
        //        xlWorkSheet.Cells[i, 3] = ords[i - 1].A;
        //        xlWorkSheet.Cells[i, 4] = ords[i - 1].B;
        //        xlWorkSheet.Cells[i, 5] = ords[i - 1].Cost;
        //    }
        //    xlWorkBook.Save();
        //    _xlApp.Quit();
        //}


    }
}
