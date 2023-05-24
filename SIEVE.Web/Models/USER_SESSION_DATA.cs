using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIEVE.Web.Models
{
    public class USER_SESSION_DATA
    {
        /// <summary>
        /// Table Id, User Id, VT ID (Its not vendor Id)
        /// </summary>
        public string USER_ID_MY_ID { get; set; }

        /// <summary>
        /// Tagged with Vendor ID or Null for User or Company Id for User
        /// </summary>
        public string ASSOCIATED_WITH_ID { get; set; }

        /// <summary>
        /// Contact Person Name or User Name
        /// </summary>
        public string USER_NAME_MY_NAME { get; set; }


        /// <summary>
        /// Organization Name Or Company Name or Null of User
        /// </summary>
        public string ORG_COMP_NAME { get; set; }

        /// <summary>
        /// Login email Id
        /// </summary>
        public string EMAIL_ID { get; set; }

        /// <summary>
        /// profile picture image link
        /// </summary>
        public string PROFILE_IMAGE { get; set; }

        /// <summary>
        /// Vendor Role or User Role
        /// </summary>
        public ENM_USER_ROLE USER_ROLE { get; set; }

    }
}