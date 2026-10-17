namespace Borodin
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private System.Windows.Forms.BindingSource rolesBindingSource;
        private System.Windows.Forms.BindingNavigator usersBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton usersBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.TextBox idTextBox, loginTextBox, passwordTextBox, first_NameTextBox;
        private System.Windows.Forms.ComboBox role_NameComboBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            usersBindingSource = new System.Windows.Forms.BindingSource(components);
            rolesBindingSource = new System.Windows.Forms.BindingSource(components);
            usersBindingNavigator = new System.Windows.Forms.BindingNavigator(components);
            bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton("Добавить");
            bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton("Удалить");
            usersBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton("Сохранить");
            dataGridViewUsers = new System.Windows.Forms.DataGridView();
            idTextBox = new System.Windows.Forms.TextBox(); loginTextBox = new System.Windows.Forms.TextBox();
            passwordTextBox = new System.Windows.Forms.TextBox(); first_NameTextBox = new System.Windows.Forms.TextBox();
            role_NameComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(rolesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(usersBindingNavigator)).BeginInit();
            usersBindingNavigator.SuspendLayout(); ((System.ComponentModel.ISupportInitialize)(dataGridViewUsers)).BeginInit(); SuspendLayout();
            usersBindingNavigator.AddNewItem = bindingNavigatorAddNewItem;
            usersBindingNavigator.DeleteItem = bindingNavigatorDeleteItem;
            usersBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { bindingNavigatorAddNewItem, bindingNavigatorDeleteItem, usersBindingNavigatorSaveItem });
            usersBindingNavigator.Location = new System.Drawing.Point(0, 0); usersBindingNavigator.Name = "usersBindingNavigator"; usersBindingNavigator.Size = new System.Drawing.Size(784, 25);
            bindingNavigatorAddNewItem.Click += bindingNavigatorAddNewItem_Click;
            bindingNavigatorDeleteItem.Click += bindingNavigatorDeleteItem_Click;
            usersBindingNavigatorSaveItem.Click += usersBindingNavigatorSaveItem_Click;
            dataGridViewUsers.AutoGenerateColumns = true; dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.DataSource = usersBindingSource; dataGridViewUsers.Location = new System.Drawing.Point(12, 40); dataGridViewUsers.Name = "dataGridViewUsers"; dataGridViewUsers.Size = new System.Drawing.Size(760, 220);
            int left = 105; string[] labels = { "ID", "Логин", "Пароль", "Имя", "Роль" }; System.Windows.Forms.Control[] inputs = { idTextBox, loginTextBox, passwordTextBox, first_NameTextBox, role_NameComboBox };
            for (int i = 0; i < inputs.Length; i++) { var label = new System.Windows.Forms.Label { Text = labels[i], Location = new System.Drawing.Point(12, 280 + i * 32), AutoSize = true }; Controls.Add(label); inputs[i].Location = new System.Drawing.Point(left, 276 + i * 32); inputs[i].Size = new System.Drawing.Size(230, 23); Controls.Add(inputs[i]); }
            idTextBox.ReadOnly = true; idTextBox.DataBindings.Add("Text", usersBindingSource, "ID", true);
            loginTextBox.DataBindings.Add("Text", usersBindingSource, "Login", true);
            passwordTextBox.DataBindings.Add("Text", usersBindingSource, "Password", true);
            first_NameTextBox.DataBindings.Add("Text", usersBindingSource, "First_Name", true);
            role_NameComboBox.DataBindings.Add("SelectedValue", usersBindingSource, "Role_Name", true);
            role_NameComboBox.DataSource = rolesBindingSource; role_NameComboBox.DisplayMember = "Name"; role_NameComboBox.ValueMember = "Name"; role_NameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 460); Controls.Add(dataGridViewUsers); Controls.Add(usersBindingNavigator); Name = "Form1"; Text = "Пользователи"; Load += Form1_Load;
            usersBindingNavigator.ResumeLayout(false); usersBindingNavigator.PerformLayout(); ((System.ComponentModel.ISupportInitialize)(dataGridViewUsers)).EndInit(); ResumeLayout(false); PerformLayout();
        }
    }
}
