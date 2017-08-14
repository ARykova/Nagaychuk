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
            var xlWorkBook = _xlApp.Workbooks.Open("D:\\KursKuh\\Kuhnya.xlsx", Editable: true);

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
                            if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-") || !xlWorkSheet.Cells[i + i2, j + 1].Value.Equals("-") || !xlWorkSheet.Cells[i + i2, j + 2].Value.Equals("-"))
                            {
                                BottomElements[BottomElements.Count - 1].Materials.Add(new Material { SizeValues = new List<Size>() });
                            }
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

            xlWorkBook = null;
            xlWorkSheet = null;
            _xlApp.Quit();

            return BottomElements;
        }

        public List<TopElement> GetAllTopElements()
        {
            var _xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = _xlApp.Workbooks.Open("D:\\KursKuh\\Kuhnya.xlsx", Editable: true);

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
                            if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-") || !xlWorkSheet.Cells[i + i2, j + 1].Value.Equals("-") || !xlWorkSheet.Cells[i + i2, j + 2].Value.Equals("-"))
                            {
                                TopElements[TopElements.Count - 1].Materials.Add(new Material { SizeValues = new List<Size>() });
                            }
                        }
                        if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-"))
                        {
                            TopElements[TopElements.Count - 1].Materials[TopElements[TopElements.Count - 1].Materials.Count - 1]
                                                              .NameOfMaterial = xlWorkSheet.Cells[i + i2, 2].Value;

                            TopElements[TopElements.Count - 1].Materials[TopElements[TopElements.Count - 1].Materials.Count - 1]
                                                              .SizeValues
                                                              .Add(new Size{ SizeValue = xlWorkSheet.Cells[i, j].Value.ToString(),
                                                                             Price = xlWorkSheet.Cells[i + i2, j].Value });
                        }
                        j++;

                    }

                }
                else break;
            }

            xlWorkBook = null;
            xlWorkSheet = null;
            _xlApp.Quit();

            return TopElements;
        }

        public List<Penal> GetAllPenals()
        {
            var _xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = _xlApp.Workbooks.Open("D:\\KursKuh\\Kuhnya.xlsx", Editable: true);

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
                            if (!xlWorkSheet.Cells[i + i2, j].Value.Equals("-") || !xlWorkSheet.Cells[i + i2, j + 1].Value.Equals("-") || !xlWorkSheet.Cells[i + i2, j + 2].Value.Equals("-"))
                            {
                                Penals[Penals.Count - 1].Materials.Add(new Material { SizeValues = new List<Size>() });
                            }
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

            xlWorkBook = null;
            xlWorkSheet = null;
            _xlApp.Quit();

            return Penals;
        }

        public void SaveOrders(List<OrderItem> order, double resultCost)
        {
            var _xlApp = new Microsoft.Office.Interop.Excel.Application();
            var xlWorkBook = _xlApp.Workbooks.Open("D:\\KursKuh\\Orders.xlsx", Editable: true);
            var xlWorkSheet = xlWorkBook.Sheets.Add();
            xlWorkSheet.Cells[1, 1] = "Тип";
            xlWorkSheet.Cells[1, 2] = "Название";
            xlWorkSheet.Cells[1, 3] = "Материал";
            xlWorkSheet.Cells[1, 4] = "Размер";
            xlWorkSheet.Cells[1, 5] = "Цена";
            xlWorkSheet.Cells[1, 6] = "Количество";
            xlWorkSheet.Cells[1, 7] = "Стоимость";
            int i = 2;
            foreach (OrderItem item in order)
            {
                xlWorkSheet.Cells[i, 1] = item.Type;
                xlWorkSheet.Cells[i, 2] = item.ItemName;
                xlWorkSheet.Cells[i, 3] = item.Material;
                xlWorkSheet.Cells[i, 4] = item.Size;
                xlWorkSheet.Cells[i, 5] = item.Price;
                xlWorkSheet.Cells[i, 6] = item.Count;
                xlWorkSheet.Cells[i, 7] = item.Cost;
                i++;
            }
            xlWorkSheet.Cells[i, 1] = "Общая стоимость заказа:";
            xlWorkSheet.Cells[i, 3] = resultCost;

            xlWorkBook.Save();
            xlWorkBook = null;
            xlWorkSheet = null;
            _xlApp.Quit();
        }

        //public void SaveOrders(BottomElement bot, Material botMaterial, Size botSize,
        //                       TopElement top, Material topMaterial, Size topSize,
        //                       Penal penal, Material penalMaterial, Size penalSize,
        //                       double price)
        //{
        //    var _xlApp = new Microsoft.Office.Interop.Excel.Application();
        //    var xlWorkBook = _xlApp.Workbooks.Open("D:\\KursKuh\\Orders.xlsx", Editable: true);
        //    var xlWorkSheet = xlWorkBook.Sheets[1];

        //    double countOfRaws = xlWorkSheet.Cells[1, 5].Value;
        //    xlWorkSheet.Cells[countOfRaws, 1] = $"Заказ №{xlWorkSheet.Cells[1, 6].Value}";
        //    xlWorkSheet.Cells[countOfRaws, 2] = $"На сумму:";
        //    xlWorkSheet.Cells[countOfRaws, 3] = $"{price}";
        //    xlWorkSheet.Cells[1, 6].Value += 1;


        //    if (topSize != null)
        //    {
        //        xlWorkSheet.Cells[countOfRaws + 1, 1] = "Верхний элемент:";
        //        xlWorkSheet.Cells[countOfRaws + 1, 2] = top.Name;
        //        xlWorkSheet.Cells[countOfRaws + 1, 3] = topMaterial.NameOfMaterial;
        //        xlWorkSheet.Cells[countOfRaws + 1, 4] = topSize.SizeValue;

        //    }
        //    else
        //    {
        //        xlWorkSheet.Cells[countOfRaws + 1, 1] = "Верхний элемент:";
        //        xlWorkSheet.Cells[countOfRaws + 1, 2] = "-";
        //        xlWorkSheet.Cells[countOfRaws + 1, 3] = "-";
        //        xlWorkSheet.Cells[countOfRaws + 1, 4] = "-";
        //    }

        //    if (botSize != null)
        //    {
        //        xlWorkSheet.Cells[countOfRaws + 2, 1] = "Нижний элемент:";
        //        xlWorkSheet.Cells[countOfRaws + 2, 2] = bot.Name;
        //        xlWorkSheet.Cells[countOfRaws + 2, 3] = botMaterial.NameOfMaterial;
        //        xlWorkSheet.Cells[countOfRaws + 2, 4] = botSize.SizeValue;

        //    }
        //    else
        //    {
        //        xlWorkSheet.Cells[countOfRaws + 2, 1] = "Нижний элемент:";
        //        xlWorkSheet.Cells[countOfRaws + 2, 2] = "-";
        //        xlWorkSheet.Cells[countOfRaws + 2, 3] = "-";
        //        xlWorkSheet.Cells[countOfRaws + 2, 4] = "-";
        //    }

        //    if (penalSize != null)
        //    {
        //        xlWorkSheet.Cells[countOfRaws + 3, 1] = "Пенал:";
        //        xlWorkSheet.Cells[countOfRaws + 3, 2] = penal.Name;
        //        xlWorkSheet.Cells[countOfRaws + 3, 3] = penalMaterial.NameOfMaterial;
        //        xlWorkSheet.Cells[countOfRaws + 3, 4] = penalSize.SizeValue;
        //    }
        //    else
        //    {
        //        xlWorkSheet.Cells[countOfRaws + 3, 1] = "Пенал:";
        //        xlWorkSheet.Cells[countOfRaws + 3, 2] = "-";
        //        xlWorkSheet.Cells[countOfRaws + 3, 3] = "-";
        //        xlWorkSheet.Cells[countOfRaws + 3, 4] = "-";
        //    }

        //    xlWorkSheet.Cells[1, 5].Value += 5;

        //    xlWorkBook.Save();
        //    xlWorkBook = null;
        //    xlWorkSheet = null;
        //    _xlApp.Quit();
        //}
    }
}
