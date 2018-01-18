using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_CarsSearch
{
    public partial class Search : System.Web.UI.Page
    {
        private Producer[] producers = new Producer[]
        {
            new Producer("BMW", new string[]
            {
               "z5",
               "z3",
               "710d"
            }),
            new Producer("Opel", new string[]
            {
               "tigra",
               "zafira",
               "kadet"
            }),
        };

        private Extra extras = new Extra(
            new string[]
            {
                "manual",
                "auto"
            },
            new string[]
            {
                "diesel",
                "gazoline"
            }
            );

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ltProducers.DataSource = this.producers;
                this.ltProducers.DataTextField = "Name";
                this.ltProducers.DataValueField = "Name";

                this.ltModels.DataSource = this.producers[0].Models;

                this.ltEngines.DataSource = this.extras.EngineTypes;
                this.ltGearBoxes.DataSource = this.extras.Gears;

                ViewState["SelectedProducerIndex"] = 0;
            }
            else
            {
                var producerIndex = this.ltProducers.SelectedIndex;
                if (producerIndex != (int)ViewState["SelectedProducerIndex"])
                {
                    this.ltModels.DataSource = this.producers[producerIndex].Models;
                }
            }

            this.DataBind();
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            this.postbackQuery.Text = $@"
<b>Producer:</b> {this.ltProducers.SelectedItem}
<b>Model:</b> {this.ltModels.SelectedItem}
<br />
<b>Engine type:</b> {this.ltEngines.SelectedItem}
<br />
<b>Gear box:</b> {this.ltGearBoxes.SelectedItem}
";

            ViewState["SelectedProducerIndex"] = this.ltProducers.SelectedIndex;
        }

    }
}