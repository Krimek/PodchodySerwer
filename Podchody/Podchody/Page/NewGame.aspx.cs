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
        string[] stationHeader = { "Numer stacji", "Opis", "Wskazówka", "Pełna wskazówka", "Lokalizacja", "Adres" };
        string[] specialTaskHeader = { "Nazwa", "Opis", "Bonus", "Przy stacji numer: " };

        Label[] stationHeaderLabel;
        Label[] specialTaskHeaderLabel;

        TextBox[] stationPropertiesTextBox;
        TextBox[] specialTaskPropertiesTextBox;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void GenerateStation()
        {
            for(int i =0;i<Convert.ToInt32(amountStationTextBox.Text);i++)
            {
                stationPropertiesTextBox = new TextBox[stationHeader.Length];
                
            }
        }


        private void GenerateSpecialTask()
        {
            
        }

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            GenerateStation();
            GenerateSpecialTask();
        }
    }
}