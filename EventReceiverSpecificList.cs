using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace EventReceiver.EventReceiverSpecificList
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EventReceiverSpecificList : SPItemEventReceiver
    {
        /// <summary>
        /// An item is being updated.
        /// </summary>
        public override void ItemUpdating(SPItemEventProperties properties)
        {
            using (SPWeb web = properties.OpenWeb())
            {
                try
                {
                    System.Diagnostics.Debugger.Break();
                    SPList list = web.Lists["DocumentLog"];
                    SPListItem newItem = list.Items.Add();
                    newItem["Title"] = properties.ListItem.Title;
                    newItem["DateAndTime"] = System.DateTime.Now;
                    newItem["Action"] = "Item  Announcements Updated";
                    newItem.Update();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
