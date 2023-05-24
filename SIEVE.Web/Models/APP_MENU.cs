using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIEVE.Web.Models
{
    public class APP_MENU
    {
        public int PARENT_ID { get; set; }
        public string PARENT_NAME_EN { get; set; }
        public string PARENT_NAME_BN { get; set; }
        public string PARENT_ICON { get; set; }
        public int PARENT_ORDER { get; set; }

        public int MENU_ID { get; set; }
        public string MENU_NAME_EN { get; set; }
        public string MENU_NAME_BN { get; set; }
        public string MENU_ICON { get; set; }
        public string AREA_NAME { get; set; }
        public string CONTROLLER_NAME { get; set; }
        public string ACTION_NAME { get; set; }
        public int MENU_ORDER { get; set; }
    }
}