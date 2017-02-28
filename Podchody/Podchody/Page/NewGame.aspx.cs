using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Podchody.App_Code;

namespace Podchody.Page
{
    public partial class NewStalking : System.Web.UI.Page
    {
        string[] stationHeader = { "Numer stacji", "Opis", "Wskazówka", "Pełna wskazówka", "Lokalizacja" };
        string[] specialTaskHeader = { "Numer Zadania", "Nazwa", "Opis", "Bonus", "Przy stacji numer: " };

        Point[] sizeStationTextBox = { new Point(20, 20), new Point(300, 20), new Point(100, 20), new Point(100, 20), new Point(200, 20) };
        Point[] sizeSpecialTaskTextBox = { new Point(20, 20), new Point(100, 20), new Point(300, 20), new Point(40, 20), new Point(40, 20) };

        int[] maxSizeStationTextBox = { 2, 1000, 100, 100, 200 };
        int[] maxSizeSpecialTaskTextBox = { 2, 50, 1000, 2, 2 };

        Label[] stationHeaderLabel;
        Label[] specialTaskHeaderLabel;

        TextBox[] stationTextBox;
        TextBox[] specialTaskTextBox;

        private int amountAddingStation = 0;
        private int amountAddingSpecialTask = 0;

        private int currentAmmountAddingStation = 1;
        private int currentAmmountAddingSpecialTask = 1;

        Button addStationButton;
        Button addSpecialTaskButton;
        Button finishButton;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateStation();
            GenerateSpecialTask();
            finishButton = new Button() { Text = "Przejdź do zarządzania", Enabled = false };
            finishButton.Click += new EventHandler(FinishButton_Click);
            finishDiv.Controls.Add(finishButton);
        }

        #region Load and Save variable
        private void LoadData()
        {
            currentAmmountAddingStation = (int)ViewState["currentAmmountAddingStation"];
            amountAddingStation = (int)ViewState["amountAddingStation"];
            currentAmmountAddingSpecialTask = (int)ViewState["currentAmmountAddingSpecialTask"];
            amountAddingSpecialTask = (int)ViewState["amountAddingSpecialTask"];
        }

        private void SaveData()
        { 
            ViewState["currentAmmountAddingStation"] = currentAmmountAddingStation;
            ViewState["amountAddingStation"] = amountAddingStation;
            ViewState["currentAmmountAddingSpecialTask"] = currentAmmountAddingSpecialTask;
            ViewState["amountAddingSpecialTask"] = amountAddingSpecialTask;
        }
        #endregion
        
        private void GenerateStation()
        {
            addingStationDiv.Controls.Clear();
            addingStationButtonDiv.Controls.Clear();
            stationTextBox = new TextBox[stationHeader.Length];
            stationHeaderLabel = new Label[stationHeader.Length];
            for (int i = 0; i < stationHeader.Length; i++)
            {
                stationHeaderLabel[i] = GenereteLabel(stationHeader[i]);
                stationTextBox[i] = GenereteTextBox("", sizeStationTextBox[i].X, sizeStationTextBox[i].Y, maxSizeStationTextBox[i]);
                addingStationDiv.Controls.Add(stationHeaderLabel[i]);
                addingStationDiv.Controls.Add(stationTextBox[i]);
            }

            stationTextBox[0].Text = currentAmmountAddingStation.ToString();

            addStationButton = new Button()
            {
                Text = "Dodaj",
                Enabled = false
            };
            addStationButton.Click += new EventHandler(AddStationButton_Click);
            addingStationButtonDiv.Controls.Add(addStationButton);
        }
        
