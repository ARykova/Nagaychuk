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
                        if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-"))
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

        public List<TopElement> GetAllTopElements()
        {
            var _xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = _xlApp.Workbooks.Open("D:\\Kuhnya.xlsx", Editable: true);

            List<TopElement> TopElements = new List<TopElement>();
            var xlWorkSheet = xlWorkBook.Sheets[2];
            for (int i = 2; i < (xlWorkSheet.Rows.Count); i += 5)
            {
                if (xlWorkSheet.Cells[i, 1].Value != null)
                {
                    int j = 3;
                    int i2 = 1;
                    for (int k = 0; k < 12; k++)
                    {
                        if (xlWorkSheet.Cells[i + i2, j].Value != "-")
                        {
                            TopElements.Add(new TopElement
                            {
                                Name = xlWorkSheet.Cells[i, 1].Value,
                                Material = xlWorkSheet.Cells[i + i2, 2].Value,
                                Size = xlWorkSheet.Cells[i, j].Value,
                                Price = xlWorkSheet.Cells[i + i2, j].Value
                            });
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

            return TopElements;
        }

        public List<Penal> GetAllPenals()
        {
            var _xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = _xlApp.Workbooks.Open("D:\\Kuhnya.xlsx", Editable: true);

            List<Penal> Penals = new List<Penal>();
            var xlWorkSheet = xlWorkBook.Sheets[3];
            for (int i = 2; i < (xlWorkSheet.Rows.Count); i += 5)
            {
                if (xlWorkSheet.Cells[i, 1].Value != null)
                {
                    int j = 3;
                    int i2 = 1;
                    for (int k = 0; k < 12; k++)
                    {
                        if (xlWorkSheet.Cells[i + i2, j].Value != "-")
                        {
                            Penals.Add(new Penal
                            {
                                Name = xlWorkSheet.Cells[i, 1].Value,
                                Material = xlWorkSheet.Cells[i + i2, 2].Value,
                                Size = xlWorkSheet.Cells[i, j].Value,
                                Price = xlWorkSheet.Cells[i + i2, j].Value
                            });
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

            return Penals;
        }
    }
}
