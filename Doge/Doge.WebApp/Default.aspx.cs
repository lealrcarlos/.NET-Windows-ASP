using Doge.WebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Doge.WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            var ordersList = JsonConvert.DeserializeObject<List<Order>>(System.IO.File.ReadAllText(@"C:\Orders.json"));
            StringBuilder sb = new StringBuilder();

            foreach (var order in ordersList.OrderBy(p => p.RequiredShippedTime))
            {
                string delayedControl = string.Empty;

                TimeSpan timeLeft = order.RequiredShippedTime > DateTime.Now ? order.RequiredShippedTime - DateTime.Now : TimeSpan.Zero;
                string timeLeftControl = timeLeft.Days + " days " + timeLeft.Hours + " hours " + timeLeft.Minutes + " minutes " + (timeLeft.Seconds - 1 < 0 ? 0 : timeLeft.Seconds - 1) + " seconds.";

                if (order.RequiredShippedTime < DateTime.Now)
                {
                    delayedControl = "<h6 class='delayed'>Delayed</h6>";
                }
                else
                {
                    delayedControl = "<h6 class='ontime'>On time</h6>";
                }

                sb.Append(
                    "<div class='card' style='width: fit-content;'>" +
                    "   <div>" +
                    "   <h5>" + order.OrderId + "</h5>" +
                    "   " + delayedControl +
                    "   <p>Ship To:" + order.ShipTo + "</p>" +
                    "   <p>Time Left: " + timeLeftControl +
                    "</div></div>");
            }

            ph1.Controls.Add(new LiteralControl(sb.ToString()));

        }

    }
}