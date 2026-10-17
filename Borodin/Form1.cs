using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Borodin
{
    public partial class Form1 : Form
    {
        private ModelEF context;

        public Form1()
        {
            InitializeComponent();
        }

        // Загружает данные из БД в привязанные источники формы.
        private void StartLoadData()
        {
            context = new ModelEF();
            context.Roles.Load();
            context.Users.Load();

            rolesBindingSource.DataSource = context.Roles.Local.ToBindingList();
            usersBindingSource.DataSource = context.Users.Local.ToBindingList();
        }

        // Сохраняет изменения, выполненные через BindingNavigator и DataGridView.
        private void SaveData()
        {
            Validate();
            usersBindingSource.EndEdit();
            rolesBindingSource.EndEdit();
            context.SaveChanges();
            dataGridViewUsers.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try { StartLoadData(); }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подключиться к DB_Users. Проверьте SQL Server Express и строку подключения.\n\n" + ex.Message,
                    "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try { SaveData(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            usersBindingSource.RemoveCurrent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => role_NameComboBox.SelectedIndex = role_NameComboBox.Items.Count > 0 ? 0 : -1));
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            context?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