        private void GenerateSpecialTask()
        {
            addingSpecialTaskDiv.Controls.Clear();
            addingSpecialTaskButtonDiv.Controls.Clear();
            specialTaskTextBox = new TextBox[specialTaskHeader.Length];
            specialTaskHeaderLabel = new Label[specialTaskHeader.Length];
            for (int i = 0; i < specialTaskHeader.Length; i++)
            {
                specialTaskHeaderLabel[i] = GenereteLabel(specialTaskHeader[i]);
                specialTaskTextBox[i] = GenereteTextBox("", sizeSpecialTaskTextBox[i].X, sizeSpecialTaskTextBox[i].Y, maxSizeSpecialTaskTextBox[i]);
                addingSpecialTaskDiv.Controls.Add(specialTaskHeaderLabel[i]);
                addingSpecialTaskDiv.Controls.Add(specialTaskTextBox[i]);
            }

            specialTaskTextBox[0].Text = currentAmmountAddingSpecialTask.ToString();

            addSpecialTaskButton = new Button()
            {
                Text = "Dodaj",
                Enabled = false
            };

            addSpecialTaskButton.Click += new EventHandler(AddSpecialTaskButton_Click);
            addingSpecialTaskButtonDiv.Controls.Add(addSpecialTaskButton);
        }

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            if (Validation.isNumber(amountStationTextBox.Text) && Validation.isNumber(amountSpecialTaskTextBox.Text) && Validation.isNumber(penaltyHintTextBox.Text) && Validation.isNumber(penaltyNextPlaceTextBox.Text))
            {

                Models.ServiceDataBase sdb = new Models.ServiceDataBase();
                sdb.ClearTable("STATION");
                sdb.ClearTable("SPECIALTASK");

                currentAmmountAddingStation = 1;
                amountAddingStation = Convert.ToInt32(amountStationTextBox.Text);
                currentAmmountAddingSpecialTask = 1;
                amountAddingSpecialTask = Convert.ToInt32(amountSpecialTaskTextBox.Text);

                UnEnabledAdding();
                SaveData();
            }
        }

        private void AddStationButton_Click(object sender, EventArgs e)
        {
            LoadData();
            Models.ServiceDataBase sdb;
            if (currentAmmountAddingStation <= amountAddingStation)
            {
                sdb = new Models.ServiceDataBase();

                sdb.AddNewStation(stationTextBox[1].Text, stationTextBox[2].Text, stationTextBox[3].Text, stationTextBox[4].Text, currentAmmountAddingStation);

                currentAmmountAddingStation++;
                stationTextBox[0].Text = currentAmmountAddingStation.ToString();
                specialTaskTextBox[0].Text = currentAmmountAddingSpecialTask.ToString();

                for (int i = 1; i < stationHeader.Length; i++)
                {
                    stationTextBox[i].Text = "";
                }
            }
            if (currentAmmountAddingStation > amountAddingStation)
            {
                EnabledAdding(true);
                if(currentAmmountAddingSpecialTask > amountAddingSpecialTask)
                {
                    Finish();
                }
            }
            SaveData();
        }


        private void AddSpecialTaskButton_Click(object sender, EventArgs e)
        {
            LoadData();
            Models.ServiceDataBase sdb;
            if (currentAmmountAddingSpecialTask <= amountAddingSpecialTask)
            {
                if (Validation.isNumber(specialTaskTextBox[4].Text) && Validation.isNumber(specialTaskTextBox[3].Text))
                {
                    sdb = new Models.ServiceDataBase();

                    if (sdb.AddNewSpecialTask(specialTaskTextBox[2].Text, Convert.ToInt32(specialTaskTextBox[3].Text), Convert.ToInt32(specialTaskTextBox[4].Text), specialTaskTextBox[1].Text, currentAmmountAddingSpecialTask))
                    {
                        currentAmmountAddingSpecialTask++;
                        stationTextBox[0].Text = currentAmmountAddingStation.ToString();
                        specialTaskTextBox[0].Text = currentAmmountAddingSpecialTask.ToString();

                        for (int i = 1; i < specialTaskHeader.Length; i++)
                        {
                            specialTaskTextBox[i].Text = "";
                        }
                    }
                }
            }
            if (currentAmmountAddingSpecialTask > amountAddingSpecialTask)
            {
                EnabledAdding(false);
                if (currentAmmountAddingStation > amountAddingStation)
                {
                    Finish();
                }
            }
            SaveData();
        }
    

        private void EnabledAdding(bool station)
        {
            if (station)
            {
                for (int i = 1; i < stationHeader.Length; i++)
                {
                    stationTextBox[i].Enabled = false;
                }
                addStationButton.Enabled = false;
            }
            else
            {
                for (int i = 1; i < specialTaskHeader.Length; i++)
                {
                    specialTaskTextBox[i].Enabled = false;
                }
                addSpecialTaskButton.Enabled = false;
            }
        }

        private void UnEnabledAdding()
        {
            for (int i = 1; i < specialTaskHeader.Length; i++)
            {
                specialTaskTextBox[i].Enabled = true;
            }
            for (int i = 1; i < stationHeader.Length; i++)
            {
                stationTextBox[i].Enabled = true;
            }
            addSpecialTaskButton.Enabled = true;
            addStationButton.Enabled = true;
        }

        private Label GenereteLabel(string text)
        {
            Label label = new Label()
            {
                Text = text
            };
            return label;
        }

        private TextBox GenereteTextBox(string text, int width, int height, int maxSize)
        {
            TextBox textBox = new TextBox()
            {
                Text = text,
                Width = width,
                Height = height,
                MaxLength = maxSize,
                Enabled = false
            };
            return textBox;
        }

        private void Finish()
        {
            finishButton.Enabled = true;
        }


        private void FinishButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("Managment.aspx");
        }
    }
}