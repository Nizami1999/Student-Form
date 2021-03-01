using HomeForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeForm
{
    public partial class Form1 : Form
    {
        private Dictionary<uint, Student> students;
        private List<string> items = new List<string>
        {
            "Id", "First name", "Last name", "Age", "Group", "Specification"
        };
        public Form1()
        {
            InitializeComponent();
            students = new Dictionary<uint, Student>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbGroup.Items.Add("674.7E");
            cmbGroup.Items.Add("272.2E");
            cmbGroup.Items.Add("415.3E");
            cmbGroup.Items.Add("484.4R");
            cmbGroup.Items.Add("574.9A");

            nmAge.Minimum = 15;
            nmAge.Maximum = byte.MaxValue;

            dgvTable.ColumnCount = 6;
            for (int i = 0; i < items.Count; i++)
            {
                dgvTable.Columns[i].HeaderText = items[i];
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //add values from form control
            string firstName = txtFirstName.Text;
            string surname = txtSurname.Text;
            string group = cmbGroup.Text;
            string spec = txtSpec.Text;
            byte age = Convert.ToByte(nmAge.Value);

            //validation
            if (firstName.Length < 3 ||
                surname.Length < 3 ||
                String.IsNullOrEmpty(group) ||
                String.IsNullOrEmpty(spec))
            {
                MessageBox.Show("Check your values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateSelectionStudents();
            }
            else
            {
                //create student
                Student student = new Student(firstName, surname, group, spec, age);
                students.Add(student.ID, student);

                //clear values in form
                ClearAddStudent();

                //update students in selection section
                UpdateSelectionStudents();

                //success proof
                MessageBox.Show("Student was successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ClearAddStudent()
        {
            txtFirstName.Text = String.Empty;
            txtSurname.Text = String.Empty;
            cmbGroup.SelectedIndex = 0;
            txtSpec.Text = String.Empty;
            nmAge.Value = nmAge.Minimum;
        }
        private void UpdateSelectionStudents()
        {
            // updates for control
            cmbRemovedStudent.Items.Clear(); // ust uste duwmesin diye
            foreach (Student student in students.Values)
            {
                cmbRemovedStudent.Items.Add(student.ID);
            }
            lblRemovedStudent.Text = String.Empty;

            //updates for table
            dgvTable.Rows.Clear();
            foreach (Student student in students.Values)
            {
                dgvTable.Rows.Add(student.ID, student.FirstName, student.LastName, student.Age, student.GroupName, student.Specification);
            };
        }
        private void cmbRemovedStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint Id = Convert.ToUInt32(cmbRemovedStudent.Text);
            Student st = students[Id];

            lblRemovedStudent.Text = st.ToString();
            lblRemovedStudent.Visible = true;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbRemovedStudent.Text))
            {
                uint Id = Convert.ToUInt32(cmbRemovedStudent.Text);
                students.Remove(Id);
                UpdateSelectionStudents();
                MessageBox.Show("Student was successfully removed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Select the student, who will be removed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
