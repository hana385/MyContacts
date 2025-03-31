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
    public partial class frmAddOrEdit : Form
    {
        IContactsresponsitory respository;
        public int contactId = 0;
        public frmAddOrEdit()
        {
            InitializeComponent();
            respository = new ContactsRepository();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        bool ValidateInouts()
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("لطفا نام خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("لطفا نام و نام خانوادگی  خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("لطفا موبایل  خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numericUpDown1.Value==0)
            {
                MessageBox.Show("لطفا سن  خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("لطفا  آدرس  خود را وارد کنید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInouts())
            {
                bool isSuccess;
                if(contactId==0)
                {
                    isSuccess = respository.Insert(textBox1.Text, textBox2.Text, (int)numericUpDown1.Value, textBox3.Text, textBox4.Text);
                }
                else
                {
                    isSuccess = respository.Update(contactId,textBox1.Text, textBox2.Text, (int)numericUpDown1.Value, textBox3.Text, textBox4.Text);
                }

                if (isSuccess == true)
                {
                    MessageBox.Show("عملیات با موفقیت ثبت شد ", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجهه شد ", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص جدید";
            }
            else //زمانی صفر نیست که حالت ویرایش باشه.
            {
                this.Text = "ویرایش شخص ";
                DataTable dt = respository.selectrow(contactId); //باید متد را صدا بزنه
                                                                 //datatableنتیجه چی بود ؟ 
                textBox1.Text = dt.Rows[0][1].ToString();
                textBox2.Text = dt.Rows[0][2].ToString(); //یدونه خط بیشتر نداره که شماره خونه اون 0 هست چرا؟چون ما تو کلاس کانتکتمون اومدیم .whereگذاشتیم 
                                                          // و اونی که کانتکت ایدیش (contactId)این هست 
                                                          //و این هم به عنوان کلید اصلی ما معرفی شده
                numericUpDown1.Text = dt.Rows[0][3].ToString();

                textBox3.Text = dt.Rows[0][4].ToString();  
                textBox4.Text = dt.Rows[0][5].ToString();
                button1.Text = "ویرایش ";


            }
            
        }

    }
}
