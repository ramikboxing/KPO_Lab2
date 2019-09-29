using Kpo4381_nmv;
using Kpo4381_nmv.Lib;
using Kpo4381_nmv.Utility;
using KPO4381_nmv.Main.source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KPO4381_nmv.Main
{
    public partial class FrmMain : Form
    {
        private List<Car> carList = null;
        private BindingSource bsCars = new BindingSource();

        public FrmMain()
        {
            InitializeComponent();
        }
        private void mnExit_Click(object sender, EventArgs e)
        {
            Close();
           
        }
        private void mnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                //CarsList loader = new CarsList();

                //Получает имя текстового файла из conf
                //создает экз-р loader 
                LoadCarsListCommand loader = new LoadCarsListCommand(AppGlobalSetting.dataFileName);

                //вызов метода считает данные из файла и сформирует список
                loader.Execute();
                //Список передается на эранную форму DataGrid***
                bsCars.DataSource = loader.carsList;
                dgvCarList.DataSource = bsCars;
            }
            //Обработка исключения "Метод не реализован
            catch(NotImplementedException ex)
            {  
                MessageBox.Show("Ошибка №1:" + ex.Message);
               LogUtility.ErrorLog("Лаб-2 FrmMain"+ex.Message);
            }
            //Обработка остальных исключений
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка №2:" + ex.Message);
                LogUtility.ErrorLog("Лаб-2 FrmMain"+ex.Message);
            }
        }

        private void mnOpenCars_Click(object sender, EventArgs e)
        {
            try
            {
                //Создать экземпляр формы
                FrmCar frmCar = new FrmCar();
                //Задать ссылку на текущий объект в таблице
                Car car = (bsCars.Current as Car);
                Car carm = new Car();
                frmCar.SetCar(car);

                //Open Form2
                frmCar.ShowDialog();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show("Ошибка №3: в лаб-2" + ex.Message);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
