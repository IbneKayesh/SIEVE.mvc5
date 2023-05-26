using System.Collections.Generic;
using System.Web.Mvc;

namespace SIEVE.Web.Extension
{
    public class SelectListService
    {
        public static SelectList GetBonding()
        {
            SelectList DataList = new SelectList(
                  new List<SelectListItem>
                  {
                    new SelectListItem { Text = "Self", Value ="Self"},
                    new SelectListItem { Text = "Wife", Value ="Wife"},
                    new SelectListItem { Text = "Son", Value ="Son"},
                    new SelectListItem { Text = "Dougher", Value ="Dougher"},
                    new SelectListItem { Text = "Mother", Value ="Mother"},
                    new SelectListItem { Text = "Father", Value ="Father"},
                      }, "Value", "Text", 1);
            return DataList;
        }
        public static SelectList GetGender()
        {
            SelectList DataList = new SelectList(
                  new List<SelectListItem>
                  {
                    new SelectListItem { Text = "Male", Value ="Male"},
                    new SelectListItem { Text = "Female", Value ="Female"}
                      }, "Value", "Text", 1);
            return DataList;
        }
        public static SelectList GetBloodGroup()
        {
            SelectList DataList = new SelectList(
                  new List<SelectListItem>
                  {
                    new SelectListItem { Text = "O+", Value ="O+"},
                    new SelectListItem { Text = "O-", Value ="O-"}
                      }, "Value", "Text", 1);
            return DataList;
        }
        public static SelectList GetReligion()
        {
            SelectList DataList = new SelectList(
                  new List<SelectListItem>
                  {
                    new SelectListItem { Text = "N/A", Value ="N/A"},
                    new SelectListItem { Text = "Islam", Value ="Islam"},
                    new SelectListItem { Text = "Hindu", Value ="Hindu"},
                      }, "Value", "Text", 1);
            return DataList;
        }
    }
}