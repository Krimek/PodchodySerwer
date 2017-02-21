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
        string[] textStationHeader = { "Numer stacji", "Wskazówka", "Podpowiedź dla drużyny", "Następne miejsce", "Lokalizacja następnego miejsca", "Adres następnego miejsca" };

        Label amountStationLabel, amountSpecialTaskLabel;
        TextBox amountStationTextBox, amountSpecialTaskTextBox;
        Button applyAmountStationAndSpecialTaskButton;

        Label[] stationInformationLabel;

        TextBox[,] stationPropertiesTextBox;

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
            applyAmountStationAndSpecialTaskButton = new Button() { Text = "Dalej" };
            applyAmountStationAndSpecialTaskButton.Click += new EventHandler(applyAmountStationAndSpecialTaskButton_Click);
            PropertiesStalking.Controls.Add(amountStationLabel);
            PropertiesStalking.Controls.Add(amountStationTextBox);
            PropertiesStalking.Controls.Add(amountSpecialTaskLabel);
            PropertiesStalking.Controls.Add(amountSpecialTaskTextBox);
            PropertiesStalking.Controls.Add(applyAmountStationAndSpecialTaskButton);
        }

        private void applyAmountStationAndSpecialTaskButton_Click(object sender, EventArgs e)
        {
            GenerateStation();
            GenerateSpecialTask();
        }

        private void GenerateSpecialTask()
        {

        }

        private void GenerateStation()
        {
            if (App_Code.Validation.isNumber(amountStationTextBox.Text))
            {
                stationPropertiesTextBox = new TextBox[textStationHeader.Length, Convert.ToInt32(amountStationTextBox.Text)];
                int amountLabel = textStationHeader.Length;
                stationInformationLabel = new Label[amountLabel];
                for (int i = 0; i < amountLabel; i++)
                {
                    stationInformationLabel[i] = new Label()
                    {
                        Text = textStationHeader[i]
                    };
                    Station.Controls.Add(stationInformationLabel[i]);
                }
                for (int i = 0; i < Convert.ToInt32(amountStationTextBox.Text); i++)
                {
                    for (int j = 0; j < textStationHeader.Length; j++)
                    {
                        stationPropertiesTextBox[j, i] = new TextBox()
                        {
                            Text = "",
                        };
                        Station.Controls.Add(stationPropertiesTextBox[i, j]);
                    }
                }
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