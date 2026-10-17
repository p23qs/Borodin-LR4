using System; using System.Data.Entity; using System.Windows.Forms;
namespace Borodin
{
 public class Form1:Form
 {
  ModelEF db; readonly BindingSource usersBindingSource=new BindingSource(); readonly BindingSource rolesBindingSource=new BindingSource();
  readonly DataGridView grid=new DataGridView(); readonly TextBox id=new TextBox(), login=new TextBox(), password=new TextBox(), firstName=new TextBox(); readonly ComboBox role=new ComboBox();
  public Form1(){ Text="Пользователи"; Width=800; Height=500; BuildUi(); Load+=FormLoad; }
  void BuildUi(){ var nav=new BindingNavigator(usersBindingSource){Dock=DockStyle.Top}; var add=new ToolStripButton("Добавить"); var del=new ToolStripButton("Удалить"); var save=new ToolStripButton("Сохранить"); nav.AddNewItem=add; nav.DeleteItem=del; nav.Items.AddRange(new ToolStripItem[]{add,del,save}); Controls.Add(nav); grid.Dock=DockStyle.Top; grid.Height=220; grid.AutoGenerateColumns=true; grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill; grid.DataSource=usersBindingSource; Controls.Add(grid); var panel=new TableLayoutPanel{Top=250,Left=12,Width=340,Height=160,ColumnCount=2,RowCount=5}; panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,75)); panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100)); string[] labels={"ID","Логин","Пароль","Имя","Роль"}; Control[] fields={id,login,password,firstName,role}; for(int i=0;i<5;i++){panel.Controls.Add(new Label{Text=labels[i],AutoSize=true},0,i); fields[i].Dock=DockStyle.Fill;panel.Controls.Add(fields[i],1,i);} id.ReadOnly=true; role.DropDownStyle=ComboBoxStyle.DropDownList; Controls.Add(panel); add.Click+=(s,e)=>{BeginInvoke(new Action(()=>role.SelectedIndex=0));}; save.Click+=(s,e)=>SaveData(); }
  void FormLoad(object s,EventArgs e){try{StartLoadData();}catch(Exception ex){MessageBox.Show(ex.ToString(),"Ошибка подключения");}}
  void StartLoadData(){db=new ModelEF(); db.Roles.Load(); db.Users.Load(); rolesBindingSource.DataSource=db.Roles.Local.ToBindingList(); role.DataSource=rolesBindingSource; role.DisplayMember="Name"; role.ValueMember="Name"; usersBindingSource.DataSource=db.Users.Local.ToBindingList(); BindFields(); grid.DataSource=usersBindingSource; if(grid.Columns["Roles"]!=null)grid.Columns["Roles"].Visible=false;}
  void BindFields(){id.DataBindings.Clear();login.DataBindings.Clear();password.DataBindings.Clear();firstName.DataBindings.Clear();role.DataBindings.Clear(); id.DataBindings.Add("Text",usersBindingSource,"ID",true); login.DataBindings.Add("Text",usersBindingSource,"Login",true); password.DataBindings.Add("Text",usersBindingSource,"Password",true); firstName.DataBindings.Add("Text",usersBindingSource,"First_Name",true); role.DataBindings.Add("SelectedValue",usersBindingSource,"Role_Name",true);}
  void SaveData(){try{Validate();usersBindingSource.EndEdit();db.SaveChanges();MessageBox.Show("Данные сохранены.","Пользователи");}catch(Exception ex){MessageBox.Show(ex.ToString(),"Ошибка сохранения");}}
  protected override void Dispose(bool d){if(d)db?.Dispose();base.Dispose(d);}
 }
}
