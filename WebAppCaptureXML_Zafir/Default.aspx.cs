using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

//Assumptions Cellphone Number Mauritian //Minimum 7 - Maximum 8

namespace WebAppCaptureXML_Zafir
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                using (DataSet ds = new DataSet())
                {
                    int rowCount = gvListPersonsRecords.Rows.Count;

                    if (rowCount == 0)
                    {
                        gvListPersonsRecords.Visible = false;
                    }
                    else
                    {
                        gvListPersonsRecords.Visible = true;

                    }

                }

            }

        }

        //Assumptions Cellphone Number Mauritian
        //Minimum 7 - Maximum 8
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Page.Validate("submitClick");
            if (Page.IsValid)
            {
                var xDoc = XDocument.Load(Server.MapPath("webAppCapture.xml"));
                var count = xDoc.Descendants("people").Count();
                var newPerson = new XElement("people",
                                  new XElement("id", count + 1),
                                  new XElement("First_Name", tbFname.Text),
                                  new XElement("Surname", tbSurname.Text),
                                  new XElement("Cellphone_Number", tbNumber.Text));
                xDoc.Root.Add(newPerson);
                xDoc.Save(Server.MapPath("webAppCapture.xml"));
                this.BindGrid();

                Response.Redirect(Request.Url.AbsoluteUri);

            }

        }
        public void clearForm()
        {
            this.tbFname.Text = string.Empty;
            this.tbSurname.Text = string.Empty;
            this.tbNumber.Text = string.Empty;
        }

        public void listPersons_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvListPersonsRecords.EditIndex = e.NewEditIndex;
            this.DataBind();
        }

        private void BindGrid()
        {
            DataSet ds = new DataSet();

            ds.ReadXml(Server.MapPath("webAppCapture.xml"));

            if (ds.Tables.Count == 0)
            {
                gvListPersonsRecords.Visible = false;
            }
            else
            {
                gvListPersonsRecords.DataSource = ds;
                gvListPersonsRecords.DataBind();
                gvListPersonsRecords.Visible = true;
            }

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvListPersonsRecords.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, EventArgs e)
        {
            gvListPersonsRecords.EditIndex = -1;
            this.BindGrid();
        }
        //Assumptions Cellphone Number Mauritian
        //Minimum 7 - Maximum 8
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvListPersonsRecords.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvListPersonsRecords.DataKeys[e.RowIndex].Values[0]);
            string fName = (row.FindControl("txtFirstName") as System.Web.UI.WebControls.TextBox).Text;
            string lName = (row.FindControl("txtSurname") as System.Web.UI.WebControls.TextBox).Text;
            int cellNumber = Convert.ToInt32((row.FindControl("txtCellphone") as System.Web.UI.WebControls.TextBox).Text);
            gvListPersonsRecords.EditIndex = -1;
            var xDoc = XDocument.Load(Server.MapPath("webAppCapture.xml"));
            foreach (XElement xe in xDoc.Descendants("people"))
            {
                if (Convert.ToInt32(xe.Element("id").Value) == id)
                {
                    xe.Element("First_Name").Value = fName;
                    xe.Element("Surname").Value = lName;
                    xe.Element("Cellphone_Number").Value = cellNumber.ToString();
                }
            }
            xDoc.Save(Server.MapPath("webAppCapture.xml"));
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("webAppCapture.xml"));
            gvListPersonsRecords.DataSource = ds;
            gvListPersonsRecords.DataBind();      

        }


        protected void XmlGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gvListPersonsRecords.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvListPersonsRecords.DataKeys[e.RowIndex].Values[0]);
            var xDoc = XDocument.Load(Server.MapPath("webAppCapture.xml"));

            xDoc.Descendants("people")
             .Where(x => x.Element("id").Value == id.ToString())
             .Remove();

            xDoc.Save(Server.MapPath("webAppCapture.xml"));
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("webAppCapture.xml"));
            gvListPersonsRecords.DataSource = ds;
            //if no xml node exist, empty gridview
            bool Elementexist=  xDoc.Descendants("people").Any();
            if(Elementexist==true)
            {
                this.DataBind();
            }
            else
            {
                gvListPersonsRecords.DataSource = null;
                this.DataBind();
            }

        }
    }
}