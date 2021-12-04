using TC.Services.DTOs.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TC.MVC.Helpers
{
    public static class DropdownHelper<T> where T : class
    {
        private static List<ISelectable> ConvertToISelectable(List<T> list)
        {
            List<ISelectable> selectableList = new();
            foreach (var i in list)
            {
                if (i is ISelectable s)
                {
                    selectableList.Add(s);
                }
            }

            return selectableList;
        }

        public static async Task<List<SelectListItem>> FillDropdownValues(List<T> list)
        {
            var tempList = ConvertToISelectable(list);

            var listForDisplay = new List<SelectListItem>();

            listForDisplay.Add(new SelectListItem()
            {
                Text = "Odaberite..",
                Value = "0"
            });

            foreach (var item in tempList)
            {
                listForDisplay.Add(new SelectListItem(item.SelectName, item.Id.ToString()));
            }
            return listForDisplay;
        }
    }
}
