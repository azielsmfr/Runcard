using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RunCard.Classes;

namespace RunCard
{
    public partial class Runcard : Form
    {
        private static List<AddressModel> _stationsgb;
        public Runcard()
        {
            InitializeComponent();
        }          
        private void Runcard_Load(object sender, EventArgs e)
        {
            //SearchAddress();
            //List<AddressModel> stations = DataAccess.GetAllLocations();
            ResetGrid();

            CenterTopControl(Header);
            CenterBottomControl(Footer);
            CenterControlHorizontal(Title);
            CenterControlHorizontal(SearchPanel);

        }

        private void ResetGrid()
        {
            _stationsgb = DataAccess.GetAllLocations();
            LocationsGrid.DataSource = _stationsgb;
            ItemsNumber.Text = _stationsgb.Count.ToString();

        }


        private void Runcard_Resize(object sender, EventArgs e)
        {
            CenterTopControl(Header);
            CenterBottomControl(Footer);
        }
        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchAddress();
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
           
            SearchAddress();
        }

       


        private void SearchAddress() {
            try
            {
                
                string street  = StreetTextBox.Text;
                string number  = NumberTextBox.Text;

                List<AddressModel>  stations = _stationsgb;
                List<AddressModel> newstations = new List<AddressModel>();

                newstations = stations;


                if (!String.IsNullOrEmpty(number)) { 
                   newstations = stations.Where(item => item.Location.ToUpper().Contains(number.ToUpper())).ToList();
                }

                if (!String.IsNullOrEmpty(street))
                {
                    if (newstations.Count > 0)
                    {
                        newstations = newstations.Where(item => item.Location.ToUpper().Contains(street.ToUpper())).ToList();
                    }
                    else {
                        newstations = stations.Where(item => item.Location.ToUpper().Contains(street.ToUpper())).ToList();
                    }

                }                

              //  if (!String.IsNullOrEmpty(street) && !String.IsNullOrEmpty(number))

                    LocationsGrid.DataSource = newstations.ToList();     

                ItemsNumber.Text = newstations.Count.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CenterControlHorizontal(Control ctrlToCenter)
        {
            ctrlToCenter.Left = (ctrlToCenter.Parent.Width - ctrlToCenter.Width) / 2;
            //ctrlToCenter.Top = 5;
        }

        private void CenterTopControl(Control ctrlToCenter)
        {
            ctrlToCenter.Left = (ctrlToCenter.Parent.Width - ctrlToCenter.Width) / 2;
            ctrlToCenter.Top = 5;
        }

        private void CenterBottomControl(Control ctrlToCenter)
        {
            ctrlToCenter.Left = (ctrlToCenter.Parent.Width - ctrlToCenter.Width) / 2;
            ctrlToCenter.Top = (ctrlToCenter.Parent.Height - ctrlToCenter.Height) -45;
        }

        private void ClearBoxes_Click(object sender, EventArgs e)
        {
            NumberTextBox.Clear();
            StreetTextBox.Clear();


        }
    }
}
    

