using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApi.Models
{
    public class ViewModel
    {

        private string[] ReadFile(string fileaddress)
        {
            try
            {

                return System.IO.File.ReadAllLines(fileaddress);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IEnumerable<Table01Model> GetModelTable01(string[] arrTable)
        {
            try
            {
                List<Table01Model> modelList = new List<Table01Model>();

                if (arrTable.Length > 0)
                {
                    foreach (string element in arrTable)
                    {
                        Table01Model model = new Table01Model();
                        string[] arrSubElements = element.Split('|');

                        if (arrSubElements.Length > 0)
                        {
                            for (int i = 0; i <= arrSubElements.Length-1; i++)
                            {
                                switch (i)
                                {
                                    case 0:
                                        model.Id = arrSubElements[i].TrimEnd();
                                        break;
                                    case 1:
                                        model.FullName = arrSubElements[i].TrimStart().TrimEnd();
                                        break;
                                    default:
                                        break;
                                }
                            }

                            modelList.Add(model);
                        }
                    }
                }

                return modelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<Table02Model> GetModel(string strTable01Address, string strTable02Address)
        {
            try
            {

                string[] arrTable01 = ReadFile(strTable01Address);
                string[] arrTable02 = ReadFile(strTable02Address);

                List<Table01Model> model01List = GetModelTable01(arrTable01).ToList();

                List<Table02Model> model02List = new List<Table02Model>();

                if (arrTable02.Length > 0)
                {
                    foreach (string element in arrTable02)
                    {
                        Table02Model model = new Table02Model();
                        string[] arrSubElements = element.Split('|');

                        if (arrSubElements.Length > 0)
                        {
                            for (int i = 0; i <= arrSubElements.Length - 1; i++)
                            {
                                switch (i)
                                {
                                    case 0:
                                        model.Id = arrSubElements[i].TrimEnd();
                                        break;
                                    case 1:
                                        model.ToyName = arrSubElements[i].TrimStart().TrimEnd();
                                        break;
                                    case 2:
                                        if (model01List.Count() > 0)
                                        {
                                            List<Table01Model> tempModel = new List<Table01Model>();
                                            foreach (Table01Model modelItem in model01List)
                                            {
                                                if (arrSubElements[i].TrimStart().TrimEnd().Contains(modelItem.Id))
                                                {
                                                    tempModel.Add(modelItem);
                                                }
                                            }
                                            model.Table01List = tempModel;
                                        }
                                        
                                        break;
                                    default:
                                        break;
                                }
                            }

                            model02List.Add(model);
                        }
                    }
                }
                
                return model02List;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}