using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Party_Planner
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;
        BirthdayParty birthdayParty;

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost(checkBox2.Checked); //healthy option is checked.
            labelCost.Text = Cost.ToString("c"); //passing c tells it to use local currency value. Can also use f3
        }
        public Form1()
        {
            InitializeComponent();

            //dinnerParty = new DinnerParty(); // { NumberOfPeople = 5 };
            //dinnerParty.SetPartyOptions(5, checkBox1.Checked);
            //dinnerParty.SetHealthyOption(checkBox2.Checked);
            //dinnerParty.CalculateCostOfDecorations(checkBox1.Checked);

            dinnerParty = new DinnerParty((int)numericUpDown1.Value, checkBox2.Checked, checkBox1.Checked);

            DisplayDinnerPartyCost();

            birthdayParty = new BirthdayParty((int)numberBirthday.Value, fancyBirthday.Checked, cakeWriting.Text);
            DisplayBirthdayPartyCost();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //dinnerParty.numberOfPeople = (int)numericUpDown1.Value; //casting numericUpdown1.value because it is a decimal
            dinnerParty.SetPartyOptions((int)numericUpDown1.Value, checkBox1.Checked);
            DisplayDinnerPartyCost();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.CalculateCostOfDecorations(checkBox1.Checked);
            DisplayDinnerPartyCost(); //recalculates and displays new dinner party cost.
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.SetHealthyOption(checkBox2.Checked);
            DisplayDinnerPartyCost();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numberBirthday_ValueChanged(object sender, EventArgs e)
        {
            birthdayParty.NumberOfPeople = (int)numberBirthday.Value;
            DisplayBirthdayPartyCost();
        }

        private void fancyBirthday_CheckedChanged(object sender, EventArgs e)
        {
            birthdayParty.CalculateCostOfDecorations(fancyBirthday.Checked);
            DisplayBirthdayPartyCost();
        }

        private void cakeWriting_TextChanged(object sender, EventArgs e)
        {
            birthdayParty.CakeWriting = cakeWriting.Text;
            DisplayBirthdayPartyCost();
        }

        private void DisplayBirthdayPartyCost()
        {
            cakeWriting.Text = birthdayParty.CakeWriting;
            decimal cost = birthdayParty.CalculateCost();
            birthdayCost.Text = cost.ToString("c");
        }
    }
}
