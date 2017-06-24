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
                    BottomElements.Add(new BottomElement
                    {
                        Name = xlWorkSheet.Cells[i, 1].Value,
                        Materials = new List<Material>()
                    });
                    int j = 6;
                    int i2 = 0;
                    for(int k = 0; k < 12; k++)
                    {
                        if (j == 6)
                        {
                            j = 3;
                            i2++;
                            BottomElements[BottomElements.Count - 1].Materials.Add(new Material { SizeValues = new List<Size>() });
                        }
                        if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-"))
                        {
                            BottomElements[BottomElements.Count - 1].Materials[BottomElements[BottomElements.Count - 1].Materials.Count - 1]
                                                                    .NameOfMaterial = xlWorkSheet.Cells[i + i2, 2].Value;

                            BottomElements[BottomElements.Count - 1].Materials[BottomElements[BottomElements.Count - 1].Materials.Count - 1]
                                                                    .SizeValues
                                                                    .Add(new Size{ SizeValue = xlWorkSheet.Cells[i, j].Value.ToString(),
                                                                                   Price = xlWorkSheet.Cells[i + i2, j].Value});
                        }
                        j++;
                        
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
                    TopElements.Add(new TopElement
                    {
                        Name = xlWorkSheet.Cells[i, 1].Value,
                        Materials = new List<Material>()
                    });

                    int j = 6;
                    int i2 = 0;
                    for (int k = 0; k < 12; k++)
                    {
                        if (j == 6)
                        {
                            j = 3;
                            i2++;
                            TopElements[TopElements.Count - 1].Materials.Add(new Material { SizeValues = new List<Size>() });
                        }
                        if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-"))
                        {
                            TopElements[TopElements.Count - 1].Materials[TopElements[TopElements.Count - 1].Materials.Count - 1]
                                .NameOfMaterial = xlWorkSheet.Cells[i + i2, 2].Value;

                            TopElements[TopElements.Count - 1].Materials[TopElements[TopElements.Count - 1].Materials.Count - 1]
                                .SizeValues
                                .Add(new Size
                                {
                                    SizeValue = xlWorkSheet.Cells[i, j].Value.ToString(),
                                    Price = xlWorkSheet.Cells[i + i2, j].Value
                                });
                        }
                        j++;

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
                    Penals.Add(new Penal
                    {
                        Name = xlWorkSheet.Cells[i, 1].Value,
                        Materials = new List<Material>()
                    });

                    int j = 6;
                    int i2 = 0;
                    for (int k = 0; k < 12; k++)
                    {
                        if (j == 6)
                        {
                            j = 3;
                            i2++;
                            Penals[Penals.Count - 1].Materials.Add(new Material { SizeValues = new List<Size>() });
                        }
                        if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-"))
                        {
                            Penals[Penals.Count - 1].Materials[Penals[Penals.Count - 1].Materials.Count - 1]
                                .NameOfMaterial = xlWorkSheet.Cells[i + i2, 2].Value;

                            Penals[Penals.Count - 1].Materials[Penals[Penals.Count - 1].Materials.Count - 1]
                                .SizeValues
                                .Add(new Size
                                {
                                    SizeValue = xlWorkSheet.Cells[i, j].Value.ToString(),
                                    Price = xlWorkSheet.Cells[i + i2, j].Value
                                });
                        }
                        j++;

                    }

                }
                else break;
            }
            _xlApp.Quit();

            return Penals;

        }
    }
}
