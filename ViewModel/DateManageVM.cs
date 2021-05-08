using MyStaffWpf2.Model;
using MyStaffWpf2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyStaffWpf2.ViewModel
{
    public class DateManageVM : INotifyPropertyChanged
    {

        // свойство отдела
        public string DepartmentName { get; set; }

        // свойство должностей

        public string PositionName { get; set; }

        public Department PositionDepartment { get; set; }

        #region СВОЙСТВА СОТРУДНИКОВ

        public string StaffId { get; set; }

        public string StaffLastName { get; set; }

        public string StaffFirstName { get; set; }

        public string StaffMiddleName { get; set; }

        public Position StaffPosition { get; set; }

        public string StaffDateOfBrith { get; set; }

        public string StaffPhone { get; set; }

        public string StaffEmail { get; set; }

        #endregion

        #region ДЛЯ ВЫДЕЛЕННЫХ

        public static Department SelectedDepartment { get; set; }

        public static Position SelectedPosition { get; set; }

        public static Staff SelectedStaff { get; set; }

        #endregion

        #region ДЛЯ РЕДАКТИРОВАНИЯ

        public static string OldNameDepartment
        {
            get
            {
                return DataWorker.findDepartmentById(SelectedDepartment.Id).Name;
            }
        }

        private static string newNameDepartment;

        public static string NewNameDepartment 
        {
            get
            {
                return DataWorker.findDepartmentById(SelectedDepartment.Id).Name;
            }

            set
            {
                newNameDepartment = value;
                DataWorker.EditDepartment(SelectedDepartment, value);
            }
        }

        private static string newNamePosition;

        public static string NewNamePosition 
        {
            get
            {
                return DataWorker.findPositionById(SelectedPosition.Id).Name;
            }

            set
            {
                newNamePosition = value;
                DataWorker.EditPosition(SelectedPosition, value, NewDepartment);
            }
        }

        public static Department NewDepartment { get; set; }



        private static string newStaffLastName;

        public static string NewStaffLastName 
        {
            get
            {
                return DataWorker.findStaffById(SelectedStaff.Id).LastName;
            }

            set
            {
                newStaffLastName = value;
                DataWorker.EditStaff(
                    SelectedStaff,
                    value,
                    NewStaffFirstName,
                    NewStaffMiddleName,
                    DataWorker.findPositionById(DataWorker.findStaffById(SelectedStaff.Id).PositionId),
                    NewStaffDateOfBrith,
                    NewStaffPhone,
                    NewStaffEmail);  
            }
        }

        private static string newStaffFirstName;

        public static string NewStaffFirstName 
        {
            get
            {
                return DataWorker.findStaffById(SelectedStaff.Id).FirstName;
            }

            set
            {
                newStaffFirstName = value;
                DataWorker.EditStaff(
                    SelectedStaff,
                    NewStaffLastName,
                    value,
                    NewStaffMiddleName,
                    NewStaffPosition,
                    NewStaffDateOfBrith,
                    NewStaffPhone,
                    NewStaffEmail
                    );          
            }
        }

        private static string newStaffMiddleName;

        public static string NewStaffMiddleName 
        {
            get
            {
                return DataWorker.findStaffById(SelectedStaff.Id).MiddleName;
            }

            set
            {
                newStaffMiddleName = value;
                DataWorker.EditStaff(
                    SelectedStaff,
                    NewStaffFirstName,
                    NewStaffFirstName,
                    value,
                    NewStaffPosition,
                    NewStaffDateOfBrith,
                    NewStaffPhone,
                    NewStaffEmail
                    );          
            }
        }

        public static Position NewStaffPosition { get; set; }

        private static string newStaffDateOfBrith;

        public static string NewStaffDateOfBrith 
        {
            get
            {
                return DataWorker.findStaffById(SelectedStaff.Id).DateOfBrith;
            }

            set
            {
                newStaffDateOfBrith = value;
                DataWorker.EditStaff(
                    SelectedStaff,
                    NewStaffLastName,
                    NewStaffFirstName,
                    NewStaffMiddleName,
                    NewStaffPosition,
                    value,
                    NewStaffPhone,
                    NewStaffEmail
                    );          
            }
        }

        private static string newStaffPhone;

        public static string NewStaffPhone 
        {
            get
            {
                return DataWorker.findStaffById(SelectedStaff.Id).Phone;
            }

            set
            {
                newStaffPhone = value;
                DataWorker.EditStaff(
                    SelectedStaff,
                    NewStaffLastName,
                    NewStaffFirstName,
                    NewStaffMiddleName,
                    NewStaffPosition,
                    NewStaffDateOfBrith,
                    value,
                    NewStaffEmail
                    );          
            }
        }

        private static string newStaffEmail;

        public static string NewStaffEmail 
        {
            get
            {
                return DataWorker.findStaffById(SelectedStaff.Id).Email;
            }

            set
            {
                newStaffEmail = value;
                DataWorker.EditStaff(
                    SelectedStaff,
                    NewStaffLastName,
                    NewStaffFirstName,
                    NewStaffMiddleName,
                    NewStaffPosition,
                    NewStaffDateOfBrith,
                    NewStaffPhone,
                    value
                    );                  
            }
        }

        #endregion

        #region ДЛЯ ФИЛЬТРАЦИИ
        public string FilterLastNameText { get; set; }

        public string FilterFirstNameText { get; set; }

        public string FilterMiddleNameText { get; set; }
        #endregion

        #region ДЛЯ ВСЕХ ПОЛНЫХ СПИСКОВ
        private List<Department> allDepartments = DataWorker.findAllDepartments();

        public List<Department> AllDepartments
        {
            get
            {
                return allDepartments;
            }
            set
            {
                allDepartments = value;
                NotifyPropertyChanged("AllDepartments");
            }
        }

        private List<Position> allPositions = DataWorker.findAllPositions();

        public List<Position> AllPositions
        {
            get
            {
                return allPositions;
            }
            set
            {
                allPositions = value;
                NotifyPropertyChanged("AllPositions");
            }
        }

        private List<Staff> allStaffs = DataWorker.findAllStaffs();

        public List<Staff> AllStaffs
        {
            get
            {
                return allStaffs;
            }

            set
            {
                allStaffs = value;
                NotifyPropertyChanged("AllStaffs");
            }
        }
        #endregion

        #region WINDOWS WORK
        #region WINDOWS LIST
        // открытия окон списков
        private void DepartmentWindowList()
        {
            DepartmentWindow newDepartmentWindow = new DepartmentWindow();
            newDepartmentWindow.Show();
            
        }

        private void PositionWindowList()
        {
            PositionWindow newPositionWindow = new PositionWindow();
            newPositionWindow.Show();
        }

        private void StaffWindowList()
        {
            StaffWindow newStaffWindow = new StaffWindow();
            newStaffWindow.Show();
        }
        #endregion

        #region WINDOWS ADD
        // открытия окон добавления
        private void AddDepartmentWindow()
        {
            AddNewDepartmentWindow newAddDepartmentWindow = new AddNewDepartmentWindow();
            SetCurrentPositionAndOpenWindow(newAddDepartmentWindow);
        }

        private void AddPositionWindow()
        {
            AddNewPositionWindow newAddPositionWindow = new AddNewPositionWindow();
            SetCurrentPositionAndOpenWindow(newAddPositionWindow);
        }

        private void AddStaffWindow()
        {
            AddNewStaffWindow newAddStaffWindow = new AddNewStaffWindow();
            SetCurrentPositionAndOpenWindow(newAddStaffWindow);
        }
        #endregion

        #region WINDOW EDIT
        private void EditDepartmentWindow()
        {
            EditDepartmentWindow newEditDepartmentWindow = new EditDepartmentWindow();
            SetCurrentPositionAndOpenWindow(newEditDepartmentWindow);
        }

        private void EditPositionWindow()
        {
            EditPositionWindow newEditPositionWindow = new EditPositionWindow();
            SetCurrentPositionAndOpenWindow(newEditPositionWindow);
        }

        private void EditStaffWindow()
        {
            EditStaffWindow newEditStaffWindow = new EditStaffWindow();
            SetCurrentPositionAndOpenWindow(newEditStaffWindow);
        }

        #endregion

        private void SetCurrentPositionAndOpenWindow(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        #endregion


        #region COMMAND OPEN ADD EDIT WINDOWS

        #region OPEN
        private RelayCommand departmentWnd;

        public RelayCommand DepartmentWnd
        {
            get
            {
                return departmentWnd ?? new RelayCommand(obj =>
                {
                    DepartmentWindowList();
                });
            }
        }

        private RelayCommand positionWnd;

        public RelayCommand PositionWnd
        {
            get
            {
                return positionWnd ?? new RelayCommand(obj =>
                {
                    PositionWindowList();
                });
            }
        }

        private RelayCommand staffWnd;

        public RelayCommand StaffWnd
        {
            get
            {
                return staffWnd ?? new RelayCommand(obj =>
                {
                    StaffWindowList();
                });
            }
        }
        #endregion

        #region ADD
        private RelayCommand addNewDepartmentWnd;

        public RelayCommand AddNewDepartmentWnd
        {
            get
            {
                return addNewDepartmentWnd ?? new RelayCommand(obj =>
                {
                    AddDepartmentWindow();
                });
            }
        }

        private RelayCommand addNewPositionWnd;

        public RelayCommand AddNewPositionWnd
        {
            get
            {
                return addNewPositionWnd ?? new RelayCommand(obj =>
                {
                    AddPositionWindow();
                });
            }
        }

        private RelayCommand addNewStaffWnd;

        public RelayCommand AddNewStaffWnd
        {
            get
            {
                return addNewStaffWnd ?? new RelayCommand(obj =>
                {
                    AddStaffWindow();
                });
            }
        }
        #endregion

        #region EDIT
        private RelayCommand editDepartmentWnd;

        public RelayCommand EditDepartmentWnd
        {
            get
            {
                return editDepartmentWnd ?? new RelayCommand(obj =>
                {
                    string result = "Выберите для редактирования";
                    if(SelectedDepartment != null)
                    {
                        EditDepartmentWindow();
                    } else
                    {
                        MessageBox.Show(result);
                    }
                });
            }
        }

        private RelayCommand editPositionWnd;

        public RelayCommand EditPositionWnd
        {
            get
            {
                return editPositionWnd ?? new RelayCommand(obj =>
                {
                    string result = "Выберите для редактирования";
                    if (SelectedPosition != null)
                    {
                        NewDepartment = DataWorker.findDepartmentById(DataWorker.findPositionById(SelectedPosition.Id).DepartmentId);
                        EditPositionWindow();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                });
            }
        }

        private RelayCommand editStaffWnd;

        public RelayCommand EditStaffWnd
        {
            get
            {
                return editStaffWnd ?? new RelayCommand(obj =>
                {
                    string result = "Выберите для редактирования";
                    if (SelectedStaff != null)
                    {
                        NewStaffPosition = DataWorker.findPositionById(DataWorker.findStaffById(SelectedStaff.Id).PositionId);
                        EditStaffWindow();
                    }
                    else
                    {
                        MessageBox.Show(result);
                    }
                });
            }
        }
        #endregion

        #endregion

        #region COMMAND ADD DB

        private RelayCommand addDepartment;

        public RelayCommand AddDepartment
        {
            get
            {
                return addDepartment ?? new RelayCommand(obj =>
                {
                    string result = "";
                    Window window = obj as Window;
                    if(DepartmentName == null || DepartmentName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "departmentNameBox");
                    } else
                    {
                        result = DataWorker.CreateDepartment(DepartmentName);
                        ShowMessage(result);
                        updateAllDepartmentsView();
                        window.Close();
                    }
                });
            }
        }

        private RelayCommand addPosition;

        public RelayCommand AddPosition
        {
            get
            {
                return addPosition ?? new RelayCommand(obj =>
                {
                    string result = "";
                    Window window = obj as Window;
                    if (PositionName == null || PositionName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "positionNameBox");
                    }
                    if(PositionDepartment == null)
                    {
                        MessageBox.Show("Выбирите отдел!");
                    }
                    else
                    {
                        result = DataWorker.CreatePosition(PositionName, PositionDepartment);
                        updateAllPositionsView();
                        ShowMessage(result);
                        window.Close();
                    }
                });
            }
        }

        private RelayCommand addStaff;

        public RelayCommand AddStaff
        {
            get
            {
                return addPosition ?? new RelayCommand(obj =>
                {
                    string result = "";
                    Window window = obj as Window;
                    if (StaffLastName == null || StaffLastName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "lastNameBox");
                    }
                    if (StaffFirstName == null || StaffFirstName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "firstNameBox");
                    }
                    if (StaffMiddleName == null || StaffMiddleName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "middleNameBox");
                    }
                    if (StaffPosition == null)
                    {
                        MessageBox.Show("Выбирите отдел!");
                    }
                    if (StaffDateOfBrith == null || StaffDateOfBrith.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "dateOfBrithBox");
                    }
                    if (StaffPhone == null || StaffPhone.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "phoneBox");
                    }
                    if (StaffEmail == null || StaffEmail.Replace(" ", "").Length == 0)
                    {
                        SetRedBlock(window, "emailBox");
                    }
                    else
                    {
                        result = DataWorker.CreateStaff(
                            StaffLastName,
                            StaffFirstName,
                            StaffMiddleName,
                            StaffPosition,
                            StaffDateOfBrith,
                            StaffPhone,
                            StaffEmail
                            );
                        ShowMessage(result);
                        window.Close();
                        updateAllStaffsView();
                    }
                });
            }
        }

        #endregion

        #region DELETE DB
        private RelayCommand deleteItem;

        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string result = "Выбирите для удаления";
                    if(SelectedDepartment != null)
                    {
                        result = DataWorker.DeleteDepartment(SelectedDepartment);
                        updateAllDepartmentsView();
                    }
                    if(SelectedPosition != null)
                    {
                        result = DataWorker.DeletePosition(SelectedPosition);
                        updateAllPositionsView();
                    }
                    if(SelectedStaff != null)
                    {
                        result = DataWorker.DeleteStuff(SelectedStaff);
                        updateAllStaffsView();
                    } else
                    {
                        MessageBox.Show(result);
                    }
                });
            }
        }
        #endregion

        #region EDIT DB
        private RelayCommand editItem;

        public RelayCommand EditItem
        {
            get
            {
                return editItem ?? new RelayCommand(obj =>
                {
                    string result = "Выберите для редактирования";

                    Window window = obj as Window;

                    if(SelectedDepartment != null)
                    {
                        if (NewNameDepartment == null || NewNameDepartment.Replace(" ", "").Length == 0)
                        {
                            result = DataWorker.EditDepartment(SelectedDepartment, OldNameDepartment);
                            updateAllDepartmentsView();
                            window.Close();
                        } else
                        {
                            result = DataWorker.EditDepartment(SelectedDepartment, NewNameDepartment);
                            updateAllDepartmentsView();
                            window.Close();
                        }
                    }

                    if(SelectedPosition != null)
                    {
                        result = DataWorker.EditPosition(SelectedPosition, NewNamePosition, NewDepartment);
                        updateAllPositionsView();
                        window.Close();
                    }

                    if (SelectedStaff != null)
                    {
                        if (NewStaffLastName == null || NewStaffLastName.Replace(" ", "").Length == 0)
                        {
                            SetRedBlock(window, "lastNameBox");
                        }
                        if (NewStaffFirstName == null || NewStaffFirstName.Replace(" ", "").Length == 0)
                        {
                            SetRedBlock(window, "firstNameBox");
                        }
                        if (NewStaffMiddleName == null || NewStaffMiddleName.Replace(" ", "").Length == 0)
                        {
                            SetRedBlock(window, "middleNameBox");
                        }
                        if (NewStaffPosition == null)
                        {
                            SetRedBlock(window, "positionBox");
                        }
                        if(NewStaffDateOfBrith == null || NewStaffDateOfBrith.Replace(" ", "").Length == 0)
                        {
                            SetRedBlock(window, "dateOfBrithBox");
                        }
                        if (NewStaffPhone == null || NewStaffPhone.Replace(" ", "").Length == 0)
                        {
                            SetRedBlock(window, "phoneBox");
                        }
                        if (NewStaffEmail == null || NewStaffEmail.Replace(" ", "").Length == 0)
                        {
                            SetRedBlock(window, "emailBox");
                        } else
                        {
                            result = DataWorker.EditStaff(
                            SelectedStaff,
                            NewStaffLastName,
                            NewStaffFirstName,
                            NewStaffMiddleName,
                            NewStaffPosition,
                            NewStaffDateOfBrith,
                            NewStaffPhone,
                            NewStaffEmail
                            );
                            updateAllStaffsView();
                            window.Close();
                        }       
                    }
                });
            }
        }

        #endregion

        #region SEARCH
        private RelayCommand filterButton;

        public RelayCommand FilterButton
        {
            get
            {
                return filterButton ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultText = "Не чего не найдено";
                    // если фильтр пуст то берем из БД всех
                    if ((FilterLastNameText == null || FilterLastNameText.Replace(" ", "").Length == 0)
                        && (FilterFirstNameText == null || FilterFirstNameText.Replace(" ", "").Length == 0)
                        && (FilterMiddleNameText == null || FilterMiddleNameText.Replace(" ", "").Length == 0))
                    {
                        AllStaffs = DataWorker.findAllStaffs();
                    }

                    // фильтруем по фамилии
                    if((FilterLastNameText != null && FilterLastNameText.Replace(" ", "").Length != 0)
                        && (FilterFirstNameText == null || FilterFirstNameText.Replace(" ", "").Length == 0)
                        && (FilterMiddleNameText == null || FilterMiddleNameText.Replace(" ", "").Length == 0))
                    {
                        AllStaffs = DataWorker.filter(FilterLastNameText, "", "");
                        if (AllStaffs.Count == 0) ShowMessage(resultText);
                    }

                    // фильтруем по имени
                    if ((FilterFirstNameText != null && FilterFirstNameText.Replace(" ", "").Length != 0)
                        && (FilterLastNameText == null || FilterLastNameText.Replace(" ", "").Length == 0)
                        && (FilterMiddleNameText == null || FilterMiddleNameText.Replace(" ", "").Length == 0))
                    {
                        AllStaffs = DataWorker.filter("", FilterFirstNameText, "");
                        if (AllStaffs.Count == 0) ShowMessage(resultText);
                    }

                    // фильтруем по отчеству
                    if ((FilterMiddleNameText != null && FilterMiddleNameText.Replace(" ", "").Length != 0)
                        && (FilterLastNameText == null || FilterLastNameText.Replace(" ", "").Length == 0)
                        && (FilterFirstNameText == null || FilterFirstNameText.Replace(" ", "").Length == 0))
                    {
                        AllStaffs = DataWorker.filter("", "", FilterMiddleNameText);
                        if (AllStaffs.Count == 0) ShowMessage(resultText);
                    }

                    // фильтруем по фамилии и имени
                    if ((FilterLastNameText != null && FilterLastNameText.Replace(" ", "").Length != 0)
                        && (FilterFirstNameText != null && FilterFirstNameText.Replace(" ", "").Length != 0)
                        && (FilterMiddleNameText == null || FilterMiddleNameText.Replace(" ", "").Length == 0))
                    {
                        AllStaffs = DataWorker.filter(FilterLastNameText, FilterFirstNameText, "");
                        if (AllStaffs.Count == 0) ShowMessage(resultText);
                    }

                    // фильтруем по фамилии, имени, отчеству
                    if ((FilterLastNameText != null && FilterLastNameText.Replace(" ", "").Length != 0)
                       && (FilterFirstNameText != null && FilterFirstNameText.Replace(" ", "").Length != 0)
                       && (FilterMiddleNameText != null && FilterMiddleNameText.Replace(" ", "").Length != 0))
                    {
                        AllStaffs = DataWorker.filter(FilterLastNameText, FilterFirstNameText, FilterMiddleNameText);
                        if (AllStaffs.Count == 0) ShowMessage(resultText);
                    }

                    // фильтруем по фамилии, отчеству
                    if ((FilterLastNameText != null && FilterLastNameText.Replace(" ", "").Length != 0)
                       && (FilterFirstNameText == null || FilterFirstNameText.Replace(" ", "").Length == 0)
                       && (FilterMiddleNameText != null && FilterMiddleNameText.Replace(" ", "").Length != 0))
                    {
                        AllStaffs = DataWorker.filter(FilterLastNameText, "", FilterMiddleNameText);
                        if (AllStaffs.Count == 0) ShowMessage(resultText);
                    }

                    // фильтруем по имени, отчеству
                    if ((FilterLastNameText == null || FilterLastNameText.Replace(" ", "").Length == 0)
                      && (FilterFirstNameText != null && FilterFirstNameText.Replace(" ", "").Length != 0)
                      && (FilterMiddleNameText != null && FilterMiddleNameText.Replace(" ", "").Length != 0))
                    {
                        AllStaffs = DataWorker.filter("", FilterFirstNameText, FilterMiddleNameText);
                        if (AllStaffs.Count == 0) ShowMessage(resultText);
                    }
                });
            }
        }

        #endregion

        #region UTILS
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void SetRedBlock(Window window, string blockName)
        {
            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        private void ShowMessage(string message)
        {
            MessageWindow messageWindow = new MessageWindow(message);
            SetCurrentPositionAndOpenWindow(messageWindow);
        }


        private void updateAllDepartmentsView()
        {
            AllDepartments = DataWorker.findAllDepartments();
            DepartmentWindow.AllDepartments.ItemsSource = null;
            DepartmentWindow.AllDepartments.Items.Clear();
            DepartmentWindow.AllDepartments.ItemsSource = AllDepartments;
            DepartmentWindow.AllDepartments.Items.Refresh();
            DepartmentName = null;
        }

        private void updateAllPositionsView()
        {
            AllPositions = DataWorker.findAllPositions();
            PositionWindow.AllPositions.ItemsSource = null;
            PositionWindow.AllPositions.Items.Clear();
            PositionWindow.AllPositions.ItemsSource = AllPositions;
            PositionWindow.AllPositions.Items.Refresh();
            PositionName = null;
            PositionDepartment = null;
        }

        private void updateAllStaffsView()
        {
            AllStaffs = DataWorker.findAllStaffs();
            StaffWindow.AllStaffs.ItemsSource = null;
            StaffWindow.AllStaffs.Items.Clear();
            StaffWindow.AllStaffs.ItemsSource = AllStaffs;
            StaffWindow.AllStaffs.Items.Refresh();
            StaffLastName = null;
            StaffFirstName = null;
            StaffMiddleName = null;
            StaffPosition = null;
            StaffDateOfBrith = null;
            StaffPhone = null;
            StaffEmail = null;
        }
        #endregion
    }
}
