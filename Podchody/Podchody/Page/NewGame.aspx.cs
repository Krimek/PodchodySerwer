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
        string[] stationHeader = { "Numer stacji", "Opis", "Wskazówka", "Następne miejsce", "Lokalizacja", "Adres" };
        string[] specialTaskHeader = { "Nazwa", "Opis", "Bonus" };

        Label amountStationLabel, amountSpecialTaskLabel;
        TextBox amountStationTextBox, amountSpecialTaskTextBox;
        Button applyAmountStationAndSpecialTaskButton;

        Label[] stationHeaderLabel;
        Label[] specialTaskHeaderLabel;

        TextBox[,] stationPropertiesTextBox;
        TextBox[,] specialTaskPropertiesTextBox;

        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratePage();
        }

        private void GeneratePage()
        {
            amountStationLabel = new Label() { Text = "Ilość stacji" };
            amountStationTextBox= new TextBox() { Text = "", Width = 40, MaxLength = 2 };
            amountStationTextBox.TextChanged += new EventHandler(amountStationTextChanged);

            amountSpecialTaskLabel = new Label() { Text = "Ilość zadań soecjalnych" };
            amountSpecialTaskTextBox = new TextBox() { Text = "", Width = 40, MaxLength = 2 };
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

        private void GenerateStation()
        {
            if (App_Code.Validation.isNumber(amountStationTextBox.Text))
            {
                int amountLabel = stationHeader.Length;
                int amountStation = Convert.ToInt32(amountStationTextBox.Text);

                stationPropertiesTextBox = new TextBox[amountLabel, amountStation];
                stationHeaderLabel = new Label[amountLabel];

                for (int i = 0; i < amountLabel; i++)
                {
                    stationHeaderLabel[i] = new Label()
                    {
                        Text = stationHeader[i]
                    };
                    Station.Controls.Add(stationHeaderLabel[i]);
                }
                Station.Controls.Add(new LiteralControl("<br />"));
                for (int i = 0; i < amountStation; i++)
                {
                    for (int j = 0; j < amountLabel; j++)
                    {
                        stationPropertiesTextBox[j, i] = new TextBox()
                        {
                            Width = 100,
                            Height = 25
                        };
                        Station.Controls.Add(stationPropertiesTextBox[j, i]);
                    }
                    Station.Controls.Add(new LiteralControl("<br />"));
                }
            }
        }

        private void GenerateSpecialTask()
        {
            if (App_Code.Validation.isNumber(amountStationTextBox.Text))
            {
                int amountLabel = specialTaskHeader.Length;
                int amountSpecialTask = Convert.ToInt32(amountSpecialTaskTextBox.Text);

                specialTaskHeaderLabel = new Label[amountLabel];
                specialTaskPropertiesTextBox = new TextBox[amountLabel, amountSpecialTask];

                for (int i = 0; i < amountLabel; i++)
                {
                    specialTaskHeaderLabel[i] = new Label()
                    {
                        Text = specialTaskHeader[i]
                    };
                    SpecialTask.Controls.Add(specialTaskHeaderLabel[i]);
                }
                SpecialTask.Controls.Add(new LiteralControl("<br />"));
                for (int i = 0; i < amountSpecialTask; i++)
                {
                    for (int j = 0; j < amountLabel; j++)
                    {
                        specialTaskPropertiesTextBox[j, i] = new TextBox()
                        {
                            Width = 40,
                            Height = 20
                        };
                        SpecialTask.Controls.Add(stationPropertiesTextBox[j, i]);
                    }
                    SpecialTask.Controls.Add(new LiteralControl("<br />"));
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