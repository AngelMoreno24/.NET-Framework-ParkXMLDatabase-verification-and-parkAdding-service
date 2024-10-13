using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            //creates an object of verification
            verification.Service1Client verification = new verification.Service1Client();

            //create string to hold output
            string output = "";

            try
            {
                //performs the service on the user given string and stores it into a string called output
                output = verification.Verification(TextBox2.Text.ToString(), TextBox1.Text.ToString());

            }catch (Exception ex) { 
            }
            

            //displays wheth or not there was an error
            Label6.Text = output.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //checks if theh required fields are filled
            if (TextBox3.Text != "" || TextBox5.Text != "" || TextBox6.Text != "" || TextBox7.Text != "" || TextBox8.Text != "" || TextBox9.Text != "" || TextBox10.Text != "")
            {
                //creates an object of addPark
                addPark.Service1Client addPark = new addPark.Service1Client();

                //create string to hold output
                string output;

                //performs the service on the user given string and stores it into a string called output
                output = addPark.AddPark(TextBox3.Text.ToString(), TextBox5.Text.ToString(), TextBox6.Text.ToString(), TextBox7.Text.ToString(), TextBox8.Text.ToString(), TextBox9.Text.ToString(), TextBox10.Text.ToString(), TextBox4.Text.ToString());

                try
                {
                    //displays the parl xml info
                    TextBox11.Text = output.ToString();
                }
                catch (Exception ex)
                {

                }


            }
            else
            {
                //asks the user to add all required info
                Label12.Text = "Please enter all required information(all but founder)";
            }
        }
    }
}