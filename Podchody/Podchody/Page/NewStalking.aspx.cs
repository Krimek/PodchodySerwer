using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Podchody.Page
{
    public partial class NewStalking : System.Web.UI.Page
    {
        Label amountStationLabel, amountSpecialTaskLabel;
        TextBox amountStationTextBox, amountSpecialTaskTextBox;
        Button applyamountStationAndSpecialTaskButton;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GeneratePage();
            }
        }

        private void GeneratePage()
        {
            amountStationLabel = new Label() { Text = "Ilość stacji" };
            amountStationTextBox= new TextBox() { Text = "0", Width = 40, MaxLength = 2 };
            amountStationTextBox.TextChanged += new EventHandler(amountStationTextChanged);
            amountSpecialTaskLabel = new Label() { Text = "Ilość stacji" };
            amountSpecialTaskTextBox = new TextBox() { Text = "0", Width = 40, MaxLength = 2 };
            amountSpecialTaskTextBox.TextChanged += new EventHandler(amountSpecialTaskTextChanged);
            applyamountStationAndSpecialTaskButton = new Button() { Text = "Dalej" };
            applyamountStationAndSpecialTaskButton.Click += new EventHandler(applyamountStationAndSpecialTaskButton_Click);
            PropertiesStalking.Controls.Add(amountStationLabel);
            PropertiesStalking.Controls.Add(amountStationTextBox);
            PropertiesStalking.Controls.Add(amountSpecialTaskLabel);
            PropertiesStalking.Controls.Add(amountSpecialTaskTextBox);
            PropertiesStalking.Controls.Add(applyamountStationAndSpecialTaskButton);
        }

        private void applyamountStationAndSpecialTaskButton_Click(object sender, EventArgs e)
        {
            GenerateStation();
            GenerateSpecialTask();
        }

        private void GenerateSpecialTask()
        {

        }

        private void GenerateStation()
        {
            for(int i =0;i<Convert.ToInt32(amountStationTextBox.Text);i++)
            {

            }
        }

        private void amountSpecialTaskTextChanged(object sender, EventArgs e)
        {

        }

        private void amountStationTextChanged(object sender, EventArgs e)
        {

        }
    }
}