using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace EventDocuments.CopyNameToTitle
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class CopyNameToTitle : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdding(properties);

            SPWeb web = properties.Web;
            SPListItem item = properties.ListItem;
            item["Title"] =item["FileLeafRef"];
            item.Update();
        }

        /// <summary>
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdating(properties);
            SPWeb web = properties.Web;
            SPListItem item = properties.ListItem;
            item["Title"] = item["FileLeafRef"];
            item.Update();
        }


    }
}