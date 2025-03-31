using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
        IContactsresponsitory responsity; //حالا ما میتونیم ار قوانینی که تعیین کرده بودیم اینجا استفاده کنیم .

        public Form1()
        {
            InitializeComponent();
            responsity = new ContactsRepository();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = responsity.selectAll();
         //   dataGridView1.Columns[0].Visible = false; برای مشاهده نکردن سلول اول است
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit();
            frm.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                BindGrid();              //این رو نشون بده.
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string familly = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                
                string fullname = string.Format("ایا از حذف اطلاعات {1} {0} مطمین هستید ؟ ",name,familly);

                if(MessageBox.Show(fullname,"توجه",MessageBoxButtons.YesNo)==DialogResult.Yes);
                {
                    int contactId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    responsity.Delete(contactId);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("لطفا ابتدا ردیف مورد نظر یا شخص مورد نظر را انتخاب کنید .", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int contactId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                frmAddOrEdit frm = new frmAddOrEdit(); // این فرمه باید باز شه // چجوری میتونم ایدی را به اون فرم بفرستیم
                frm.contactId = contactId;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }

            }
            else 
            {
                MessageBox.Show("لطفا ابتدا ردیف مورد نظر یا شخص مورد نظر را انتخاب کنید .", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
             
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = responsity.Search(txtsearch.Text);
        }
    }
}
